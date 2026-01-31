using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject npcPrefab;
    public int npcCount = 2;

    private List<NPC> spawnedNpcs = new List<NPC>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < npcCount && i < transform.childCount; i++)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Transform npcSpawn;

        do
        {
            int randomSpawn = Random.Range(0, transform.childCount);
            npcSpawn = transform.GetChild(randomSpawn).transform;
        } while (npcSpawn.childCount > 0);

        GameObject npcObject = Instantiate(npcPrefab, npcSpawn.position, npcSpawn.rotation, npcSpawn);
        spawnedNpcs.Add(npcObject.GetComponent<NPC>());
    }
}
