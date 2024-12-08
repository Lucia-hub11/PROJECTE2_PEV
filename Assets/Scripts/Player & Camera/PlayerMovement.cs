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

    public Animator keyDoorAnimator;
    bool key_collected;


    public float WalkSpeed = 5;
    public float JumpSpeed = 5;
    public float AirControl = 0.1f;

    private Vector3 _lastVelocity;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _inputs = GetComponent<InputControllers>();
        _groundChecker = GetComponentInChildren<GroundChecker>();

        key_collected = false;
    }

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
        // Obtenir la direcció de moviment en funció de la càmera
        Vector3 camForward = _camera.forward;
        camForward.y = 0; // Ignorar inclinació vertical
        camForward.Normalize();

        Vector3 camRight = _camera.right;
        camRight.y = 0; // Ignorar inclinació vertical
        camRight.Normalize();

        Vector3 direction = camForward * _inputs.Move.y + camRight * _inputs.Move.x;

        // Normalitzar la direcció si hi ha input significatiu
        direction = direction.magnitude > 0.1f ? direction.normalized : Vector3.zero;

        Vector3 velocity = direction * WalkSpeed;

        velocity.y = _lastVelocity.y + Physics.gravity.y * Time.deltaTime;

        if (ShouldJump())
            Jump(ref velocity);

        _characterController.Move(velocity * Time.deltaTime);

        // Ajustar la direcció del personatge
        if (direction.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        _lastVelocity = velocity;
    }

    private float GetGravity()
    {
        return _lastVelocity.y + Physics.gravity.y * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "KeyDoorCollider")
        {
            key_collected = true;
            keyDoorAnimator.SetBool("Key Collected", key_collected);
        }
    }
}