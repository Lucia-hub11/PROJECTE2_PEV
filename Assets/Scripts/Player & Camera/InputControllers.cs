using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputControllers : MonoBehaviour
{
    private Vector2 _move;
    public Vector2 Move => _move;

    private bool _jump;
    public bool Jump => _jump;

    private bool _shoot;
    public bool Shoot => _shoot;

    private bool _interact;
    public bool Interact => _interact;

    private void OnMove(InputValue input)
    {
        _move = input.Get<Vector2>();
    }

    private void OnJump()
    {
        _jump = true;
    }

    private void OnShoot()
    {
        _shoot = true;
    }

    private void OnInteract()
    {
        _interact = true;
    }

    private void LateUpdate()
    {
        _jump = false;
        _shoot = false;
        if (_interact)
        {
            _interact = false;
        }
    }

    private Vector2 _look;
    public Vector2 Look => _look;

    private void OnLook(InputValue input)
    {
        _look = input.Get<Vector2>();
    }
}
