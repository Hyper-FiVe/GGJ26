using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public NPC npc;
    public List<string> dialogues = new List<string>();
    public string question, answer;

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

        // logica
        npc = GameManager.Instance.InteractingNPC;
        question = (string)GameObject.FindWithTag("Quest").GetComponentInChildren<TMP_Text>().name;
        
        switch (question)
        {
            case "Colour":
                if (npc.features.faction == Utils.Faction.ally)
                {
                    // serve sapere l'attributo dell'npc da trovare
                    // dopo si restituisce la risposta corrispondente a quel colore
                } else
                {
                    if (npc.features.faction == Utils.Faction.neutral)
                    {
                        // qui mettiamo la risposta neutra
                        answer = dialogues[0];
                    } else
                    {
                        if (npc.features.faction == Utils.Faction.enemy)
                        {
                            // qui si mette una risposta random tra tutte tranne quella giusta
                        }
                    }
                }
                    break;
            case "Head":
                if (npc.features.faction == Utils.Faction.ally)
                {
                    // serve sapere l'attributo dell'npc da trovare
                    // dopo si restituisce la risposta corrispondente a quel colore
                }
                else
                {
                    if (npc.features.faction == Utils.Faction.neutral)
                    {
                        // qui mettiamo la risposta neutra
                        answer = dialogues[0];
                    }
                    else
                    {
                        if (npc.features.faction == Utils.Faction.enemy)
                        {
                            // qui si mette una risposta random tra tutte tranne quella giusta
                        }
                    }
                }
                break;
            case "Neck":
                if (npc.features.faction == Utils.Faction.ally)
                {
                    // serve sapere l'attributo dell'npc da trovare
                    // dopo si restituisce la risposta corrispondente a quel colore
                }
                else
                {
                    if (npc.features.faction == Utils.Faction.neutral)
                    {
                        // qui mettiamo la risposta neutra
                        answer = dialogues[0];
                    }
                    else
                    {
                        if (npc.features.faction == Utils.Faction.enemy)
                        {
                            // qui si mette una risposta random tra tutte tranne quella giusta
                        }
                    }
                }
                break;
            case "Voice":
                if (npc.features.faction == Utils.Faction.ally)
                {
                    // serve sapere l'attributo dell'npc da trovare
                    // dopo si restituisce la risposta corrispondente a quel colore
                }
                else
                {
                    if (npc.features.faction == Utils.Faction.neutral)
                    {
                        // qui mettiamo la risposta neutra
                        answer = dialogues[0];
                    }
                    else
                    {
                        if (npc.features.faction == Utils.Faction.enemy)
                        {
                            // qui si mette una risposta random tra tutte tranne quella giusta
                        }
                    }
                }
                break;
            case "Position":
                if (npc.features.faction == Utils.Faction.ally)
                {
                    // serve sapere l'attributo dell'npc da trovare
                    // dopo si restituisce la risposta corrispondente a quel colore
                }
                else
                {
                    if (npc.features.faction == Utils.Faction.neutral)
                    {
                        // qui mettiamo la risposta neutra
                        answer = dialogues[0];
                    }
                    else
                    {
                        if (npc.features.faction == Utils.Faction.enemy)
                        {
                            // qui si mette una risposta random tra tutte tranne quella giusta
                        }
                    }
                }
                break;
        }

        textBox.text = answer;
        //transform.parent.gameObject.SetActive(false);
    }

    public void OnExitDialogue()
    {
        GameManager.Instance.EndDialogue();
    }
}
