using UnityEngine;

public class GameManager : MonoBehaviour
{
    private NPC interactableNPC;

    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetInteractableNPC(NPC interactableNPC)
    {
        this.interactableNPC = interactableNPC;
    }

    public void ResetInteractableNPC(NPC npc)
    {
        if (interactableNPC == npc)
        {
            interactableNPC = null;
        }
    }

    public void InteractWithNPC()
    {
        if (interactableNPC != null)
        {
            interactableNPC.Interact();
        }
    }
}
