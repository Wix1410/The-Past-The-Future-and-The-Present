using UnityEngine;

public class INepednentPlayerStartMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveCooldown = 0.5f;

    public GameObject player;

    private float moveTimer = 0f;

    void Start()
    {
        player.GetComponentInParent<PlayerMovement>().enabled = false;
    }
    void Update()
    {
        if (moveTimer > 0)
        {
            moveTimer -= Time.deltaTime;
            return;
        }
        moveTimer = moveCooldown;
        transform.Translate(1 * 0.16f, 0, 0);
    }
}
