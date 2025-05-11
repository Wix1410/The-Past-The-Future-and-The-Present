using System.Collections;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Bindings")]
    public GameObject pauseMenu;
    public Rigidbody2D rb;

    [Header("Movement")]
    public float moveCooldown = 0.5f;
    public float movePushableCooldown = 0.5f;

    private float moveTimer = 0f;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseMenu.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saveble.LoadAll();
        }
        if (moveTimer > 0)
        {
            moveTimer -= Time.deltaTime;
            return;
        }
        Vector3 targetPosition = transform.position;
        if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") == 0)
        { 
            targetPosition.x += Input.GetAxisRaw("Horizontal");
            moveTimer = moveCooldown;
        }
        if (Input.GetAxisRaw("Vertical") != 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            targetPosition.y += Input.GetAxisRaw("Vertical");
            moveTimer = moveCooldown;
        }
        RaycastHit2D hit = Physics2D.Raycast(targetPosition, Vector2.up, 0.01f);
        if (hit.collider == null )
        {
            if(targetPosition != transform.position)
            {
                //transform.position = targetPosition;
                rb.MovePosition(targetPosition);
            }
        }
        else
        {
            //Dotkniecie
            float direction = Input.GetAxisRaw("Horizontal");
            //Check if collider has layer movable
            if ((hit.collider.gameObject.layer == LayerMask.NameToLayer("Movable")))
            {
                Vector3 boxPosition = hit.collider.transform.position;
                Collider2D box = Physics2D.OverlapBox(boxPosition + Vector3.right * direction, new Vector2(0.1f, 0.1f), 0f);
                if (box == null)
                {
                    moveTimer = movePushableCooldown;
                    hit.collider.transform.Translate(direction, 0, 0);
                    rb.MovePosition(targetPosition);
                }
            }
            else if ((hit.collider.gameObject.layer == LayerMask.NameToLayer("Finished")))
            {
                LevelEnd levelEnd = hit.collider.GetComponent<LevelEnd>();
                if (levelEnd != null)
                {
                    levelEnd.NextLevel();
                }
            }
            else if ((hit.collider.gameObject.layer == LayerMask.NameToLayer("Destructable")))
            {
                Destructable destructable = hit.collider.GetComponent<Destructable>();
                if (destructable != null)
                {
                    destructable.DestroyObject();
                    rb.MovePosition(targetPosition);
                }
            }
            else if ((hit.collider.gameObject.layer == LayerMask.NameToLayer("CheckPoint")))
            {
                CheckPoints point = hit.collider.GetComponent<CheckPoints>();
                if (point != null)
                {
                    rb.MovePosition(targetPosition);
                    transform.position = point.transform.position;
                    point.SaveLevel();
                }
            }
        }
    }
}
