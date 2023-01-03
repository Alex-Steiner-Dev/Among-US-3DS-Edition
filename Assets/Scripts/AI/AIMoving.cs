using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMoving : MonoBehaviour {
    [SerializeField] private Transform[] wayPointList;
    [SerializeField] private float speed = 3f;

    public int currentWayPoint = 0;
    Transform targetWayPoint;

    void Update()
    {
        if (currentWayPoint < this.wayPointList.Length)
        {
            if (targetWayPoint == null)
                targetWayPoint = wayPointList[currentWayPoint];
            Walk();
        }
        else
        {
            currentWayPoint = 0;
            targetWayPoint = null;
        }
    }

    void Walk()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);

        if(currentWayPoint == 3)
        {
            speed = 2.5f;
        }

        if (transform.position == targetWayPoint.position)
        {
            currentWayPoint++;
            targetWayPoint = wayPointList[currentWayPoint];
        }
    }
}