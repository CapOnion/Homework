using Dreamteck.Forever;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputControls _inputController;
    [SerializeField] private Runner _basicRunner;
    [SerializeField] private float _slideSpeed = 5f;
    [SerializeField] private int _levelWidth = 5;

    private Vector2 _targetVector;
    private void Awake()
    {
        _inputController = new();
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        _inputController.MovementRecieved += OnMovementRecieved;
        _inputController.MovementEnd += OnMovementEnd;
    }

    private void UnsubscribeEvents()
    {
        _inputController.MovementRecieved -= OnMovementRecieved;
        _inputController.MovementEnd -= OnMovementEnd;
    }

    private void OnMovementRecieved(Vector2 movement)
    {
        Debug.Log("movement " + movement);
        _targetVector = new Vector2(movement.x * _levelWidth, _basicRunner.motion.offset.y);
        // UpdateMovement(movement.x);
    }

    private void OnMovementEnd()
    {
        _targetVector = Vector2.zero;
    }

    // private void UpdateMovement(float _x)
    // {
    //     _basicRunner.motion.offset = new Vector2(_x, _basicRunner.motion.offset.y);
    // }

    private void Update()
    {
        var finalOffset = UnityEngine.Vector2.MoveTowards(_basicRunner.motion.offset, _targetVector, _slideSpeed * Time.deltaTime);
        _basicRunner.motion.offset = finalOffset;
    }
    private void OnDestroy()
    {
        UnsubscribeEvents();
    }
}
