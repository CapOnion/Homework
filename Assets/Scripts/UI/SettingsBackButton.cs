using UnityEngine;

public class SettingsBackButton : MonoBehaviour
{
    [SerializeField] private GameObject _settingScreen;
    [SerializeField] private GameObject _menuScreen;

    public void OnBackClick()
    {
        _settingScreen.gameObject.SetActive(false);
        _menuScreen.gameObject.SetActive(true);
    }

    public void OnSettingsClick()
    {
        _settingScreen.gameObject.SetActive(true);
        _menuScreen.gameObject.SetActive(false);
    }
}
