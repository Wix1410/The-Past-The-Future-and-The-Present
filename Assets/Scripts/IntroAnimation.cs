using UnityEngine;

public class IntroAnimation : MonoBehaviour
{
    [Header("Movement")]
    public float moveCooldown = 0.5f;

    [Header("Bindings")]
    public Player player;

    private float moveTimer = 0f;

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
