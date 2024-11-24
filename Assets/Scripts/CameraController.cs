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

    private Vector2 _mouseDelta; // Delta del ratón
    private float _verticalRotation = 0f; // Rotación acumulativa vertical

    private void Start()
    {
        // Bloquear y esconder el cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        RotateCamera();
    }

    public void OnLook(InputValue input)
    {
        _mouseDelta = input.Get<Vector2>();
    }

    private void RotateCamera()
    {
        // Calcular rotación horizontal (eje Y) y aplicarla al jugador
        float horizontalRotation = _mouseDelta.x * Sensitivity * Time.deltaTime;
        Player.Rotate(Vector3.up * horizontalRotation);

        // Calcular rotación vertical (eje X) y limitarla
        _verticalRotation -= _mouseDelta.y * Sensitivity * Time.deltaTime;
        _verticalRotation = Mathf.Clamp(_verticalRotation, MinVerticalAngle, MaxVerticalAngle);

        // Aplicar la rotación vertical a la cámara
        transform.localRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);
    }
}
