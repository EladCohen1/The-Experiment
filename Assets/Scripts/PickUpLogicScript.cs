using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLogicScript : MonoBehaviour
{
    [SerializeField]
    private LayerMask pickableLayerMask;
    [SerializeField]
    private LayerMask useableOnLayerMask;
    [SerializeField]
    private LayerMask firstPickableLayerMask;
    [SerializeField]
    private LayerMask firstUseableOnLayerMask;
    [SerializeField]
    private Transform playerCameraTransform;
    [SerializeField]
    private Canvas pickUpUI;
    [SerializeField]
    private Canvas useUI;
    [SerializeField]
    [Min(1)]
    private float hitRange = 3;
    private RaycastHit hit;

    [SerializeField]
    public Transform pickUpParent;

    [SerializeField]
    public GameObject inHandItem;

    public PlayerScript playerScript;

    void Update()
    {
        if (!(playerScript.pauseMenuScript.gamePaused || playerScript.dialogueManager.isInDialogue))
        {
            if (hit.collider != null)
            {
                pickUpUI.enabled = false;
            }
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, firstUseableOnLayerMask) && inHandItem)
            {
                useUI.enabled = true;
            }
            else
            {
                useUI.enabled = false;
            }

            if (inHandItem != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    DropItem();
                }
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    UseItem();
                }
                return;
            }

            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, firstPickableLayerMask))
            {
                pickUpUI.enabled = true;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!inHandItem)
                {
                    PickUp();
                }
            }
        }
        else
        {
            pickUpUI.enabled = false;
            useUI.enabled = false;
        }
    }

    private void UseItem()
    {
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, useableOnLayerMask) ||
        Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, firstUseableOnLayerMask))
        {
            if (hit.collider.gameObject.GetComponent<UseScriptInterface>() != null)
            {
                hit.collider.gameObject.GetComponent<UseScriptInterface>().Use(inHandItem);
            }
        }
    }

    private void PickUp()
    {
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, firstPickableLayerMask) ||
        Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, pickableLayerMask))
        {
            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<PickUpItemScriptInterface>() != null)
                {
                    hit.collider.GetComponent<PickUpItemScriptInterface>().PickUp();
                }
            }
        }
    }

    private void DropItem()
    {
        Rigidbody rb = inHandItem.GetComponent<Rigidbody>();
        inHandItem.transform.SetParent(null);
        if (rb)
        {
            rb.isKinematic = false;
        }
        inHandItem = null;
    }
}
