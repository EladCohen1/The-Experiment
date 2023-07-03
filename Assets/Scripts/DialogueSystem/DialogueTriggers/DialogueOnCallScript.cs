using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOnCallScript : MonoBehaviour
{
    public ObjectDialogue dialogue;
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManagerScript>().startDialogue(dialogue);
    }
}
