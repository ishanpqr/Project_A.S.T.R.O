using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManager;
    Rigidbody playerRigidBody;

    public Transform orientation;

    Vector3 moveDirection;
    public float walkingSpeed = 1.5f;
    public float runningSpeed = 5;
    public float sprintingSpeed = 7;

    public bool isSprinting;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRigidBody = GetComponent<Rigidbody>();
    }

    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        moveDirection = orientation.forward * inputManager.verticalInput + orientation.right * inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;

        Vector3 movementVelocity;
        if (isSprinting)
        {
            movementVelocity = moveDirection * sprintingSpeed;
        }
        else
        {
            if(inputManager.moveAmount >= 0.5f)
            {
                movementVelocity = moveDirection * runningSpeed;
            }
            else
            {
                movementVelocity = moveDirection * walkingSpeed;
            }
        }

        playerRigidBody.AddForce(movementVelocity, ForceMode.Acceleration); 
    }

    private void HandleRotation()
    {
        transform.rotation = orientation.transform.rotation;
    }
}
