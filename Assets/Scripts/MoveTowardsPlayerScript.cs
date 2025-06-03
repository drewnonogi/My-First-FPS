using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayerScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.2f;
    private Rigidbody rigidBody;
    [SerializeField] private Transform player;
    [SerializeField] private int playerLayerIndex = 6;
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        player = PlayerController.PlayerControllerInstance.transform;
    }

    void Update()
    {
        TryMoveTowardsPlayer();
    }
    private void TryMoveTowardsPlayer()
    {
        Vector3 directionToPlayer = player.position - transform.position;

        if (Physics.Raycast(transform.position, directionToPlayer.normalized, out RaycastHit hitInfo))
        {
            Debug.DrawRay(transform.position, directionToPlayer);

            if (hitInfo.collider.gameObject.layer == playerLayerIndex)
            {
                Vector3 direction = (player.position - transform.position).normalized;

                rigidBody.velocity = direction * moveSpeed;
            }
            else
            {
                rigidBody.velocity = Vector3.zero;
            }
        }

    }
}
