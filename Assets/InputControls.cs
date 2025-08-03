using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputControls : IDisposable
{
    private readonly PlayerControls _inputActions;
    public PlayerControls InputActions => _inputActions;

    public event Action<Vector2> MovementXRecieved;
    public event Action MovementXEnd;

    public event Action<Vector2> MovementYRecieved;
    public event Action MovementYEnd;
    private IDisposable _eventListener;

    public InputControls()
    {
        _inputActions = new PlayerControls();
        _inputActions.Enable();
        _inputActions.Default.Movement_x.performed += OnMovementXPerformed;
        _inputActions.Default.Movement_x.canceled += OnMovementXEnd;

        _inputActions.Default.Movement_y.performed += OnMovementYPerformed;
        _inputActions.Default.Movement_y.canceled += OnMovementYEnd;
    }

    private void OnMovementXPerformed(InputAction.CallbackContext callbackContext) => MovementXRecieved?.Invoke(callbackContext.ReadValue<Vector2>());

    private void OnMovementXEnd(InputAction.CallbackContext callbackContext) => MovementXEnd?.Invoke();

    private void OnMovementYPerformed(InputAction.CallbackContext callbackContext) => MovementYRecieved?.Invoke(callbackContext.ReadValue<Vector2>());

    private void OnMovementYEnd(InputAction.CallbackContext callbackContext) => MovementYEnd?.Invoke();

    public void Dispose()
    {
        _inputActions.Default.Movement_x.performed -= OnMovementXPerformed;
        _inputActions.Default.Movement_x.canceled -= OnMovementXEnd;

        _inputActions.Default.Movement_y.performed -= OnMovementYPerformed;
        _inputActions.Default.Movement_y.canceled -= OnMovementYEnd;
    }
}
