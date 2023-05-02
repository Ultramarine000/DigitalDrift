using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class InputCameraController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private Vector2 LookCamera; // your LookDelta
    public float deadZoneX = 0.2f;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();

        playerInputActions._3DPlayer.Sight.performed += ctx => LookCamera = ctx.ReadValue<Vector2>().normalized;
        playerInputActions._3DPlayer.Sight.performed += ctx => GetInput();
    }

    private void GetInput()
    {
        CinemachineCore.GetInputAxis = GetAxisCustom;
    }

    public float GetAxisCustom(string axisName)
    {
        // LookCamera.Normalize();

        if (axisName == "Mouse X")
        {
            if (LookCamera.x > deadZoneX || LookCamera.x < -deadZoneX) // To stabilise Cam and prevent it from rotating when LookCamera.x value is between deadZoneX and - deadZoneX
            {
                return LookCamera.x;
            }
        }

        else if (axisName == "Mouse X")
        {
            return LookCamera.y;
        }

        return 0;
    }

    private void OnEnable()
    {
        playerInputActions._3DPlayer.Enable();
    }

    private void OnDisable()
    {
        playerInputActions._3DPlayer.Disable();
    }
}