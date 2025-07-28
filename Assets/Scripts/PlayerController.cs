using UnityEngine;
using Dreamteck.Forever;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioClip _explosionSound;
     private InputControls _inputController;
    [SerializeField] private Runner _basicRunner;
    [SerializeField] private float _slideSpeed = 5f;
    [SerializeField] private int _levelWidth = 5;
    [SerializeField] private GameManager _gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(_explosionSound, transform.position);
            _gameManager.AddScore(10);
        }
    }

    private void Update()
    {
        var finalOffset = UnityEngine.Vector2.MoveTowards(_basicRunner.motion.offset, _targetVector, _slideSpeed * Time.deltaTime);
        _basicRunner.motion.offset = finalOffset;
    }

    public void GameOver()
    {
        _basicRunner.follow = false;
    }

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
        _targetVector = new Vector2(movement.x * _levelWidth, _basicRunner.motion.offset.y);
    }

    private void OnMovementEnd()
    {
        _targetVector = _basicRunner.motion.offset;
    }

    private void OnDestroy()
    {
        UnsubscribeEvents();
    }
}
