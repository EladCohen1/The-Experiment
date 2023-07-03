using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public AudioSource keysFalling;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5f)
        {
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            keysFalling.Play();
        }
    }
}
