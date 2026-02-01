using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class DialogueButton : MonoBehaviour
{
    public NPC npc;
    public List<string> dialogues = new List<string>();
    public string question, answer;

    public TextMeshProUGUI textBox;

    public void OnClick()
    {
        npc = GameManager.Instance.InteractingNPC;
        question = GameObject.FindWithTag("Quest").GetComponentInChildren<TMP_Text>().name;
        int correctIndex;

        switch (question)
        {
            case "Colour":
                correctIndex = (int)GameManager.Instance.target.features.color + 1;

                if (npc.features.faction == Utils.Faction.ALLY)
                {
                    answer = dialogues[correctIndex];
                } else
                {
                    if (npc.features.faction == Utils.Faction.NEUTRAL)
                    {
                        answer = dialogues[0];
                    } else
                    {
                        if (npc.features.faction == Utils.Faction.ENEMY)
                        {
                            answer = GetRandomAnswer(correctIndex);
                        }
                    }
                }
                    break;
            case "Head":
                correctIndex = Convert.ToInt32(GameManager.Instance.target.features.head) + 1;

                if (npc.features.faction == Utils.Faction.ALLY)
                {
                    answer = dialogues[correctIndex];
                }
                else
                {
                    if (npc.features.faction == Utils.Faction.NEUTRAL)
                    {
                        answer = dialogues[0];
                    }
                    else
                    {
                        if (npc.features.faction == Utils.Faction.ENEMY)
                        {
                            answer = GetRandomAnswer(correctIndex);
                        }
                    }
                }
                break;
            case "Neck":
                correctIndex = Convert.ToInt32(GameManager.Instance.target.features.neck) + 1;

                if (npc.features.faction == Utils.Faction.ALLY)
                {
                    answer = dialogues[correctIndex];
                }
                else
                {
                    if (npc.features.faction == Utils.Faction.NEUTRAL)
                    {
                        answer = dialogues[0];
                    }
                    else
                    {
                        if (npc.features.faction == Utils.Faction.ENEMY)
                        {
                            answer = GetRandomAnswer(correctIndex);
                        }
                    }
                }
                break;
            case "Voice":
                correctIndex = (int)GameManager.Instance.target.features.voice + 1;

                if (npc.features.faction == Utils.Faction.ALLY)
                {
                    answer = dialogues[correctIndex];
                }
                else
                {
                    if (npc.features.faction == Utils.Faction.NEUTRAL)
                    {
                        answer = dialogues[0];
                    }
                    else
                    {
                        if (npc.features.faction == Utils.Faction.ENEMY)
                        {
                            answer = GetRandomAnswer(correctIndex);
                        }
                    }
                }
                break;
            case "Position":
                correctIndex = (int)GameManager.Instance.target.features.room + 1;

                if (npc.features.faction == Utils.Faction.ALLY)
                {
                    answer = dialogues[correctIndex];
                }
                else
                {
                    if (npc.features.faction == Utils.Faction.NEUTRAL)
                    {
                        answer = dialogues[0];
                    }
                    else
                    {
                        if (npc.features.faction == Utils.Faction.ENEMY)
                        {
                            answer = GetRandomAnswer(correctIndex);
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

    private string GetRandomAnswer(int correctIndex)
    {
        int index;
        do
        {
            index = Random.Range(1, dialogues.Count);
        } while (index == correctIndex);
        return dialogues[index];
    }
}
