using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI _scoreText;

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        
    }

    public int scoreNumber = 0;

    public void AddScore(int nubmerToAdd)
    {
        scoreNumber += nubmerToAdd;
        _scoreText.text = scoreNumber.ToString();
    }


}
