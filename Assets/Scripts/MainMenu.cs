﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void PauseGame()
    {
        SceneManager.LoadScene("PauseMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name + " MODE: " + mode);

        if(scene.name == "GameScene" && DialogueManager.conversation == 0)
        {
            GameObject openingTrigger = GameObject.Find("Toggle");
            openingTrigger.GetComponent<Toggle>().isOn = true;
            DialogueManager.conversation++;
        }
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
