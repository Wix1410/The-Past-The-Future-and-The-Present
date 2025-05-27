using System.Collections.Generic;
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

    [Header("Eq")]
    public List<Item> items = new List<Item>();

    private float moveTimer = 0f;

    private Computer currentlyInteractedComputer;
    private void Start()
    {
        PlayerPrefs.DeleteKey("player_name");
    }
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
        if (Input.GetKeyDown(KeyCode.E) && currentlyInteractedComputer != null)
        {
            currentlyInteractedComputer.OpenComputer();
            this.enabled = false;
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
        if(targetPosition != transform.position)
        {
            if (currentlyInteractedComputer != null)
            {
                currentlyInteractedComputer.pressEPopUp.SetActive(false);
            }
            currentlyInteractedComputer = null;
        }
        RaycastHit2D hit = Physics2D.Raycast(targetPosition, Vector2.up, 0.01f);
        if (hit.collider == null)
        {
            if(targetPosition != transform.position)
            {
                rb.MovePosition(targetPosition);
            }
        }
        else if (targetPosition != transform.position && hit.collider.gameObject.layer != LayerMask.NameToLayer("Wall"))
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
            else if ((hit.collider.gameObject.layer == LayerMask.NameToLayer("DoorButton")))
            {
                DoorsButton doorsButton = hit.collider.GetComponent<DoorsButton>();
                if (doorsButton != null)
                {
                    rb.MovePosition(targetPosition);
                    transform.position = doorsButton.transform.position;
                    doorsButton.TurnOn(this);
                }
            }
            else if ((hit.collider.gameObject.layer == LayerMask.NameToLayer("Doors")))
            {

            }
            else if ((hit.collider.gameObject.layer == LayerMask.NameToLayer("Chest")))
            {
                Chest chest = hit.collider.GetComponent<Chest>();
                if (chest != null)
                {
                    rb.MovePosition(targetPosition);
                    chest.OpenChest(this);
                }
            }
            else if ((hit.collider.gameObject.layer == LayerMask.NameToLayer("Computer")))
            {
                Computer computer = hit.collider.GetComponent<Computer>();
                if (computer != null)
                {
                    computer.pressEPopUp.SetActive(true);
                    currentlyInteractedComputer = computer;
                }
            }
            else
            {
                rb.MovePosition(targetPosition);
                Debug.LogError($"[Player] Trigger Not Supported: {hit.collider.gameObject}", hit.collider.gameObject);
            }
        }
    }
}
