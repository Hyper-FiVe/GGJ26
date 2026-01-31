using UnityEngine;
using UnityEngine.InputSystem;

public class NPC : MonoBehaviour
{
    public float interactionRange = 2f;
    public float rotationTime = 0.2f;

    private float sqrInteractionRange;
    private Quaternion defaultRotation;
    private Quaternion targetRotation;
    private Transform player;
    private Camera mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sqrInteractionRange = interactionRange * interactionRange;
        defaultRotation = transform.rotation;
        targetRotation = defaultRotation;
        player = GameObject.FindWithTag("Player").transform;
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - player.transform.position).sqrMagnitude <= sqrInteractionRange &&
            CanInteract())
        {
            GameManager.Instance.InteractableNPC = this;
        }
        else if (GameManager.Instance.InteractableNPC == this)
        {
            GameManager.Instance.InteractableNPC = null;
        }

        RotateTowardsTarget();
    }

    public void Interact()
    {
        GameManager.Instance.InteractingNPC = this;

        Vector3 direction = player.position - transform.position;
        direction.y = 0;
        targetRotation = Quaternion.LookRotation(direction);
    }

    public void EndInteraction()
    {
        GameManager.Instance.InteractingNPC = null;
        targetRotation = defaultRotation;
    }

    private bool CanInteract()
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        return Physics.Raycast(ray, out RaycastHit hit, interactionRange, 1 << gameObject.layer) &&
            (hit.collider.gameObject == gameObject);
    }

    private void RotateTowardsTarget()
    {
        float angleDifference = Quaternion.Angle(transform.rotation, targetRotation);
        float rotationSpeed = angleDifference / rotationTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
