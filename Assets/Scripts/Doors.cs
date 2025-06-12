using UnityEngine;

public class Doors : MonoBehaviour
{
    [Header("Bindings")]
    public BoxCollider2D doorCollider;
    public SpriteRenderer open;
    public SpriteRenderer close;
    public Saveble saveble;

    public int levelNumber;
    public bool isOpen = false;

    public void Open()
    {
        doorCollider.enabled = false;
        isOpen = true;
        open.enabled = true;
        close.enabled = false;
        PlayerPrefs.SetInt($"door_{levelNumber}_{saveble.id}", 1); 
    }

    public void Close()
    {
        doorCollider.enabled = true;
        isOpen = false;
        open.enabled = false;
        close.enabled = true;
        PlayerPrefs.SetInt($"door_{levelNumber}_{saveble.id}", 0);
    }

    private void OnDrawGizmosSelected()
    {
        if(isOpen)
        {
            Open();
        }
        else
        {
            Close();
        }
    }
}
