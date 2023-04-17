using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover2D : MonoBehaviour
{
    //[SerializeField] private GameController gameController;

    [Header("Speed")]
    public float groundMoveSpeed = 7f;
    private float movementForce = 1f;

    //public Rigidbody rb;

    private Vector3 moveDirection = Vector3.zero;
    //private Vector2 inputVector = Vector2.zero;
    private PlayerInputHandler pih;

    [Header("environment check")]
    public float footOffset = 0.4f;
    public float floatingSpeed = 200;
    public LayerMask groundLayer;
    [SerializeField]
    public bool isOnGround = false;
    //[SerializeField]
    //public Animator anim;

    [SerializeField]
    public GameObject renderSurfaceDown;
    public GameObject stateRelease;
    public GameObject stateGrab;
    private GridBuildingSystem gridBuildingSys;
    //public Camera playerCamera;
    private Animator animator;

    private void Awake()
    {
        //rb = GetComponent<Rigidbody>();
        pih = GetComponent<PlayerInputHandler>();
        //gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        renderSurfaceDown = GameObject.Find("2DRenderSurfaceDown");
        gridBuildingSys = GameObject.Find("GridBuildingSystem").GetComponent<GridBuildingSystem>();
        gridBuildingSys.player2D = gameObject;
        //playerCamera = GameObject.Find("Camera3D").GetComponent<Camera>();
        //animator = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        PhysicsCheck();
        OnMove();
        //renderSurfaceDown.SetActive(!pih.rightShoulderBtn);
        OnControll();
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
            //rb.velocity = new Vector3(pih.leftStickInput.x * groundMoveSpeed, pih.leftStickInput.y * groundMoveSpeed, rb.velocity.z);
            
            gameObject.transform.position += new Vector3(pih.leftStickInput.x * groundMoveSpeed * 0.01f, pih.leftStickInput.y * groundMoveSpeed * 0.01f, 0);

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
    void OnControll()
    {
        if (pih.rightStickInput.y > 0.7f )
        {
            renderSurfaceDown.SetActive(false);
        }
        if(pih.rightStickInput.y < -0.7f)
        {
            renderSurfaceDown.SetActive(true);
        }
    }
    public void BuildBlocks()
    {
        gridBuildingSys.BuildBlocks(gameObject.transform.position);
    }
    public void RemoveBlocks()
    {
        gridBuildingSys.RemoveBlocks(gameObject.transform.position);
    }
    public void RotateBlocks()
    {
        gridBuildingSys.RotateBlocks();
    }
    public void CurrentSelectIndexChange(int n)
    {
        gridBuildingSys.CurrentSelectChange(n);
    }
}
