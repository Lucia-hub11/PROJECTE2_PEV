using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform Player; // Referencia al transform del jugador
    public float Sensitivity = 100f; // Sensibilidad del ratón
    public float MaxVerticalAngle = 80f; // Límite superior de inclinación
    public float MinVerticalAngle = -80f; // Límite inferior de inclinación

    private float _verticalRotation = 0f; // Rotación acumulativa vertical

    InputControllers _inputs;

    private void Start()
    {
        _inputs = GetComponentInParent<InputControllers>();
        // Bloquear y esconder el cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        // Rotar horizontalmente al jugador con el mouse
        float horizontalRotation = _inputs.Look.x * Sensitivity * Time.deltaTime;
        Player.Rotate(Vector3.up * horizontalRotation); // La cámara no rota independiente del jugador

        // Rotación vertical (solo afecta la cámara, no el jugador)
        _verticalRotation -= _inputs.Look.y * Sensitivity * Time.deltaTime;
        _verticalRotation = Mathf.Clamp(_verticalRotation, MinVerticalAngle, MaxVerticalAngle);

        // Aplicar la rotación vertical a la cámara
        transform.localRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);
    }

}
