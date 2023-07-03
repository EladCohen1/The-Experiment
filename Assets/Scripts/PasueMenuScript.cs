using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PasueMenuScript : MonoBehaviour
{
    public DialogueManagerScript dialogueManager;
    public EndTriggerScript endTriggerScript;
    public bool gamePaused = false;
    public Canvas pauseMenuCanvas;
    public Button resumeButton;
    public Button quitButton;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !dialogueManager.isInDialogue && (endTriggerScript == null || !endTriggerScript.didEnd))
        {
            gamePaused = !gamePaused;
            if (gamePaused)
            {
                PauseMenuOpen();
            }
            else
            {
                PauseMenuClose();
            }
        }
    }

    public void PauseMenuOpen()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenuCanvas.enabled = true;
        resumeButton.enabled = true;
        quitButton.enabled = true;
    }

    public void PauseMenuClose()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuCanvas.enabled = false;
        gamePaused = false;
    }

    public void QuitToMainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }
}
