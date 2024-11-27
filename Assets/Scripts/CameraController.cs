using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public float Sensitivity = 30f; // Sensibilidad del ratón
    public float MaxVerticalAngle = 15f; // Límite superior de inclinación
    public float MinVerticalAngle = -30f; // Límite inferior de inclinación

    private float _verticalRotation = 0f; // Rotación acumulativa vertical
    public InputControllers _inputs;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        if (_inputs == null) return; // Asegurar que _inputs no sea nulo

        // Rotación vertical (solo afecta la cámara)
        _verticalRotation -= _inputs.Look.y * Sensitivity * Time.deltaTime;
        _verticalRotation = Mathf.Clamp(_verticalRotation, MinVerticalAngle, MaxVerticalAngle);
        transform.localRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);

        // La rotación horizontal puede afectar directamente al holder (sin mover al jugador)
        transform.parent.Rotate(Vector3.up * _inputs.Look.x * Sensitivity * Time.deltaTime);
    }
}