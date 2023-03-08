using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mouse3D : MonoBehaviour
{
    public static Mouse3D Instance { get; private set; }
    [SerializeField] private LayerMask mouseColliderLayerMask = new LayerMask();
    [SerializeField] private bool isMouseOnUI;
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        isMouseOnUI = IsClickUGUI();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, mouseColliderLayerMask))
        {
            transform.position = raycastHit.point;
        }
    }
    public static bool IsClickUGUI()
    {
        if (EventSystem.current)
        {
            return EventSystem.current.IsPointerOverGameObject();
        }
        return false;
    }
    public static Vector3 GetMouseWorldPosition() => Instance.GetMouseWorldPosition_Instance();
    private Vector3 GetMouseWorldPosition_Instance()
    {
        if (!isMouseOnUI)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, mouseColliderLayerMask))
            {
                return raycastHit.point;
            }
            else
            {
                return new Vector3(-1, -1, -1);
            }
        }
        else
        {
            return new Vector3(-1, -1, -1);
        }
    }
}
