using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public List<string> dialogues = new List<string>();

    public TextMeshProUGUI textBox;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        string dialogue = "Hai premuto un bottone";

        // logica

        textBox.text = dialogue;
        //transform.parent.gameObject.SetActive(false);
    }

    public void OnExitDialogue()
    {
        GameManager.Instance.EndDialogue();
    }
}
