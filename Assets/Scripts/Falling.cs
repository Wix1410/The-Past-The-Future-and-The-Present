using TMPro;
using UnityEngine;

public class Falling : MonoBehaviour
{
    [Header("Movement")]
    public float moveCooldown = 0.5f;

    [Header("Settings")]
    public LayerMask wallLayer;

    private float moveTimer = 0f;

    private void Update()
    {
        if (moveTimer > 0)
        {
            moveTimer -= Time.deltaTime;
            return;
        }
        Vector3 position = transform.position;
        Collider2D box = Physics2D.OverlapBox(position + Vector3.down * 0.16f, new Vector2(0.1f, 0.1f), 0f);
        if (box == null)
        {
            moveTimer = moveCooldown;
            transform.Translate(0, -1 * 0.16f, 0);
        }
    }
}
