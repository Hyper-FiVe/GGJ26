using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static NPCManager Instance { get; private set; }

    public List<GameObject> malePrefabs = new List<GameObject>();
    public List<GameObject> femalePrefabs = new List<GameObject>();
    public List<GameObject> maskPrefabs = new List<GameObject>();
    public List<AudioClip> voices = new List<AudioClip>();

    public GameObject maleHead;
    public GameObject femaleHead;
    public GameObject maleNeck;
    public GameObject femaleNeck;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(transform.parent);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
