using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPad : MonoBehaviour
{
    [SerializeField] private float jumpForce = 20f; 
    [SerializeField] private Vector3 jumpDirection = Vector3.up; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.LaunchPlayer(jumpDirection.normalized * jumpForce);
            }
        }
    }
}
