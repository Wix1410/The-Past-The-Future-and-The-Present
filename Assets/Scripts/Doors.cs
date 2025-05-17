using UnityEngine;

public class Doors : MonoBehaviour
{
    [Header("Bindings")]
    public BoxCollider2D doorCollider;
    public SpriteRenderer open;
    public SpriteRenderer close;

    public bool isOpen = false;

    public void Open()
    {
        doorCollider.enabled = false;
        isOpen = true;
        open.enabled = true;
        close.enabled = false;
    }

    public void Close()
    {
        doorCollider.enabled = true;
        isOpen = false;
        open.enabled = false;
        close.enabled = true;
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
