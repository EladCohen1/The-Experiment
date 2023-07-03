using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseDoorScript : MonoBehaviour, UseScriptInterface
{
    DialogueOnCallScript dialogue;
    Animator doorAnimator;
    void Awake()
    {
        doorAnimator = gameObject.GetComponent<Animator>();
        dialogue = gameObject.GetComponent<DialogueOnCallScript>();
    }

    public void Use(GameObject usedItem)
    {
        if (usedItem.name == "Key")
        {
            DoorControll("Open");
            Destroy(usedItem);
            dialogue.TriggerDialogue();
        }
    }

    void DoorControll(string state)
    {
        doorAnimator.SetTrigger(state);
    }
}
