using UnityEngine;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    private PlayerInput input;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
        CloseDialogue();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            CloseDialogue();
        }
    }

    private void CloseDialogue()
    {
        GameManager.Instance.InteractingNPC.EndInteraction();
        input.SwitchCurrentActionMap("Player");
    }
}
