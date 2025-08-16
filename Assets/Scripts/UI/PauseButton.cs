using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject _menuUI;
    [SerializeField] private GameManager _gameManager;

    public void OnPauseClick()
    {
        _menuUI.SetActive(true);
        _gameManager.onPauseClick();
    }
}
