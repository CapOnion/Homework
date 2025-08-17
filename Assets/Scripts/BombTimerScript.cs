using UnityEngine;
using TMPro;
using System.Collections;

public class BombTimerScript : MonoBehaviour
{
    [SerializeField] public float _bombTimer;
    [SerializeField] public TextMeshProUGUI _timeToExplodeText;
    [SerializeField] private GameManager _gameManager;

    void Start()
    {

    }

    private const string AddTimeTrigger = "addTime";

    void Update()
    {
        _bombTimer -= 1 * Time.deltaTime;
        _timeToExplodeText.text = _bombTimer.ToString("0");
        if (_bombTimer <= 0)
        {
            GameManager.Instance.BombExplode();
            ResetTimer();
        }
    }

    public void AddTime(float timeToAdd)
    {
        _bombTimer += timeToAdd;
    }   

    private void ResetTimer()
    {
        AddTime(_bombTimer);
    }

}

