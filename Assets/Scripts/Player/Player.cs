using UnityEngine;
using static Utils;

public class Player : MonoBehaviour
{
    public Mask mask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mask = (Mask)Random.Range(0, 3);
    }
}
