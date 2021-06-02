using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject mobileButtons;
    public static bool isPaused;
    void Start()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        pauseButton = GameObject.Find("PauseButton");
        mobileButtons = GameObject.Find("MobileButtons");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        pauseButton.SetActive(false);
        if(PlayerController.onMobile)
            mobileButtons.SetActive(false);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        pauseButton.SetActive(true);
        if(PlayerController.onMobile)
            mobileButtons.SetActive(true);
    }
}
