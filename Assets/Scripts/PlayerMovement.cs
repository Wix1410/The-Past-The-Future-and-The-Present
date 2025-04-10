using System.Collections;
using UnityEngine;

//animacje
public class PlayerMovement : MonoBehaviour
{
    private const string SPEED = "Speed";
    private const string IS_MOVING = "IsMoving";
    private const string IS_JUMPING = "IsJumping";
    private const string IS_FALLING = "IsFalling";
    private const string IS_DASHING = "IsDashing";
    private const string WALL_SLIDING = "IsWallSliding";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            float x = 0.16f;
            transform.position += new Vector3(x, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            float x = 0.16f;
            transform.position -= new Vector3(x, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            float y = 0.16f;
            transform.position += new Vector3(0, y, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            float y = 0.16f;
            transform.position -= new Vector3(0, y, 0);
        }
    }
}
