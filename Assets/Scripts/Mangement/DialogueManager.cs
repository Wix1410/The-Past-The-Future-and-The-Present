using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [Header("Bindings")]
    public GameObject dialogueUI;
    public TMP_Text txt;

    [Header("Arrays")]
    string[] dialogue1;

    private void Start()
    {
        dialogue1 = new string[] {"k", "l"};
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            for (int i = 0; i < dialogue1.Length; i++)
            {
                txt.text = dialogue1[i];
                if (i == dialogue1.Length)
                {
                    dialogueUI.SetActive(true);
                }
            }
        }
    }
}
