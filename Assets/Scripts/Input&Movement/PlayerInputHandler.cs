using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;
using Cinemachine;
//using static UnityEditor.Searcher.SearcherWindow.Alignment;
//using DG.Tweening;


public class PlayerInputHandler : MonoBehaviour
{
    private PlayerConfiguration playerConfig;
    private Mover3D mover3D;
    private Mover2D mover2D;
    //private Toward toward;
    public List<GameObject> Models;
    //public Vector3 processiveForce = Vector3.zero;
    public Vector3 sightDir = Vector3.zero;
    public Vector2 leftStickInput = Vector2.zero;
    public Vector2 rightStickInput = Vector2.zero;
    public bool rightShoulderBtn = false;
    public int bounceForce;
    public float jumpForce = 1.8f;
    [SerializeField]
    private bool isDead = false;

    [SerializeField]
    private GameObject PlayerModel;
    //[SerializeField]
    //private MeshRenderer playerMesh;//»»ÑÕÉ«ÓÃ  

    public LayerMask player3Dlayer;
    public LayerMask player2Dlayer;
    

    public PlayerInputActions playerInputActions;
    private void Awake()
    {
        mover3D = GetComponent<Mover3D>();
        mover2D = GetComponent<Mover2D>();
        playerInputActions = new PlayerInputActions();

        //playerInputActions._3DPlayer.Ybtn.performed += PressY;
        //Debug.Log(gameObject.layer);
        //if (gameObject.layer == 8)
        //{
        //    playerInputActions._3DPlayer.Enable();
        //    Debug.Log("3D Enable");
        //}
        //else if (gameObject.layer == 9)
        //{
        //    playerInputActions._2DPlayer.Enable();
        //    Debug.Log("2D Enable");
        //}
    }


    public void InitializePlayer(PlayerConfiguration pc)
    {
        playerConfig = pc;
        //mover3D.anim = Models[pc.modeIndex].GetComponent<Animator>();
        //Models[pc.modeIndex].SetActive(true);

        //mover3D = Models[pc.modeIndex].GetComponent<Mover3D>();
        playerConfig.Input.onActionTriggered += Input_onActionTriggered;
    }

    private void Input_onActionTriggered(CallbackContext obj)
    {
        //not game pausing can move3D, move2DSight, openMenu
        if (!GameController.GetInstance().isPausing) 
        {
            if (obj.action.name == playerInputActions._3DPlayer.Movement.name)
            {
                On3DMove(obj);
                //Debug.Log("trigger3D");
            }
            if (obj.action.name == playerInputActions._3DPlayer.Sight.name)
            {
                On2DSightChange(obj);
                //Debug.Log("trigger3D");
            }
            if (obj.action.name == playerInputActions._3DPlayer.MenuBtn.name)
            {
                GameController.GetInstance().ShowContinuePanel();
            }

            if (obj.performed) //when 2D & 3D using same Btn inputs
            {
                if (obj.action.name == playerInputActions._3DPlayer.Ybtn.name)//Jump for 3D and rotated for 2D
                {
                    if (mover3D != null && mover3D.isOnGround)
                    {
                        mover3D.rb.velocity += new Vector3(0, jumpForce, 0);
                        mover3D.anim.SetBool("Idle", false);
                        //mover3D.anim.SetBool("Run", false);
                        //mover3D.anim.SetBool("Jump", true);
                        mover3D.anim.SetTrigger("JumpT");
                    }
                    else if (mover2D != null)
                        mover2D.RotateBlocks();
                }

                if (obj.action.name == playerInputActions._3DPlayer.Xbtn.name)//set 2D
                {
                    mover2D.BuildBlocks();
                }
                if (obj.action.name == playerInputActions._3DPlayer.Bbtn.name)//remove 2D
                {
                    mover2D.RemoveBlocks();
                }
                if (obj.action.name == playerInputActions._3DPlayer.RightShoulder.name)
                {
                    if (mover2D != null)
                    {
                        mover2D.CurrentSelectIndexChange(1);
                    }
                }
                if (obj.action.name == playerInputActions._3DPlayer.LeftShoulder.name)
                {
                    if (mover2D != null)
                    {
                        mover2D.CurrentSelectIndexChange(-1);
                    }
                }
                if (obj.action.name == playerInputActions._3DPlayer.Select.name)//2D press A South Btn
                {
                    if (mover2D != null)
                    {
                        mover2D.ContinueStory();
                    }
                }
                if (obj.action.name == playerInputActions._3DPlayer.Skip.name)
                {
                    if(VideoPanelCtrl.GetInstance() != null)
                        VideoPanelCtrl.GetInstance().PressStopKey();
                }
            }
        }
        
        
        
    }
    public void PressY(InputAction.CallbackContext context)
    {
        Debug.Log("in");
        if (context.performed)
        {
            Debug.Log("pressY" + context.phase);
        }
    }

    public void On3DMove(CallbackContext context)
    {
        //if (mover3D != null)

        {
            //mover3D.SetInputVector(context.ReadValue<Vector2>());
            //processiveForce = new Vector3(context.ReadValue<Vector2>().x, 0, context.ReadValue<Vector2>().y);
            leftStickInput = new Vector2(context.ReadValue<Vector2>().x, context.ReadValue<Vector2>().y);
            //toward.SetInputVector(context.ReadValue<Vector2>());
        }
    }
    public void On2DSightChange(CallbackContext context)
    {
        rightStickInput = new Vector2(context.ReadValue<Vector2>().x, context.ReadValue<Vector2>().y);
    }


    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")//Rebound
    //    {
    //        Vector3 bounceDir = (this.transform.position - other.gameObject.transform.position).normalized;
    //        Vector3 bounceDirOther = -bounceDir;
    //        bounceDir = bounceDir * bounceForce;
    //        bounceDir.y = 0;
    //        this.transform.DOMove(this.transform.position + bounceDir, 0.3f).SetEase(Ease.OutSine);

    //        bounceDirOther = bounceDirOther * bounceForce;
    //        bounceDirOther.y = 0;
    //        other.gameObject.transform.DOMove(other.transform.position + bounceDirOther, 0.3f).SetEase(Ease.OutQuad);
    //    }
    //    if (other.gameObject.tag == "Bomb")
    //    {
    //        Debug.Log("hitbomb");
    //        isDead = true;
    //        Destroy(gameObject);
    //    }
    //}
}