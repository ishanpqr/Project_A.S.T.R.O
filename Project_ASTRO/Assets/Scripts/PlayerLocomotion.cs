using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManager;
    Rigidbody playerRigidBody;

    public Transform orientation;

    Vector3 moveDirection;
    public float movementSpeed = 7;

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
        Vector3 movementVelocity = moveDirection * movementSpeed; ;

        playerRigidBody.AddForce(movementVelocity, ForceMode.Acceleration); 
    }

    private void HandleRotation()
    {
        transform.rotation = orientation.transform.rotation;
    }
}
