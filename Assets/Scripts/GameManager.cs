using TMPro;
using UnityEngine;
using Dreamteck.Forever;
using JSAM;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] public BombTimerScript _bombTimerScript;
    [SerializeField] private PlayerController _player;
    [SerializeField] private GameObject _playerObject;
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private GameObject _menuUI;

    int bombsLeft = 3;
    int bombsExploded = 0;
    int highscore = 0;
    bool isPaused;

    private void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        _gameOverText.enabled = false;
        AudioManager.PlayMusic(AudioLibMusic.BackgroundMusic);
        if (GameSaver.TryLoad<PlayerData>(out var data))
        {
            highscore = data.Highscore;
            bombsExploded = data.BombsExploded;
        }
    }
    public void SavePlayerData(int _currentScore, int _bombsExploded)
    {
        PlayerData playerData = new PlayerData(
            _currentScore,
            _bombsExploded
        );

        GameSaver.Save(playerData);
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

    public void BombExplode()
    {
        bombsLeft = bombsLeft - 1;
        bombsExploded = bombsExploded + 1;
        if (bombsLeft == 0)
        {
            GameOver();
            if (ScoreManager.Instance.scoreNumber > highscore)
            {
                SavePlayerData(ScoreManager.Instance.scoreNumber, bombsExploded);
                Debug.Log("New highscore! " + ScoreManager.Instance.scoreNumber);
            }
            else
            {
                SavePlayerData(highscore, bombsExploded);
            }
            Debug.Log("Bombs exploded: " + bombsExploded);
        }
    }
    public void AddScore(int _nubmerToAdd)
    {
        ScoreManager.Instance.AddScore(_nubmerToAdd);
    }
}
