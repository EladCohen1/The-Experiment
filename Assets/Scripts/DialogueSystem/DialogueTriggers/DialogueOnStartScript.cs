using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOnStartScript : MonoBehaviour
{
    public ObjectDialogue dialogue;
    void Start()
    {
        TriggerDialogue();
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManagerScript>().startDialogue(dialogue);
    }
}
