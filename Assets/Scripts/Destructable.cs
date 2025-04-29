
using UnityEngine;


public class Destructable : MonoBehaviour
{
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.01f);
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
