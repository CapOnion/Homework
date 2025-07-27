using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputControls : IDisposable
{
    private readonly PlayerControls _inputActions;
    public PlayerControls InputActions => _inputActions;

    public event Action<Vector2> MovementRecieved;
    public event Action MovementEnd;
    private IDisposable _eventListener;

    public InputControls()
    {
        _inputActions = new PlayerControls();
        _inputActions.Enable();
        _inputActions.Default.Movement.performed += OnMovementPerformed;
        _inputActions.Default.Movement.canceled += OnMovementEnd;
    }

    private void OnMovementPerformed(InputAction.CallbackContext callbackContext) => MovementRecieved?.Invoke(callbackContext.ReadValue<Vector2>());

    private void OnMovementEnd(InputAction.CallbackContext callbackContext) => MovementEnd?.Invoke();

    public void Dispose()
    {
        _inputActions.Default.Movement.performed -= OnMovementPerformed;
        _inputActions.Default.Movement.canceled -= OnMovementEnd;
    }
}
