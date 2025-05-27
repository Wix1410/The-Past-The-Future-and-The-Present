using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    [Header("Bindings")]
    public GameObject pressEPopUp;
    public GameObject computerUI;

    public List<Computer> loginComputer = new List<Computer>();

    private void Start()
    {
        pressEPopUp.SetActive(false);
        computerUI.SetActive(false);    
    }
    public void OpenComputer()
    {
        for (int i = 0; i < loginComputer.Count; i++)
        {
            computerUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
