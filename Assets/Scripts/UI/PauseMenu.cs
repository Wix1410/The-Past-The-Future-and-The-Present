using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("Bindings")]
    public EventSystem eventSystem;
    public GameObject player;

    [Header("UI")]
    public Button resumeButton;
    public Button restartButton;
    public Button settingsButton;
    public Button goToMapButton;
    public Button quitButton;

    void Start()
    {
        gameObject.SetActive(false);
        resumeButton.onClick.AddListener(ResumeGame);
        restartButton.onClick.AddListener(RestartGame);
        settingsButton.onClick.AddListener(Settings);
        goToMapButton.onClick.AddListener(GoToMap);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void ResumeGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Settings()
    {
        throw new NotImplementedException();
    }

    private void GoToMap()
    {
        throw new NotImplementedException();
    }

    private void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            gameObject.SetActive(true);
            player.GetComponent<PlayerMovement>().enabled = false;
        }
        else
        {
            gameObject.SetActive(false);
            player.GetComponent<PlayerMovement>().enabled = true;
        }
    }
}
