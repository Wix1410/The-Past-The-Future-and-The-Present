using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Computer : MonoBehaviour
{
    [Header("Bindings")]
    public GameObject pressEPopUp;
    public GameObject computerUI;
    public Player player;

    public List<Computer> loginComputer = new List<Computer>();
    public List<Computer> startTimeGateComputer = new List<Computer>();

    private void Start()
    {
        pressEPopUp.SetActive(false);
        if(computerUI != null)
        {
            computerUI.SetActive(false);    
        }
    }
    public void OpenComputer()
    {
        if(computerUI == null)
        {
            Debug.LogWarning("Computer UI is not assigned!");
            return;
        }
        for (int i = 0; i < loginComputer.Count; i++)
        {
            computerUI.SetActive(true);
            Time.timeScale = 0;
        }
        for (int i = 0; i < startTimeGateComputer.Count; i++)
        {   
            SceneManager.LoadScene("TimePeriodChooseMenu");
        }
    }
}
