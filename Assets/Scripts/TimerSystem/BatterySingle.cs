using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatterySingle : MonoBehaviour
{
    public Image batteryGreen;
    public Image batteryOrange;
    public Image batteryRed;
    public Image frame;
    public Image emptyFrame;

    [SerializeField] private float originalSize;

    [SerializeField] private Vector3 originalPos;
    [SerializeField] private int slotNum = 5;


    void Start()
    {
        originalSize = batteryGreen.gameObject.GetComponent<RectTransform>().rect.width;
        originalPos = GetComponent<RectTransform>().anchoredPosition3D;
    }


    public void FillChange(int snNew)
    {
        slotNum = snNew;
        float x = 0;
        x += originalSize * slotNum / 5;
        //Debug.Log(x);
        //Debug.Log(slotNum);
        x -= originalSize;
        if (slotNum == 0)
        {
            batteryRed.enabled = false;
            batteryGreen.enabled = false;
            batteryOrange.enabled = false;
            frame.enabled = false;
            emptyFrame.enabled = true;
        }
        else if (slotNum == 1)
        {
            batteryRed.enabled = true;
            batteryGreen.enabled = false;
            batteryOrange.enabled = false;
            frame.enabled = true;
            emptyFrame.enabled = false;
        }
        else if (slotNum == 2 || slotNum == 3)
        {
            batteryRed.enabled = false;
            batteryGreen.enabled = false;
            batteryOrange.enabled = true;
            frame.enabled = true;
            emptyFrame.enabled = false;
        }
        else if (slotNum == 4 || slotNum == 5)
        {
            batteryRed.enabled = false;
            batteryGreen.enabled = true;
            batteryOrange.enabled = false;
            frame.enabled = true;
            emptyFrame.enabled = false;
        }
        gameObject.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(x, originalPos.y, originalPos.z);
    }
}

