using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed = 20f;
    public GameObject[] wayPoint;
    [SerializeField]int nextPointIndex;
    void Start()
    {
        //wayPoint = GameObject.FindGameObjectsWithTag("WayPoint1_Blue");
        ////sorting
        //Array.Sort(wayPoint, (x, y) => { return x.gameObject.name.CompareTo(y.gameObject.name); });
        //Initial position
        //transform.position = wayPoint[0].transform.position;
        ////Initial angle
        //transform.forward = wayPoint[nextPointIndex].transform.position - transform.position;

    }

    void Update()
    {
        //distance to next way point
        if (Vector3.Distance(wayPoint[nextPointIndex].transform.position, transform.position) < 0.2f)
        {
            // if the next way point is not the last then +1
            if (nextPointIndex != wayPoint.Length - 1)
            {
                nextPointIndex++;
            }
            //reach the last position, position fixed to avoid shaking
            if (Vector3.Distance(wayPoint[wayPoint.Length - 1].transform.position, transform.position) < 0.2f)
            {
                //transform.position = wayPoint[wayPoint.Length - 1].transform.position;
                nextPointIndex = 0;
                //return;
            }
            //Set the steering for each point
            transform.forward = wayPoint[nextPointIndex].transform.position - transform.position;
        }
        //go forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }
}
