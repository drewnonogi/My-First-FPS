using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPathMovement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    private float speed = 10f;
    private int index = 0;

    void Update()
    {
        FollowPath();
    }
    private void FollowPath()
    {
        Transform waypointTransform = waypoints[index];
        transform.position = Vector3.MoveTowards(transform.position, waypointTransform.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypointTransform.position) < 0.1f)
        {
            //index = (index + 1) % waypoints.Length;

            index++;
            if (index >= waypoints.Length)
            {
                index = 0;
            }
        }

    }
}

