using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public float Sensitivity = 30f;
    public float MaxVerticalAngle = 40f;
    public float MinVerticalAngle = -20f;

    private float _verticalRotation = 0f; // Rotació acumulativa vertical
    public InputControllers _inputs;

    private Transform _cameraHolder;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _cameraHolder = transform.parent;
    }

    private void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        if (_inputs == null || _cameraHolder == null) return;

        // Rotació vertical (aplicada al holder per girar la càmara al voltant del jugador)
        _verticalRotation -= _inputs.Look.y * Sensitivity * Time.deltaTime;
        _verticalRotation = Mathf.Clamp(_verticalRotation, MinVerticalAngle, MaxVerticalAngle);
        _cameraHolder.localRotation = Quaternion.Euler(_verticalRotation, _cameraHolder.localRotation.eulerAngles.y, 0f);

        // Rotació horitzontal (gira el holder en l'eix Y)
        _cameraHolder.Rotate(Vector3.up * _inputs.Look.x * Sensitivity * Time.deltaTime, Space.World);
    }
}
