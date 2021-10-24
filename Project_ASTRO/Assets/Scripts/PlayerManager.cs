using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    CameraManager cameraManager;
    PlayerLocomotion playerLocomotion;

    void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        cameraManager = GetComponent<CameraManager>();
    }

    void Update()
    {
        inputManager.HandleAllInput();
        cameraManager.HandleAllCameraMovement();
    }

    void FixedUpdate()
    {
        playerLocomotion.HandleAllMovement();
    }
}
