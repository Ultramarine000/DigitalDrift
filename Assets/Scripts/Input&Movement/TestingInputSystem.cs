using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    private PlayerInput playerInput;
    PlayerInputActions playerInputActions;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        playerInputActions = new PlayerInputActions();
        playerInputActions._3DPlayer.Enable();
        playerInputActions._3DPlayer.Select.performed += Jump;
        //playerInputActions._3DPlayer.Movement.performed += Movement_performed;
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = playerInputActions._3DPlayer.Movement.ReadValue<Vector2>();
        float speed = 5f;
        rb.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);
    }
    //private void Movement_performed(InputAction.CallbackContext context)
    //{
    //    Debug.Log(context);
    //    Vector2 inputVector = context.ReadValue<Vector2>();
    //    float speed = 5f;
    //    rb.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);
    //}

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log("Jump" + context.phase);
            rb.AddForce(Vector3.up * 2f, ForceMode.Impulse);
        }
    }
}
