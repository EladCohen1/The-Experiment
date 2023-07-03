using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOnTriggerChainScript : MonoBehaviour
{
    public GameObject nextInChain;
    public ObjectDialogue dialogue;
    public bool myTurn = true;
    void Start()
    {
        if (nextInChain != null)
        {
            nextInChain.GetComponent<DialogueOnTriggerChainScript>().myTurn = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (myTurn)
        {
            if (other.gameObject.tag == "Player")
            {
                TriggerDialogue();
                myTurn = false;
                if (nextInChain != null)
                    nextInChain.GetComponent<DialogueOnTriggerChainScript>().myTurn = true;
            }
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManagerScript>().startDialogue(dialogue);
    }
}
