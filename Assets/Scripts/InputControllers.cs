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


    private void OnMove(InputValue input)
    {
        _move = input.Get<Vector2>();
    }

    private void OnJump()
    {
        _jump = true;
    }

    private void LateUpdate()
    {
        _jump = false;
    }

    private Vector2 _look;
    public Vector2 Look => _look;

    private void OnLook(InputValue input)
    {
        _look = input.Get<Vector2>();
    }
}
