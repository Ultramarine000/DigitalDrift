using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    private GameObject selectObj;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))//left click
        {
            //pick a new obj
            if(selectObj == null)
            {
                RaycastHit hit = CastRay();
                if(hit.collider != null)
                {
                    if (!hit.collider.CompareTag("drag"))
                    {
                        return;
                    }
                    selectObj = hit.collider.gameObject;
                    Cursor.visible = false;
                }
            }
            else
            {
                Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(Camera.main.transform.position).z);
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(pos);
                selectObj.transform.position = new Vector3(worldPos.x, 0, worldPos.z);

                selectObj = null;
                Cursor.visible = true;
            }
        }
        if(selectObj != null)
        {
            Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y,Camera.main.WorldToScreenPoint(Camera.main.transform.position).z);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(pos);
            selectObj.transform.position = new Vector3(worldPos.x, 0.25f, worldPos.z);

            if(Input.GetMouseButtonDown(1))
            {
                selectObj.transform.rotation = Quaternion.Euler(new Vector3(
                    selectObj.transform.rotation.x, 
                    selectObj.transform.rotation.y + 90, 
                    selectObj.transform.rotation.z));
            }
        }
    }
    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 worldMousePostionFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePostionNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePostionNear, worldMousePostionFar-worldMousePostionNear, out hit);

        return hit;
    }
}
