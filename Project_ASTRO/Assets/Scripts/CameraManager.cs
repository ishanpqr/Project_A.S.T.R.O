using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    InputManager inputManager;

    public Transform cam;
    public Transform orientation;

    public float sensX = 100f;
    public float sensY = 100f;
    public float sensMultiplier = 0.01f;

    public float xRot;
    public float yRot;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void HandleAllCameraMovement()
    {
        RotateCamera();
    }

    public void RotateCamera()
    {
        yRot += inputManager.cameraInputX * sensX * sensMultiplier;
        xRot -= inputManager.cameraInputY * sensY * sensMultiplier;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRot, yRot, 0);
        orientation.transform.rotation = Quaternion.Euler(0, yRot, 0);
    }

}
