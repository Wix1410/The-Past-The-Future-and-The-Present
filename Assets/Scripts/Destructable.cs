using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Destructable : MonoBehaviour
{
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.01f);
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
