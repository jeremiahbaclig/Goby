using UnityEngine;
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
        GameObject openingTrigger = GameObject.Find("Toggle");
        openingTrigger.GetComponent<Toggle>().isOn = false;
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
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

        if(scene.name == "GameScene")
        {
            GameObject openingTrigger = GameObject.Find("Toggle");
            openingTrigger.GetComponent<Toggle>().isOn = true;
            Invoke(nameof(CallOpening), 0.02f);
            // PlayerCamera.starting = true;
        }
    }

    private void CallOpening()
    {
        PlayerCamera cam = new PlayerCamera();
        cam.OpeningCutscene();
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
