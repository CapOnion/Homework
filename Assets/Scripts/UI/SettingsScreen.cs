using JSAM;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScreen : MonoBehaviour
{
    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _sfxVolumeSlider;

    [SerializeField] private TMP_Text _masterVolumeText;
    [SerializeField] private TMP_Text _musicVolumeText;
    [SerializeField] private TMP_Text _sfxVolumeText;
    float _sliderValue;

    private void Start()
    {
        SetValues();
    }
    private void SetValues()
    {
        _masterVolumeSlider.value = PlayerPrefs.GetFloat(Constants.MasterVolumeKey, 1f);
        _sliderValue = _masterVolumeSlider.value * 100;
        _masterVolumeText.text = _sliderValue.ToString("0");
        AudioManager.MasterVolume = _masterVolumeSlider.value;

        _musicVolumeSlider.value = PlayerPrefs.GetFloat(Constants.MusicVolumeKey, 1f);
        _sliderValue = _musicVolumeSlider.value * 100;
        _musicVolumeText.text = _sliderValue.ToString("0");
        AudioManager.MusicVolume = _musicVolumeSlider.value;

        _sfxVolumeSlider.value = PlayerPrefs.GetFloat(Constants.SFXVolumeKey, 1f);
        _sliderValue = _sfxVolumeSlider.value * 100;
        _sfxVolumeText.text = _sliderValue.ToString("0");
        AudioManager.SoundVolume = _sfxVolumeSlider.value;
    }
    public void OnMasterSliderChanged(float value)
    {
        _sliderValue = value * 100;
        _masterVolumeText.text = _sliderValue.ToString("0");
        AudioManager.MasterVolume = value;
        PlayerPrefs.SetFloat(Constants.MasterVolumeKey, value);
        PlayerPrefs.Save();
    }

    public void OnMusicSliderChanged(float value)
    {
        _sliderValue = value * 100;
        _musicVolumeText.text = _sliderValue.ToString("0");
        AudioManager.MusicVolume = value;
        PlayerPrefs.SetFloat(Constants.MusicVolumeKey, value);
        PlayerPrefs.Save();
    }

    public void OnSFXSliderChanged(float value)
    {
        _sliderValue = value * 100;
        _sfxVolumeText.text = _sliderValue.ToString("0");
        AudioManager.SoundVolume = value;
        PlayerPrefs.SetFloat(Constants.SFXVolumeKey, value);
        PlayerPrefs.Save();
    }

    public void OnDefaultClick()
    {
        // GameManager.Instance.SavePlayerData(0, 0);
        GameSaver.Save(new PlayerData(0,0));
        PlayerPrefs.DeleteAll();
        SetValues();
    }

}
