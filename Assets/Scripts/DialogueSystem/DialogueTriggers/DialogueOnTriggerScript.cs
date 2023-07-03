using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOnTriggerScript : MonoBehaviour
{
    public ObjectDialogue dialogue;
    private bool didPlay = false;
    void OnTriggerEnter(Collider other)
    {
        if (!didPlay)
        {
            if (other.gameObject.tag == "Player")
            {
                didPlay = true;
                TriggerDialogue();
            }
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManagerScript>().startDialogue(dialogue);
    }
}
