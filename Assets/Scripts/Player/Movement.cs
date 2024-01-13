using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    [SerializeField] private float playerMovementSpeed;
    [SerializeField] private Rigidbody playerRigidBody;
    [FormerlySerializedAs("sprintSpeed")] [SerializeField] private float playerSprintSpeed;
    [SerializeField] private float sprintDuration;

    private bool isSprinting = false;

    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); 
        float verticalInput = Input.GetAxis("Vertical");
        
        playerRigidBody.velocity = new Vector3(horizontalInput * playerMovementSpeed,
            playerRigidBody.velocity.y, verticalInput * playerMovementSpeed);
    }

    private void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isSprinting)
        {
            StartCoroutine(SprintCoroutine());
        }
    }

    private IEnumerator SprintCoroutine()
    {
        isSprinting = true;
        
        float horizontalInput = Input.GetAxis("Horizontal"); 
        float verticalInput = Input.GetAxis("Vertical");
        
        playerRigidBody.velocity = new Vector3(horizontalInput * playerSprintSpeed, playerRigidBody.velocity.y,
            verticalInput * playerSprintSpeed);

        yield return new WaitForSeconds(sprintDuration);

        isSprinting = false;
    }
    
    void Update()
    {
        PlayerMovement();
        Sprint();
    }
}
