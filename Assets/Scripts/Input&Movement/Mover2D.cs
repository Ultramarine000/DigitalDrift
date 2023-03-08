using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover2D : MonoBehaviour
{
    [Header("速度")]
    public float groundMoveSpeed = 7f;
    private float movementForce = 1f;

    public Rigidbody rb;

    private Vector3 moveDirection = Vector3.zero;
    //private Vector2 inputVector = Vector2.zero;
    private PlayerInputHandler pih;

    [Header("环境检测")]
    public float footOffset = 0.4f;
    public float floatingSpeed = 200;
    public LayerMask groundLayer;
    [SerializeField]
    public bool isOnGround = false;
    //[SerializeField]
    //public Animator anim;

    [SerializeField]
    //public Camera playerCamera;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pih = GetComponent<PlayerInputHandler>();
        //playerCamera = GameObject.Find("Camera3D").GetComponent<Camera>();
        //animator = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        PhysicsCheck();
        OnMove();
    }
    void PhysicsCheck()
    {
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
        //if (isOnGround)
        {
            rb.velocity = new Vector3(pih.leftStickInput.x * groundMoveSpeed, pih.leftStickInput.y * groundMoveSpeed, rb.velocity.z);
            
            
            //moveDirection += new Vector3(pih.leftStickInput.x, pih.leftStickInput.y) * movementForce;

            //rb.AddForce(moveDirection, ForceMode.Impulse);
            //moveDirection = Vector3.zero;

            ////if (rb.velocity.y < 0f)
            ////    rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;

            //Vector3 horizontalVelocity = rb.velocity;
            //horizontalVelocity.z = 0;
            //if (horizontalVelocity.sqrMagnitude > groundMoveSpeed * groundMoveSpeed)
            //    rb.velocity = horizontalVelocity.normalized * groundMoveSpeed;



            //if(rb.velocity.x != 0||rb.velocity.z!=0) anim.SetTrigger("Run");
            //else anim.ResetTrigger("Run");
        }

        //    if (rb.velocity.x != 0 || rb.velocity.z != 0)
        //    {
        //        anim.SetBool("Idle", false);
        //        anim.SetTrigger("Run");
        //    }
        //    else
        //    {
        //        //Debug.Log("Idle");
        //        anim.SetBool("Idle", true);
        //    }

    }
}
