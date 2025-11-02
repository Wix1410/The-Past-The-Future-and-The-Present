using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public GameObject pauseMenu;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            dialogueUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pauseMenu.SetActive(false);
    }
}
