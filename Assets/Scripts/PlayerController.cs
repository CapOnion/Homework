using UnityEngine;
using Dreamteck.Forever;
using JSAM;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioClip _explosionSound;
     private InputControls _inputController;
    [SerializeField] private Runner _basicRunner;
    [SerializeField] private float _slideSpeed = 5f;
    [SerializeField] private int _levelWidth = 5;
    [SerializeField] private int _levelHeight = 5;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Animator _animator;

    [SerializeField] private ParticleSystem _explosion;

    private const string Running = "isRunning";
    private const string flyUp = "flyUp";
    private const string Landing = "isLanding";
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            // AudioSource.PlayClipAtPoint(_explosionSound, transform.position);
            AudioManager.PlaySound(AudioLibSounds.ExplosionSFX);
            _explosion.Play();
            _gameManager.AddScore(10);
        }

        if (other.CompareTag("Boost_timer"))
        {
            Destroy(other.gameObject);
            AudioManager.PlaySound(AudioLibSounds.CollectiblesSFX);
            _gameManager._bombTimerScript.AddTime(10);
        }
        if (other.CompareTag("Obstacle"))
        {
            _gameManager.AddScore(-100);
            _explosion.Play();
        }
    }

    private void Start()
    {
        _animator.SetBool(Running, true);
        AudioManager.PlaySound(AudioLibSounds.RunSFX);
    }

    private void Update()
    {
        var finalOffset = UnityEngine.Vector2.MoveTowards(_basicRunner.motion.offset, _targetVector, _slideSpeed * Time.deltaTime);
        _basicRunner.motion.offset = finalOffset;

        if ((_animator.GetBool(Running) == false) && _basicRunner.motion.offset.y <= 0)
        {
            _animator.SetTrigger(Landing);
            _animator.SetBool(Running, true);
            AudioManager.PlaySound(AudioLibSounds.RunSFX);
        }
        
    }

    public void GameOver()
    {
        _basicRunner.follow = false;
        _animator.SetBool(Running, false);
        this.enabled = false;
    }

    private Vector2 _targetVector;
    private void Awake()
    {
        _inputController = new();
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        _inputController.MovementXRecieved += OnMovementXRecieved;
        _inputController.MovementXEnd += OnMovementEnd;

        _inputController.MovementYRecieved += OnMovementYRecieved;
        _inputController.MovementYEnd += OnMovementEnd;
    }

    private void UnsubscribeEvents()
    {
        _inputController.MovementXRecieved -= OnMovementXRecieved;
        _inputController.MovementXEnd -= OnMovementEnd;

        _inputController.MovementYRecieved -= OnMovementYRecieved;
        _inputController.MovementYEnd -= OnMovementEnd;
    }

    private void OnMovementXRecieved(Vector2 movement)
        {
            _targetVector = new Vector2(movement.x * _levelWidth, _basicRunner.motion.offset.y);
        }

    private void OnMovementYRecieved(Vector2 movement)
    {
        float _targetY = movement.y * _levelHeight;
        if (_targetY <= 0)
        {
            _targetY = 0;
        }

        _targetVector = new Vector2(_basicRunner.motion.offset.x, _targetY);

        if (_targetY > 0)
        {

            if (_animator.GetBool(Running) == true)
            {
                _animator.SetBool(Running, false);
                AudioManager.StopSound(AudioLibSounds.RunSFX);
                _animator.SetTrigger(flyUp);
            }

        }
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
