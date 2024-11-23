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
    public float JumpSpeed = 10;
    public float AirControl = 0.1f;
    public float TurnSpeed = 1;

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
        var localInput = transform.right * _inputs.Move.x + transform.forward * _inputs.Move.y;
        Vector3 direction = new Vector3(localInput.x, 0, localInput.z); //A y D giren el personatge

        Vector3 velocity = new Vector3();

        float smoothFactor = _groundChecker.Grounded ? 1 : AirControl * Time.deltaTime;

        //float currentSpeed = _inputs.RunStart ? RunSpeed : WalkSpeed;


        //velocity.x = Mathf.Lerp(_lastVelocity.x, direction.x * currentSpeed, smoothFactor);
        //velocity.y = _lastVelocity.y;
        //velocity.z = Mathf.Lerp(_lastVelocity.z, direction.z * currentSpeed, smoothFactor);

        velocity.y = GetGravity();
        if (ShouldJump())
            Jump(ref velocity);


        _characterController.Move(velocity * Time.deltaTime);


        if (direction.magnitude > 0)
        {
            Vector3 target = transform.position + direction;

            Quaternion targetRotation = Quaternion.LookRotation(target - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, TurnSpeed * Time.deltaTime);
        }
        _lastVelocity = velocity;
    }

    private float GetGravity()
    {
        return _lastVelocity.y + Physics.gravity.y * Time.deltaTime;
    }
}
