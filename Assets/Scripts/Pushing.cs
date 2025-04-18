using TMPro;
using UnityEngine;

public class Pushing : MonoBehaviour
{
    [Header("Movement")]
    public float moveCooldown = 0.5f;

    [Header("Settings")]
    public LayerMask wallLayer;
    public LayerMask movableLayer;

    private float moveTimer = 0f;

    private void Update()
    {
        if (moveTimer > 0)
        {
            moveTimer -= Time.deltaTime;
            return;
        }
        Vector3 position = transform.position;
        Collider2D boxRight = Physics2D.OverlapBox(position + Vector3.right * 0.16f, new Vector2(0.1f, 0.1f), 0f);
        Collider2D boxLeft = Physics2D.OverlapBox(position + Vector3.left * 0.16f, new Vector2(0.1f, 0.1f), 0f);
        if (boxRight != null && boxRight.CompareTag("Player"))
        {
            moveTimer = moveCooldown;
            transform.Translate(0, -1 * 0.16f, 0);
        }
        if (boxLeft != null && boxLeft.CompareTag("Player"))
        {
            moveTimer = moveCooldown;
            transform.Translate(-1 * 0.16f, 0, 0);        
        }
    }
}
