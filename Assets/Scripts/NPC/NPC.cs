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
        //public bool target
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
        features.mask = (Mask)Random.Range(0, 3);
        features.color = (NPCColor)Random.Range(0, 4);
        features.head = Convert.ToBoolean(Random.Range(0, 2));
        features.neck = Convert.ToBoolean(Random.Range(0, 2));
        features.voice = (Voice)Random.Range(0, 4);
        features.title = (Title)Random.Range(0, 4);
        features.interacted = Convert.ToBoolean(Random.Range(0, 2));
        this.SetFaction();
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
        if (this.features.mask == GameManager.pc.mask)
        {
            this.features.faction = Utils.Faction.ally;
        }
        if (this.features.mask == Utils.Mask.team1)
        {
            if (GameManager.pc.mask == Utils.Mask.team2)
            {
                this.features.faction = Utils.Faction.enemy;
            }
            if (GameManager.pc.mask == Utils.Mask.team3)
            {
                this.features.faction = Utils.Faction.neutral;
            }
        }
        if (this.features.mask == Utils.Mask.team2)
        {
            if (GameManager.pc.mask == Utils.Mask.team3)
            {
                this.features.faction = Utils.Faction.enemy;
            }
            if (GameManager.pc.mask == Utils.Mask.team1)
            {
                this.features.faction = Utils.Faction.neutral;
            }
        }
        if (this.features.mask == Utils.Mask.team3)
        {
            if (GameManager.pc.mask == Utils.Mask.team1)
            {
                this.features.faction = Utils.Faction.enemy;
            }
            if (GameManager.pc.mask == Utils.Mask.team2)
            {
                this.features.faction = Utils.Faction.neutral;
            }
        }

    }

}
