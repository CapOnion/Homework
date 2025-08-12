using Dreamteck.Forever;
using Unity.VisualScripting;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _player;
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private GameObject _menuUI;
    public void onClick()
    {
        _gameManager.gameObject.SetActive(true);
        _player.SetActive(true);
        _levelGenerator.gameObject.SetActive(true);
        _menuUI.gameObject.SetActive(false);
    }
}
