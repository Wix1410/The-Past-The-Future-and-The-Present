using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject camera;
    public Transform player;

    public LayerMask playerLayer;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.01f, playerLayer);
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            camera.transform.SetParent(player.transform);
            camera.GetComponent<BoxCollider2D>().enabled = false;
            player.GetComponentInParent<PlayerMovement>().enabled = true;
            player.GetComponentInParent<INepednentPlayerStartMovement>().enabled = false;
        }
    }
}
