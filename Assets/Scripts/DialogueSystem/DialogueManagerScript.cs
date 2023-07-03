using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerScript : MonoBehaviour
{
    public Animator dialogueUIAnimator;
    public Canvas dialogueUI;
    public Text nameText;
    public Text dialogueText;
    public Queue<string> sentances;
    public bool isInDialogue = false;
    private bool isTyping;
    private string lastDequeued;
    void Awake()
    {
        dialogueUI.enabled = false;
        sentances = new Queue<string>();
    }
    public void startDialogue(ObjectDialogue dialogue)
    {
        dialogueUIAnimator.SetBool("IsOpen", true);
        Cursor.lockState = CursorLockMode.None;
        isInDialogue = true;
        nameText.text = dialogue.name;
        foreach (string sentance in dialogue.sentences)
        {
            sentances.Enqueue(sentance);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        dialogueText.text = "";
        if (isTyping)
        {
            dialogueText.text = lastDequeued;
            StopAllCoroutines();
            isTyping = false;
        }
        else
        {
            if (sentances.Count > 0)
            {
                lastDequeued = sentances.Dequeue();
                StartCoroutine(TypeSentence(lastDequeued));
            }
            else
            {
                EndDialogue();
            }
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        isTyping = false;
    }

    void EndDialogue()
    {
        isInDialogue = false;
        Cursor.lockState = CursorLockMode.Locked;
        dialogueUIAnimator.SetBool("IsOpen", false);
    }
}
