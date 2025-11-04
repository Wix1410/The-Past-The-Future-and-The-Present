using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public GameObject pauseMenu;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            dialogueUI.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
}
