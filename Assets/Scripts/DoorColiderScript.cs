using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorColiderScript : MonoBehaviour
{
    public DoorScript doorScript;
    Animator doorAnimator;
    public PickUpLogicScript pickUpLogic;
    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = doorScript.animator;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DoorControll("Open");
            Destroy(pickUpLogic.inHandItem);
        }
    }

    void DoorControll(string state)
    {
        doorAnimator.SetTrigger(state);
    }
}
