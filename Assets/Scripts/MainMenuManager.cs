using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public Canvas quitMenu;
    public Button playText;
    public Button quitText;
    // Start is called before the first frame update
    void Start()
    {
        quitMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void QuitMenuOpen()
    {
        quitMenu.enabled = true;
        playText.enabled = false;
        quitText.enabled = false;
    }

    public void QuitMenuClose()
    {
        quitMenu.enabled = false;
        playText.enabled = true;
        quitText.enabled = true;
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
