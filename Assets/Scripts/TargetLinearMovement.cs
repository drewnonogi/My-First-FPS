using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLinearMovement : MonoBehaviour
{

    private float speed = 10f;
    private float distance = 7f;
    private float startingPositionX;
    private float startingPositionY;
    private float startingPositionZ;

    private void Start()
    {
        startingPositionX = transform.position.x;
        startingPositionY = transform.position.y;
        startingPositionZ = transform.position.z;
    }
    void Update()
    {

        float movement = Mathf.PingPong(speed * Time.time, distance);
        transform.position = new Vector3(movement + startingPositionX, startingPositionY, startingPositionZ);

    }
}
