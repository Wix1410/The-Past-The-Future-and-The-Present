using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public EventSystem eventSystem;
    [Space]
    public Button newGameButton;
    public Button continueButton;
    public Button settingsButton;
    public Button creditsButton;
    public Button quitButton;
    private void Start()
    {
        newGameButton.onClick.AddListener(StartNewGame);
        continueButton.onClick.AddListener(ContinueGame);
        settingsButton.onClick.AddListener(Settings);
        creditsButton.onClick.AddListener(Credits);
        quitButton.onClick.AddListener(QuitGame);
    }
    private void StartNewGame()
    {
        SceneManager.LoadScene("Prologue");
    }
    public void ContinueGame()
    {
        SceneManager.LoadScene("TimePeriodChooseMenu");
    }
    public void Settings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }
    public void Credits()
    {
        SceneManager.LoadScene("CreditsMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
