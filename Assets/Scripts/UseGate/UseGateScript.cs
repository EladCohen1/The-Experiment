using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseGateScript : MonoBehaviour, UseScriptInterface
{
    DialogueOnCallScript dialogue;
    Animator GateAnimator;
    void Awake()
    {
        GateAnimator = gameObject.GetComponent<Animator>();
        dialogue = gameObject.GetComponent<DialogueOnCallScript>();
    }
    public void Use(GameObject usedItem)
    {
        if (usedItem.name == "Key")
        {
            GateAnimator.SetBool("IsOpen", true);
            Destroy(usedItem);
            dialogue.TriggerDialogue();
        }
    }
}
