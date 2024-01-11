using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float playerMovementSpeed;
    [SerializeField] private Rigidbody playerRigidBody;
    
    private void PlayerMovement()
    { 
        float horizontalInput = Input.GetAxis("Horizontal"); 
        float verticalInput = Input.GetAxis("Vertical");

        playerRigidBody.velocity = new Vector3(horizontalInput * playerMovementSpeed,
            playerRigidBody.velocity.y, playerRigidBody.velocity.z);
        playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, playerRigidBody.velocity.y,
            verticalInput * playerMovementSpeed);
    }
    
    void Update()
    {
        PlayerMovement();
    }
}
