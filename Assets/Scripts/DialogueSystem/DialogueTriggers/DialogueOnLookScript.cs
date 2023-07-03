using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOnLookScript : MonoBehaviour
{
    public ObjectDialogue dialogue;
    private bool didPlay = false;
    [SerializeField]
    [Min(1)]
    private float hitRange = 3;
    private RaycastHit hit;
    public Transform playerCameraTransform;

    [SerializeField]
    private LayerMask dialogueOnLookLayer;
    public string targetName;
    void Update()
    {
        if (!didPlay)
        {
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, dialogueOnLookLayer))
            {
                if (hit.collider.gameObject.name == targetName)
                {
                    didPlay = true;
                    TriggerDialogue();
                }
            }
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManagerScript>().startDialogue(dialogue);
    }
}
