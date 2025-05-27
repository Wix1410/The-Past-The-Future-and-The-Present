using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerNameManager : MonoBehaviour
{
    public EventSystem eventSystem;
    public TMP_InputField playerNameInput;
    public Player player;
    [Space]
    public Button loginButton;

    private void Start()
    {
        loginButton.onClick.AddListener(Login); 
    }

    public void Login()
    {
        PlayerPrefs.SetString("player_name", playerNameInput.text);
        this.gameObject.SetActive(false);
        player.enabled = true;
        Time.timeScale = 1;
    }
}
