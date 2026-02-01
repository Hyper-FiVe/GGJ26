using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int npcCount = 8;
    public GameObject dialogueCanvas;
    public TextMeshProUGUI introText;

    public NPC target;

    public static GameManager Instance { get; private set; }
    public Player Player { get; private set; }
    public NPC InteractableNPC { get; set; }
    public NPC InteractingNPC { get; set; }
    public int RoomNPCCount => npcCount / 4;

    private PlayerController playerController;
    private List<GameObject> npcSpawnerObjects = new List<GameObject>();
    private List<NPC> npcs;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Player>();
        playerController = Player.GetComponent<PlayerController>();
        npcs = new List<NPC>(npcCount);
        GameObject.FindGameObjectsWithTag("NPCSpawner", npcSpawnerObjects);

        foreach (GameObject npcSpawner in npcSpawnerObjects)
        {
            npcSpawner.GetComponent<NPCSpawner>().Spawn();
        }

        target = npcs[Random.Range(0, npcs.Count)];
    }

    public void AddNPC(NPC npc)
    {
        npcs.Add(npc);
    }

    public void StartDialogue()
    {
        string title = Utils.titles[(int)InteractingNPC.features.title];
        introText.text = $"“Greetings, you can refer to me as {title}. What thou need?”";
        dialogueCanvas.SetActive(true);
        InteractingNPC.voice.Play();
    }

    public void EndDialogue()
    {
        dialogueCanvas.SetActive(false);
        InteractingNPC.EndInteraction();
        playerController.IsInteracting = false;
    }
}
