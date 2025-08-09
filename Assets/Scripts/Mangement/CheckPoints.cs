using UnityEditor;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public Collider2D collider;

    private bool isUsed = false;

    public void SaveLevel()
    {
        if (isUsed)
        {
            return;
        }
        Saveble.SaveAll();
        isUsed = true;
        collider.enabled = false;
        audioSource.PlayOneShot(audioClip);
    }
}

