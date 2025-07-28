using UnityEngine;
using TMPro;

public class BombTimerScript : MonoBehaviour
{
    [SerializeField] public float _bombTimer;
    [SerializeField] public TextMeshProUGUI _timeToExplodeText;
    void Start()
    {

    }

    void Update()
    {
        _bombTimer -= 1 * Time.deltaTime;
        _timeToExplodeText.text = "Time to explode: " + _bombTimer;
    }

    public void AddTime(float timeToAdd)
    {
        _bombTimer += timeToAdd;
    }
}
