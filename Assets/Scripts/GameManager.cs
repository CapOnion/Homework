using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] public BombTimerScript _bombTimerScript;
    [SerializeField] private PlayerController _player;
    

    private int scoreNumber = 0;

    private void Start()
    {
        _gameOverText.enabled = false;
    }

    private void Update()
    {
        if (_bombTimerScript._bombTimer <= 0)
        {
            AddScore(-100);
            if (scoreNumber <= 0)
            {
                GameOver();
            }
            ResetTimer();
        }
    }

    private void ResetTimer()
    {
        _bombTimerScript.AddTime(_bombTimerScript._bombTimer);
    }

    public void GameOver()
    {
        _gameOverText.enabled = true;
        _bombTimerScript._timeToExplodeText.text = "Time to explode: 0";
        _bombTimerScript.enabled = false;
        _player.GameOver();
    }


    public void AddScore(int nubmerToAdd)
    {
        scoreNumber += nubmerToAdd;
        _scoreText.text = "Score: " + scoreNumber;
    }
}
