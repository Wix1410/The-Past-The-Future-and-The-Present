using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public Sprite[] sprite;
    public SpriteRenderer spriteRenderer;

    private bool isUsed = false;

    private void Update()
    {
        if (isUsed)
        {
            return;
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.01f);
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            Saveble.SaveAll();
            isUsed = true;
            Debug.Log("Checkpoint reached");
        }
    }
}

