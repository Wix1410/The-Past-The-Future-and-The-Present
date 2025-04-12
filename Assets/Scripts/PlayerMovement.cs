using JetBrains.Annotations;
using System.Collections;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveCooldown = 0.5f;

    [Header("Settings")]
    public LayerMask wallLayer;
    public LayerMask destructableLayer;

    private float moveTimer = 0f;

    private void Update()
    {
        if(moveTimer > 0)
        {
            moveTimer -= Time.deltaTime;
            return;
        }

        Vector3 targetPosition = transform.position;
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            targetPosition.x += Input.GetAxisRaw("Horizontal") * 0.16f;
            moveTimer = moveCooldown;
        }
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            targetPosition.y += Input.GetAxisRaw("Vertical") * 0.16f;
            moveTimer = moveCooldown;
        }
        RaycastHit2D hit = Physics2D.Raycast(targetPosition, Vector2.up, 0.01f, wallLayer);
        if (hit.collider == null)
        {
            transform.position = targetPosition;
        }
    }
}
