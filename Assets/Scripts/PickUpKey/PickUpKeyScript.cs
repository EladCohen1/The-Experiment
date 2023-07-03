using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKeyScript : MonoBehaviour, PickUpItemScriptInterface
{
    public PickUpLogicScript pickUpLogicScript;
    public void PickUp()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        pickUpLogicScript.inHandItem = gameObject;
        pickUpLogicScript.inHandItem.transform.position = new Vector3(0.305f, -0.063f, 0.358f);
        pickUpLogicScript.inHandItem.transform.rotation = Quaternion.identity;
        pickUpLogicScript.inHandItem.transform.SetParent(pickUpLogicScript.pickUpParent.transform, false);
        rb.isKinematic = true;
    }
}
