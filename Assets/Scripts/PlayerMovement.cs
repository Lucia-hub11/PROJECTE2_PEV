using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    CharacterController _characterController;
    InputControllers _inputs;
    GroundChecker _groundChecker;

    public Transform _camera;

    public float WalkSpeed = 5;
    public float JumpSpeed = 5;
    public float AirControl = 0.1f;

    private Vector3 _lastVelocity;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _inputs = GetComponent<InputControllers>();
        _groundChecker = GetComponentInChildren<GroundChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Jump(ref Vector3 velocity)
    {
        velocity.y = JumpSpeed;
    }

    private bool ShouldJump()
    {
        return _inputs.Jump && _groundChecker.Grounded;
    }

    private void Move()
    {
        // Obtener la dirección de movimiento en función de la cámara
        Vector3 camForward = _camera.forward;
        camForward.y = 0; // Ignorar inclinación vertical
        camForward.Normalize();

        Vector3 camRight = _camera.right;
        camRight.y = 0; // Ignorar inclinación vertical
        camRight.Normalize();

        // Calcular la dirección del movimiento basado en la entrada del jugador
        Vector3 direction = camForward * _inputs.Move.y + camRight * _inputs.Move.x;

        // Normalizar la dirección si hay input significativo
        direction = direction.magnitude > 0.1f ? direction.normalized : Vector3.zero;

        // Calcular la velocidad
        Vector3 velocity = direction * WalkSpeed;

        // Aplicar gravedad
        velocity.y = _lastVelocity.y + Physics.gravity.y * Time.deltaTime;

        // Aplicar salto si corresponde
        if (ShouldJump())
            Jump(ref velocity);

        // Mover al personaje usando el CharacterController
        _characterController.Move(velocity * Time.deltaTime);

        // Guardar la última velocidad para la física
        _lastVelocity = velocity;
    }




    private float GetGravity()
    {
        return _lastVelocity.y + Physics.gravity.y * Time.deltaTime;
    }
}