using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTriggerScript : MonoBehaviour
{
    public Animator gateAnimator;
    public AudioSource gateSlam;
    public AudioSource endBang;

    public Canvas victoryUI;
    public Animator victoryUIAnimator;
    public AudioSource victoryUIMusic;
    public bool didEnd = false;
    void Start()
    {
        endBang = gameObject.GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(GameObject.Find("BackgroundMusic"));
            gateAnimator.SetBool("IsOpen", false);
            gateSlam.Play();
        }
    }

    public void GoToBlack()
    {
        Cursor.lockState = CursorLockMode.None;
        didEnd = true;
        endBang.Play();
        victoryUI.enabled = true;
        Invoke(nameof(FadeVictoryUIButtons), 3);
    }

    private void FadeVictoryUIButtons()
    {
        victoryUIMusic.Play();
        victoryUIAnimator.SetTrigger("IsOpen");
    }
    public void moveToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
