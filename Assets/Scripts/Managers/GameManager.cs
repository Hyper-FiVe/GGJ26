using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject dialogueCanvas;

    public static GameManager Instance { get; private set; }
    public NPC InteractableNPC { get; set; }
    public NPC InteractingNPC { get; set; }

    private PlayerController playerController;

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

    private void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    public void StartDialogue()
    {
        dialogueCanvas.SetActive(true);
    }

    public void EndDialogue()
    {
        dialogueCanvas.SetActive(false);
        InteractingNPC.EndInteraction();
        playerController.IsInteracting = false;
    }
}
