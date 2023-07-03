using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSolutionScript : MonoBehaviour
{
    public GameObject key;
    void Start()
    {
        key.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gameObject.GetComponent<DialogueOnTriggerChainScript>().myTurn)
                key.SetActive(true);
        }
    }
}
