
using UnityEngine;
[DisallowMultipleComponent]
public class Falling : MonoBehaviour
{

    [Header("Movement")]
    public float moveCooldown = 0.1f;
    public bool isFalling = false;

    protected float moveTimer = 0f;

    private void Update()
    {
        if (moveTimer > 0)
        {
            moveTimer -= Time.deltaTime;
            return;
        }
        Vector3 position = transform.position;
        Collider2D box = Physics2D.OverlapBox(position + Vector3.down * 1f, new Vector2(0.1f, 0.1f), 0f);
        if (box == null)
        {
            moveTimer = moveCooldown;
            transform.Translate(0, -1, 0);
            isFalling = true;
        }
        else
        {
            OnFallOnObject(box);
            isFalling = false;
        }
    }

    public virtual void OnFallOnObject(Collider2D box)
    {

    }
}
