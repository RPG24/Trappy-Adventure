using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject Playbutton, OptionsButton, QuitButton, Title;
    [SerializeField] private GameObject OptionMenu;
    [SerializeField] private Slider VolumeSlider;
    public AudioMixer audioMixer;

    private void Start()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    public void OpenMenu()
    {
        Playbutton.SetActive(false);
        OptionsButton.SetActive(false);
        QuitButton.SetActive(false);
        Title.SetActive(false);
        OptionMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        Playbutton.SetActive(true);
        OptionsButton.SetActive(true);
        QuitButton.SetActive(true);
        Title.SetActive(true);
        OptionMenu.SetActive(false);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
