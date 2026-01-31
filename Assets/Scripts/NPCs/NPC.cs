using UnityEngine;
using UnityEngine.InputSystem;

public class NPC : MonoBehaviour
{
    public float interactionRange = 2f;

    private float sqrInteractionRange;
    private Transform player;
    private Camera mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sqrInteractionRange = interactionRange * interactionRange;
        player = GameObject.FindWithTag("Player").transform;
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - player.transform.position).sqrMagnitude <= sqrInteractionRange &&
            CanInteract())
        {
            GameManager.Instance.SetInteractableNPC(this);
        }
        else
        {
            GameManager.Instance.ResetInteractableNPC(this);
        }
    }

    public void Interact()
    {
        Debug.Log(name);
    }

    private bool CanInteract()
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit, interactionRange, 1 << gameObject.layer))
        {
            if (hit.collider.gameObject == gameObject)
            {
                return true;
            }
        }

        return false;
    }
}
