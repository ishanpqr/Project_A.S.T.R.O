using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    PlayerControls playerControls;
    AnimatorManager animatorManager;
    PlayerLocomotion playerLocomotion;

    public float moveAmount;

    public Vector2 cameraInput;
    public float cameraInputX;
    public float cameraInputY;

    public Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;

    public bool shiftInput;

    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            //Shift button
            playerControls.PlayerActions.Sprint.performed += i => shiftInput = true;
            playerControls.PlayerActions.Sprint.canceled += i => shiftInput = false;
        }

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInput()
    {
        HandleMovementInput();
        HandleSprintingInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        cameraInputY = cameraInput.y;
        cameraInputX = cameraInput.x;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount,playerLocomotion.isSprinting);
    }

    private void HandleSprintingInput()
    {
        if(shiftInput && moveAmount >= 0.5f)
        {
            playerLocomotion.isSprinting = true;
        }
        else
        {
            playerLocomotion.isSprinting = false;
        }
    }
}
