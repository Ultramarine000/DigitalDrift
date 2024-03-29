using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover3D : MonoBehaviour
{
    [Header("speed")]
    public float groundMoveSpeed = 7f;
    //private float movementForce = 1f;

    public Rigidbody rb;

    private Vector3 moveDirection = Vector3.zero;
    //private Vector2 inputVector = Vector2.zero;
    private PlayerInputHandler pih;

    [Header("environment check")]
    public float footOffset = 0.4f;
    public float floatingSpeed = 200;
    public LayerMask groundLayer;
    [SerializeField]
    public bool isOnGround = false;
    public Animator anim;

    [SerializeField]
    public Camera playerCamera;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pih = GetComponent<PlayerInputHandler>();
        playerCamera = GameObject.Find("Camera3D").GetComponent<Camera>();
        //animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }
        PhysicsCheck();
        OnMove();
        LookAt();

    }
    void PhysicsCheck()
    {
        bool leftFrontCheckGround = Raycast(new Vector3(-footOffset - 0.1f, 0.5f, footOffset + 0.1f), Vector3.down, 1f, groundLayer);
        bool rightFrontCheckGround = Raycast(new Vector3(footOffset + 0.1f, 0.5f, footOffset + 0.1f), Vector3.down, 1f, groundLayer);
        bool leftBackCheckGround = Raycast(new Vector3(-footOffset - 0.1f, 0.5f, -footOffset - 0.1f), Vector3.down, 1f, groundLayer);
        bool rightBackCheckGround = Raycast(new Vector3(footOffset + 0.1f, 0.5f, -footOffset - 0.1f), Vector3.down, 1f, groundLayer);

        //groundCheck
        if (leftFrontCheckGround || rightFrontCheckGround || leftBackCheckGround || rightBackCheckGround)
        {
            isOnGround = true;
        }
        else
            isOnGround = false;
    }
    bool Raycast(Vector3 offset, Vector3 rayDirection, float length, LayerMask layer)
    {
        Vector3 pos = transform.position;

        bool hit = Physics.Raycast(pos + offset, rayDirection, length, layer);

        Color color = hit ? Color.red : Color.green;

        Debug.DrawRay(pos + offset, rayDirection * length, color);

        return hit;
    }
    void OnMove()
    {
        if (isOnGround)
        {
            //rb.velocity = new Vector3(pih.processiveForce.x * moveSpeed, rb.velocity.y, pih.processiveForce.z * moveSpeed);
            moveDirection += pih.leftStickInput.x * GetCameraRight(playerCamera);
            moveDirection += pih.leftStickInput.y * GetCameraForward(playerCamera);

            if (Mathf.Abs(pih.leftStickInput.x) < 0.02f || Mathf.Abs(pih.leftStickInput.y) < 0.02f)
            {
                float vy = rb.velocity.y;
                rb.velocity = new Vector3(0, vy, 0);
            }
            else 
            {
                rb.velocity = new Vector3(moveDirection.x * groundMoveSpeed, rb.velocity.y, groundMoveSpeed * moveDirection.z);
            }

            moveDirection = Vector3.zero;

            //if (rb.velocity.y < 0f)
            //    rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;

            Vector3 horizontalVelocity = rb.velocity;
            horizontalVelocity.y = 0;
            if (horizontalVelocity.sqrMagnitude > groundMoveSpeed * groundMoveSpeed)
                rb.velocity = horizontalVelocity.normalized * groundMoveSpeed + Vector3.up * rb.velocity.y;

            if (rb.velocity.x != 0 || rb.velocity.z != 0)
            {
                anim.SetBool("Idle", false);
                anim.SetBool("Run", true);
                //anim.SetBool("Idle", false);
                //anim.SetTrigger("RunT");
            }

            else
            {
                anim.SetBool("Run", false);
                //anim.SetBool("Idle", true);
                anim.SetBool("Idle",true);
            }
        }
    }
    private void LookAt()
    {
        Vector3 direction = rb.velocity;
        direction.y = 0f;

        if (pih.leftStickInput.sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
            this.rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        else
            rb.angularVelocity = Vector3.zero;
    }
    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }
    public void StopPlayerVelocity()
    {
        rb.velocity = Vector3.zero;
        anim.SetBool("Run", false);
        anim.SetBool("Idle", true);
    }
}
