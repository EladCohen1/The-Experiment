using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockingTriggerScript : MonoBehaviour
{
    public AudioSource knocking;
    public AudioSource breathing;
    private bool hasPlayed = false;
    void Awake()
    {
        hasPlayed = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !hasPlayed)
        {
            knocking.Play();
            hasPlayed = true;
            breathing.volume += 30;
        }
    }
}
