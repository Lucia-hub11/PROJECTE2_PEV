using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public float Sensitivity = 30f; // Sensibilidad del ratón
    public float MaxVerticalAngle = 40f; // Límite superior de inclinación
    public float MinVerticalAngle = -20f; // Límite inferior de inclinación

    private float _verticalRotation = 0f; // Rotación acumulativa vertical
    public InputControllers _inputs; // Entrada personalizada

    private Transform _cameraHolder; // Referencia al objeto padre de la cámara

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Asignar el objeto padre (holder) que rotará la cámara
        _cameraHolder = transform.parent;
    }

    private void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        if (_inputs == null || _cameraHolder == null) return;

        // Rotación vertical (aplicada al holder para girar la cámara alrededor del jugador)
        _verticalRotation -= _inputs.Look.y * Sensitivity * Time.deltaTime;
        _verticalRotation = Mathf.Clamp(_verticalRotation, MinVerticalAngle, MaxVerticalAngle);
        _cameraHolder.localRotation = Quaternion.Euler(_verticalRotation, _cameraHolder.localRotation.eulerAngles.y, 0f);

        // Rotación horizontal (gira el holder en el eje Y)
        _cameraHolder.Rotate(Vector3.up * _inputs.Look.x * Sensitivity * Time.deltaTime, Space.World);
    }
}
