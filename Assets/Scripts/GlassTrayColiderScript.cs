using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassTrayColiderScript : MonoBehaviour
{
    public AudioSource glassCracklingAudio;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            glassCracklingAudio.Play();
        }
    }
}
