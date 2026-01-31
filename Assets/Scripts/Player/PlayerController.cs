using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSpeed = 0.05f;
    public float lookRange = 80f;

    private CharacterController controller;
    private Transform cameraTransform;
    private Vector2 moveInput;
    private float rotationX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        rotationX -= input.y * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookRange, lookRange);
        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        transform.Rotate(input.x * lookSpeed * Vector3.up);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GameManager.Instance.InteractWithNPC();
        }
    }

    private void Move()
    {
        Vector3 movement = transform.right * moveInput.x + transform.forward * moveInput.y;
        controller.SimpleMove(moveSpeed * movement);
    }
}
