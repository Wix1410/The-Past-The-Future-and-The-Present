using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public Sprite[] sprite;
    public SpriteRenderer spriteRenderer;
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
        Debug.Log("Checkpoint reached");
    }
}

