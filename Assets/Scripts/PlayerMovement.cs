using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    CharacterController _characterController;
    InputControllers _inputs;
    GroundChecker _groundChecker;

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
        // Calcular la dirección de entrada (incluye movimiento lateral y hacia adelante/atrás)
        var localInput = new Vector3(_inputs.Move.x, 0, _inputs.Move.y); // Entrada de movimiento en el espacio local
        Vector3 direction = localInput.normalized; // Normalizar para obtener la dirección sin magnitud extra

        Vector3 velocity = new Vector3();

        // Control en el aire o en tierra
        float smoothFactor = _groundChecker.Grounded ? 1 : AirControl * Time.deltaTime;

        // Aplicar velocidad horizontal (sin giro)
        velocity.x = Mathf.Lerp(_lastVelocity.x, direction.x * WalkSpeed, smoothFactor);
        velocity.z = Mathf.Lerp(_lastVelocity.z, direction.z * WalkSpeed, smoothFactor);

        // Aplicar gravedad
        velocity.y = GetGravity();

        // Aplicar salto si corresponde
        if (ShouldJump())
            Jump(ref velocity);

        // Mover al personaje usando el CharacterController
        _characterController.Move(velocity * Time.deltaTime);

        // Ajustar la dirección del personaje para que mire hacia donde se mueve
        if (direction.magnitude > 0.1f) // Evitar rotación si no hay input de movimiento
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        // Guardar la última velocidad para la física
        _lastVelocity = velocity;
    }



    private float GetGravity()
    {
        return _lastVelocity.y + Physics.gravity.y * Time.deltaTime;
    }
}