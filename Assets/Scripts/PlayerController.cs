using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Dreamteck.Forever;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioClip _explosionSound;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _timeToExplodeText;
    [SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] private float timeToExplode = 60;
     private InputControls _inputController;
    [SerializeField] private Runner _basicRunner;
    [SerializeField] private float _slideSpeed = 5f;
    [SerializeField] private int _levelWidth = 5;


    private int scoreNumber = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            scoreNumber += 10;
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(_explosionSound, transform.position);
            _scoreText.text = "Score: " + scoreNumber;
        }
    }

    private void Start()
    {
        _gameOverText.enabled = false;
    }
    private void Update()
    {
        var finalOffset = UnityEngine.Vector2.MoveTowards(_basicRunner.motion.offset, _targetVector, _slideSpeed * Time.deltaTime);
        _basicRunner.motion.offset = finalOffset;
        
        timeToExplode -= 1 * Time.deltaTime;
        _timeToExplodeText.text = "Time to explode: " + timeToExplode;

        if (timeToExplode <= 0)
        {
            scoreNumber -= 100;
            if (scoreNumber <= 0)
            {
                GameOver();
            }
            //ResetTimer();
        }
    }

    private void ResetTimer()
    {
        timeToExplode = 60;
    }

    private void GameOver()
    {
        _gameOverText.enabled = true;
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
