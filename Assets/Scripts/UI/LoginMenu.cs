using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoginMenu : MonoBehaviour
{
    public EventSystem eventSystem;
    public TMP_InputField passwordInput;
    public TMP_Text txt;
    public Player player;
    [Space]
    public Button loginButton;

    private void Start()
    {
        loginButton.onClick.AddListener(Login); 
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            BackToGame();
        }
    }
    public void Login()
    {
        if (passwordInput.text == "Time")
        {
            passwordInput.enabled = false;
            txt.text = "Login successful!";
            txt.color = Color.green;
            PlayerPrefs.SetString("player_Password", passwordInput.text);
            StartCoroutine(Singleton.Instance.InvokeUnscaledCoroutiine(BackToGame, 0.5f));
        }
        else
        {
            txt.text = "Wrong password!";
            txt.color = Color.red;
            passwordInput.text = "";
            passwordInput.ActivateInputField();
        }
    }

    private void BackToGame()
    {
        this.gameObject.SetActive(false);
        player.enabled = true;
        Time.timeScale = 1f;
    }
}
