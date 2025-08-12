using TMPro;
using UnityEngine;
using Dreamteck.Forever;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] public BombTimerScript _bombTimerScript;
    [SerializeField] private PlayerController _player;
    [SerializeField] private GameObject _playerObject;
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private GameObject _menuUI;
    
    

    private int scoreNumber = 0;

    private void Start()
    {
        _gameOverText.enabled = false;
    }

    public void onClick()
    {
        this.gameObject.SetActive(true);
        _playerObject.SetActive(true);
        _levelGenerator.gameObject.SetActive(true);
        _menuUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_bombTimerScript._bombTimer <= 0)
        {
            AddScore(-100);
            ResetTimer();
        }
        if (scoreNumber < 0)
        {
            GameOver();
        }
    }

    private void ResetTimer()
    {
        _bombTimerScript.AddTime(_bombTimerScript._bombTimer);
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
    }
}
