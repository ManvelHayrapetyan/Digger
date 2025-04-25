using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _walkSpeed = 0.2f;
    [SerializeField] private float _runSpeedMultiplayer = 1.5f;
    [SerializeField] private float _rotationSpeed = 10f;

    private bool _isRunning = false;
    private Vector2 _moveInput;
    private float _currentSpeed;
    private Vector3 _moveDirection;
    private Quaternion _targetRotation;

    private CharacterController _chController;

    private void Awake()
    {
        _chController = GetComponent<CharacterController>();
        PlayerInput _playerInput = new();
        _playerInput.Player.Enable();
        _playerInput.Player.Move.performed += ctx => _moveInput = ctx.ReadValue<Vector2>();
        _playerInput.Player.Move.canceled += ctx => _moveInput = Vector2.zero;
        _playerInput.Player.Run.performed += ctx => _isRunning = true;
        _playerInput.Player.Run.canceled += word => _isRunning = false;


    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    public float GetCurrentSpeed()
    {
        return _currentSpeed;
    }

    public bool IsRunning()
    {
        return _isRunning;
    }

    private void MovePlayer()
    {
        if (_moveInput.magnitude > 0.1f)
        {
            _currentSpeed = _isRunning ? _walkSpeed * _runSpeedMultiplayer : _walkSpeed;
            _moveDirection = new Vector3(_moveInput.x, 0, _moveInput.y);
            _chController.Move(_moveDirection * _currentSpeed);
            _targetRotation = Quaternion.LookRotation(_moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, _rotationSpeed);
        }
        else
        {
            _currentSpeed = 0;
        }
    }
}
