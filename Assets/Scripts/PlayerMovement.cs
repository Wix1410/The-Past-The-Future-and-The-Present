using JetBrains.Annotations;
using System.Collections;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveCooldown = 0.5f;

    [Header("References")]
    public Rigidbody2D rb;

    private float moveTimer = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

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
        if(Input.GetAxisRaw("Vertical") != 0)
        {
            targetPosition.y += Input.GetAxisRaw("Vertical") * 0.16f;
            moveTimer = moveCooldown;
        }
        RaycastHit2D hit = Physics2D.Raycast(targetPosition, Vector2.up, 0.01f);
        if (hit.collider == null)
        {
            transform.position = targetPosition;
        }
        //if (rb != null)
        //{
        //    if (Input.GetAxis("Horizontal") > 0)
        //    {
        //        rb.MovePosition(rb.position + Vector2.right * moveSpeed * Time.deltaTime);
        //    }
        //    else if (Input.GetAxis("Horizontal") < 0)
        //    {
        //        rb.MovePosition(rb.position + Vector2.left * moveSpeed * Time.deltaTime);
        //    }
        //    if (Input.GetAxis("Vertical") > 0)
        //    {
        //        rb.MovePosition(rb.position + Vector2.up * moveSpeed * Time.deltaTime);
        //    }
        //    else if (Input.GetAxis("Vertical") < 0)
        //    {
        //        rb.MovePosition(rb.position + Vector2.down * moveSpeed * Time.deltaTime);
        //    }
        //}
    }
}
