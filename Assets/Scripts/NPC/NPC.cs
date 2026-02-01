using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Utils;
using Random = UnityEngine.Random;

public class NPC : MonoBehaviour
{
    public float interactionRange = 2f;
    public float rotationTime = 0.2f;

    private float sqrInteractionRange;
    private Quaternion defaultRotation;
    private Quaternion targetRotation;
    private Transform player;
    private Camera mainCamera;

    [Serializable]
    public struct NPCFeatures
    {
        public bool sex;
        public Mask mask;
        public NPCColor color;
        public bool head;
        public bool neck;
        public Voice voice;
        public Room room;
        public Title title;
        public bool interacted;
        public Faction faction;
    }

    public NPCFeatures features;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sqrInteractionRange = interactionRange * interactionRange;
        defaultRotation = transform.rotation;
        targetRotation = defaultRotation;
        player = GameObject.FindWithTag("Player").transform;
        mainCamera = Camera.main;

        features.sex = Convert.ToBoolean(Random.Range(0, 2));
        features.color = (NPCColor)Random.Range(0, 4);

        int prefabIndex = (int)features.color;
        GameObject prefab = (features.sex) ?
            NPCManager.Instance.malePrefabs[prefabIndex] :
            NPCManager.Instance.femalePrefabs[prefabIndex];
        GameObject body = Instantiate(prefab, transform);

        body.AddComponent<Animator>().runtimeAnimatorController =
            GetComponent<Animator>().runtimeAnimatorController;

        features.mask = (Mask)Random.Range(0, 3);

        features.head = Convert.ToBoolean(Random.Range(0, 2));
        if (features.head)
        {
            prefab = (features.sex) ? NPCManager.Instance.maleHead : NPCManager.Instance.femaleHead;
            Instantiate(prefab, transform);
        }

        features.neck = Convert.ToBoolean(Random.Range(0, 2));
        if (features.neck)
        {
            prefab = (features.sex) ? NPCManager.Instance.maleNeck : NPCManager.Instance.femaleNeck;
            Instantiate(prefab, transform);
        }


        features.voice = (Voice)Random.Range(0, 4);

        int offset = features.sex ? 0 : 2;
        features.title = (Title)Random.Range(offset, 2 + offset);

        features.interacted = Convert.ToBoolean(Random.Range(0, 2));

        SetFaction();

        GameManager.Instance.AddNPC(this);
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - player.transform.position).sqrMagnitude <= sqrInteractionRange &&
            CanInteract())
        {
            GameManager.Instance.InteractableNPC = this;
        }
        else if (GameManager.Instance.InteractableNPC == this)
        {
            GameManager.Instance.InteractableNPC = null;
        }

        RotateTowardsTarget();
    }

    public void Interact()
    {
        GameManager.Instance.InteractingNPC = this;

        Vector3 direction = player.position - transform.position;
        direction.y = 0;
        targetRotation = Quaternion.LookRotation(direction);

        GameManager.Instance.StartDialogue();
    }

    public void EndInteraction()
    {
        GameManager.Instance.InteractingNPC = null;
        targetRotation = defaultRotation;
    }

    private bool CanInteract()
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        return Physics.Raycast(ray, out RaycastHit hit, interactionRange, 1 << gameObject.layer) &&
            (hit.collider.gameObject == gameObject);
    }

    private void RotateTowardsTarget()
    {
        float angleDifference = Quaternion.Angle(transform.rotation, targetRotation);
        float rotationSpeed = angleDifference / rotationTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void SetFaction()
    {
        if (features.mask == GameManager.Instance.Player.mask)
        {
            features.faction = Faction.ALLY;
        }
        if (features.mask == Mask.TEAM1)
        {
            if (GameManager.Instance.Player.mask == Mask.TEAM2)
            {
                features.faction = Faction.ENEMY;
            }
            if (GameManager.Instance.Player.mask == Mask.TEAM3)
            {
                features.faction = Faction.NEUTRAL;
            }
        }
        if (features.mask == Mask.TEAM2)
        {
            if (GameManager.Instance.Player.mask == Mask.TEAM3)
            {
                features.faction = Faction.ENEMY;
            }
            if (GameManager.Instance.Player.mask == Mask.TEAM1)
            {
                features.faction = Faction.NEUTRAL;
            }
        }
        if (features.mask == Mask.TEAM3)
        {
            if (GameManager.Instance.Player.mask == Mask.TEAM1)
            {
                features.faction = Faction.ENEMY;
            }
            if (GameManager.Instance.Player.mask == Mask.TEAM2)
            {
                features.faction = Faction.NEUTRAL;
            }
        }
    }
}
