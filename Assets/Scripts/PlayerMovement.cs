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
        // Calcular la direcci?n de entrada (incluye movimiento lateral y hacia adelante/atr?s)
        var localInput = transform.right * _inputs.Move.x + transform.forward * _inputs.Move.y;
        Vector3 direction = new Vector3(localInput.x, 0, localInput.z);

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

        // Guardar la ?ltima velocidad para la f?sica
        _lastVelocity = velocity;
    }

    private float GetGravity()
    {
        return _lastVelocity.y + Physics.gravity.y * Time.deltaTime;
    }
}
