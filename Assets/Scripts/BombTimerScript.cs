using UnityEngine;
using TMPro;
using System.Collections;

public class BombTimerScript : MonoBehaviour
{
    [SerializeField] public float _bombTimer;
    [SerializeField] public TextMeshProUGUI _timeToExplodeText;

    void Start()
    {

    }

    private const string AddTimeTrigger = "addTime";

    void Update()
    {
        _bombTimer -= 1 * Time.deltaTime;
        _timeToExplodeText.text = _bombTimer.ToString();
    }

    public void AddTime(float timeToAdd)
    {
        _bombTimer += timeToAdd;
    }   

}

