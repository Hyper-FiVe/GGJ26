using UnityEngine;
using static Utils;

public class NPCSpawner : MonoBehaviour
{
    public GameObject npcPrefab;
    public Room room;

    public void Spawn()
    {
        for (int i = 0; i < GameManager.Instance.RoomNPCCount && i < transform.childCount; i++)
        {
            Transform npcSpawn;

            do
            {
                int randomSpawn = Random.Range(0, transform.childCount);
                npcSpawn = transform.GetChild(randomSpawn).transform;
            } while (npcSpawn.childCount > 0);

            GameObject npcObject = Instantiate(npcPrefab, npcSpawn.position, npcSpawn.rotation, npcSpawn);
            npcObject.name = "NPC " + room + " " + npcSpawn.GetSiblingIndex();
            NPC npc = npcObject.GetComponent<NPC>();
            npc.features.room = room;
            GameManager.Instance.AddNPC(npc);
        }
    }
}
