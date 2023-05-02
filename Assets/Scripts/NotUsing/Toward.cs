using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;
public class Toward : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 inputVector = Vector2.zero;
    void Start()
    {

    }
    public void SetInputVector(Vector2 direction)
    {
        inputVector = direction;
    }

    // Update is called once per frame
    void Update()
    {
        //if (inputVector.magnitude > 0.1f)
            //transform.DOLookAt(new Vector3(inputVector.x, 0, inputVector.y) + transform.position, 0.2f);

    }
}
