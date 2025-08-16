using TMPro;
using UnityEngine;
using Dreamteck.Forever;
using JSAM;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] public BombTimerScript _bombTimerScript;
    [SerializeField] private PlayerController _player;
    [SerializeField] private GameObject _playerObject;
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private GameObject _menuUI;


    bool isPaused;
    private int scoreNumber = 0;

    private void Start()
    {
        _gameOverText.enabled = false;
        AudioManager.PlayMusic(AudioLibMusic.BackgroundMusic);
    }

    public void onPlayClick()
    {
        isPaused = false;
        Time.timeScale = 1f;
        this.gameObject.SetActive(true);
        _playerObject.SetActive(true);
        _levelGenerator.gameObject.SetActive(true);
        _menuUI.gameObject.SetActive(false);
    }
    public void onPauseClick()
    {
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        _gameOverText.enabled = true;
        _bombTimerScript._timeToExplodeText.text = "0";
        _bombTimerScript.enabled = false;
        _player.GameOver();
        this.enabled = false;
        
    }


    public void AddScore(int nubmerToAdd)
    {
        scoreNumber += nubmerToAdd;
        _scoreText.text = scoreNumber.ToString();
        if (scoreNumber < 0)
        {
            GameOver();
        }
    }
}
