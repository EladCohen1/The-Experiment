using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public PasueMenuScript pauseMenuScript;
    public DialogueManagerScript dialogueManager;
    public AudioSource footstepsSound;
    CharacterController controller;
    Vector3 velocity;
    public float playerSpeed = 2;
    public float mass = 1;
    public float jumpSpeed = 5;
    public Vector3 playerStartingRotation = new Vector3(0, 90, 0);

    // camera vars
    public Transform cameraTransform;
    public float mouseSens = 2;
    Vector2 look;

    private bool startedFinishAnimation = false;
    private bool doneFinishAnimation = false;
    public bool finish;

    public Animator gateAnimator;

    public EndTriggerScript endTriggerScript;
    private int finishPadding = 0;
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        look.x = playerStartingRotation.x;
        look.y = playerStartingRotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!(pauseMenuScript.gamePaused || dialogueManager.isInDialogue || finish))
        {
            UpdateLook();
            UpdateMovement();
            UpdateGravity();
            UpdateFootstepSounds();
        }
        else
        {
            footstepsSound.enabled = false;
        }
        if (finish && gateAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.5f)
        {
            startedFinishAnimation = true;
        }
        if (startedFinishAnimation && !doneFinishAnimation)
        {
            if (look.x < 0 && look.x > -180)
            {
                transform.localRotation = Quaternion.Euler(0, look.x, 0);
                look.x -= 6;
            }
            if (look.x < 180 && look.x > 0)
            {
                transform.localRotation = Quaternion.Euler(0, look.x, 0);
                look.x += 6;
            }
            if (look.y < 0)
            {
                look.y += 6;
                cameraTransform.localRotation = Quaternion.Euler(-look.y, 0, 0);
            }
            if (look.y > 6)
            {
                look.y -= 6;
                cameraTransform.localRotation = Quaternion.Euler(-look.y, 0, 0);
            }
            if ((look.y <= 6 && look.y >= 0) && ((look.x >= 180 && look.x <= 186) || (look.x >= -186 && look.x <= -180)))
            {
                if (finishPadding < 60)
                {
                    finishPadding++;
                }
                else
                {
                    doneFinishAnimation = true;
                    endTriggerScript.GoToBlack();
                }
            }
        }
    }

    void UpdateLook()
    {
        look.x += Input.GetAxis("Mouse X") * mouseSens;
        look.y += Input.GetAxis("Mouse Y") * mouseSens;
        look.y = Mathf.Clamp(look.y, -90, 90);
        cameraTransform.localRotation = Quaternion.Euler(-look.y, 0, 0);
        transform.localRotation = Quaternion.Euler(0, look.x, 0);
    }

    void UpdateMovement()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        var input = new Vector3();
        input += transform.forward * z;
        input += transform.right * x;
        input = Vector3.ClampMagnitude(input, 1);
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = jumpSpeed;
        }
        else
        {
            UpdateGravity();
        }
        controller.Move((input * playerSpeed + velocity) * Time.deltaTime);
    }

    void UpdateGravity()
    {
        var gravity = Physics.gravity * mass * Time.deltaTime;
        velocity.y = controller.isGrounded ? -1 : velocity.y + gravity.y;
    }

    void UpdateFootstepSounds()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
        {
            footstepsSound.enabled = true;
        }
        else
        {
            footstepsSound.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "EndTrigger")
        {
            finish = true;
        }
    }
}
