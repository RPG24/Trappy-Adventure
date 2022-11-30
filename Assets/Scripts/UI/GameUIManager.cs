using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{

    private Scene scene;
    public TextMeshProUGUI lives;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject UIControls;
    [SerializeField] private Toggle TouchToggle;
    [SerializeField] private GameObject PauseButton;
    [SerializeField] private Slider VolumeSlider;
    public AudioMixer audioMixer;

    void Start()
    {
        scene = GameObject.FindGameObjectWithTag("Scene").GetComponent<Scene>();
        VolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        TouchToggle.isOn = PlayerPrefs.GetInt("UIControls") == 1? true : false;
        UIControls.SetActive(TouchToggle.isOn);
    }

    // Update is called once per frame
    void Update()
    {
        lives.text = "Lives - " + (scene.lives + 1).ToString();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
        UIControls.SetActive(false);
        PauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
        if (TouchToggle.isOn)
        {
            UIControls.SetActive(true);
        }
        else
        {
            UIControls.SetActive(false);
        }
        PlayerPrefs.SetInt("UIControls", TouchToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }
}
