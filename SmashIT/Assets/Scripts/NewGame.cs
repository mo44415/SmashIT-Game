using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGame : MonoBehaviour
{
    public GameObject menu;
    public GameObject settings;
    public GameObject loadingScreen;
    public Slider progressSlider;
    public Slider volumeSlider;
    public TMPro.TMP_Dropdown resolutionDropdown;
    public AudioSource clickSound;


    private int[,] resolutions = {
        {1920, 1080},
        {1680, 1050},
        {1366, 768}
    };


    private void Start()
    {
        menu.SetActive(true);
        settings.SetActive(false);
        loadingScreen.SetActive(false);
        SetResolution();
        SetVolume();
    }

    public void Play ()
    {
        StartCoroutine(LoadAsynchronously(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadAsynchronously(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        loadingScreen.SetActive(true);


        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            progressSlider.value = progress;
            Debug.Log("Slider progress: " + progress);
            yield return null;
        }
    }

    public void Quit()
    {
        Debug.Log("Quit application!");
        Application.Quit();
    }

    public void ShowSettings(bool value)
    {
        menu.SetActive(!value);
        settings.SetActive(value);
    }

    public void SetVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void SetResolution()
    {
        int dropdownOption = resolutionDropdown.value;
        Screen.SetResolution(resolutions[dropdownOption, 0], resolutions[dropdownOption, 1], false);
    }

    public void PlaySelectSound()
    {
        clickSound.Play();
    }
}
