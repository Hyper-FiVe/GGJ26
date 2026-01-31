using UnityEngine;

public class Room : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("NPC"))
        {
            collision.gameObject.GetComponent<NPC>().features.room = this;
        }
    }
}
