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

    [Header("Hp")]
    public int MaxHp = 4;
    public int currentHp;

    [Header("Eq")]
    public List<Item> items = new List<Item>();

    private float moveTimer = 0f;

    private Computer currentlyInteractedComputer;

    private void Start()
    {
        currentHp = MaxHp;
        PlayerPrefs.DeleteKey("player_Password");
    }
    private void Update()
    {
        InputUpdate();
        if (moveTimer > 0)
        {
            moveTimer -= Time.deltaTime;
            return;
        }
        Vector3 targetPosition = MovementUpdate();
        RaycastHit2D hit = Physics2D.Raycast(targetPosition, Vector2.up, 0.01f);
        if (hit.collider == null)
        {
            if (targetPosition != transform.position)
            {
                rb.MovePosition(targetPosition);
            }
        }
        else if (targetPosition != transform.position && hit.collider.gameObject.layer != LayerMask.NameToLayer("Wall"))
        {
            Debug.Log("Wall touch");
            //Dotkniecie
            float direction = Input.GetAxisRaw("Horizontal");
            //Check object layer
            if ((hit.collider.gameObject.layer == LayerMask.NameToLayer("Movable")))
            {
                HandleCollisionMovable(targetPosition, hit.collider.transform, direction);
            }
            else if ((hit.collider.gameObject.layer == LayerMask.NameToLayer("Finished")))
            {
                HanldeCollisionFinish(hit);
            }
            else if ((hit.collider.gameObject.layer == LayerMask.NameToLayer("Destructable")))
            {
                HandleCollisionDestructable(targetPosition, hit);
            }
            else if ((hit.collider.gameObject.layer == LayerMask.NameToLayer("CheckPoint")))
            {
                HandleCollisionCheckPoint(targetPosition, hit);
            }
            else if ((hit.collider.gameObject.layer == LayerMask.NameToLayer("DoorButton")))
            {
                HandleCollisionDoors(targetPosition, hit);
            }
            else if ((hit.collider.gameObject.layer == LayerMask.NameToLayer("Doors")))
            {
                //this is a special case for doors, as they are not interactable directly
            }
            else if ((hit.collider.gameObject.layer == LayerMask.NameToLayer("Chest")))
            {
                HandleCollisionChests(targetPosition, hit);
            }
            else if ((hit.collider.gameObject.layer == LayerMask.NameToLayer("Computer")))
            {
                HandleCollisionComputer(hit);
            }
            else if ((hit.collider.gameObject.layer == LayerMask.NameToLayer("Collectable")))
            {
                HandleCollisionCoins(targetPosition, hit);
            }
            else
            {
                HandleCollisionNotSupported(targetPosition, hit);
            }
        }
    }

    private void InputUpdate()
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
    }

    private Vector3 MovementUpdate()
    {
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
        if (targetPosition != transform.position)
        {
            if (currentlyInteractedComputer != null)
            {
                currentlyInteractedComputer.pressEPopUp.SetActive(false);
            }
            currentlyInteractedComputer = null;
        }

        return targetPosition;
    }

    private void HandleCollisionMovable(Vector3 targetPosition, Transform objectHit, float direction)
    {
        Vector3 boxPosition = objectHit.position;
        Collider2D box = Physics2D.OverlapBox(boxPosition + Vector3.right * direction, new Vector2(0.1f, 0.1f), 0f);
        if (box == null)
        {
            moveTimer = movePushableCooldown;
            objectHit.Translate(direction, 0, 0);
            rb.MovePosition(targetPosition);
        }
    }

    private static void HanldeCollisionFinish(RaycastHit2D hit)
    {
        LevelEnd levelEnd = hit.collider.GetComponent<LevelEnd>();
        if (levelEnd != null)
        {
            levelEnd.NextLevel();
        }
    }

    private void HandleCollisionDestructable(Vector3 targetPosition, RaycastHit2D hit)
    {
        Destructable destructable = hit.collider.GetComponent<Destructable>();
        if (destructable != null)
        {
            destructable.DestroyObject();
            rb.MovePosition(targetPosition);
        }
    }

    private void HandleCollisionCheckPoint(Vector3 targetPosition, RaycastHit2D hit)
    {
        CheckPoints point = hit.collider.GetComponent<CheckPoints>();
        if (point != null)
        {
            rb.MovePosition(targetPosition);
            transform.position = point.transform.position;
            point.SaveLevel();
        }
    }

    private void HandleCollisionDoors(Vector3 targetPosition, RaycastHit2D hit)
    {
        DoorsButton doorsButton = hit.collider.GetComponent<DoorsButton>();
        if (doorsButton != null)
        {
            rb.MovePosition(targetPosition);
            transform.position = doorsButton.transform.position;
            doorsButton.TurnOn(this);
        }
    }

    private void HandleCollisionChests(Vector3 targetPosition, RaycastHit2D hit)
    {
        Chest chest = hit.collider.GetComponent<Chest>();
        if (chest != null)
        {
            rb.MovePosition(targetPosition);
            chest.OpenChest(this);
        }
    }

    private void HandleCollisionComputer(RaycastHit2D hit)
    {
        Computer computer = hit.collider.GetComponent<Computer>();
        if (computer != null)
        {
            computer.pressEPopUp.SetActive(true);
            currentlyInteractedComputer = computer;
        }
    }

    private void HandleCollisionCoins(Vector3 targetPosition, RaycastHit2D hit)
    {
        Coin coin = hit.collider.GetComponent<Coin>();
        if (coin != null)
        {
            rb.MovePosition(targetPosition);
            transform.position = coin.transform.position;
            coin.CollectCoin();
        }
    }

    private void HandleCollisionNotSupported(Vector3 targetPosition, RaycastHit2D hit)
    {
        rb.MovePosition(targetPosition);
        Debug.LogError($"[Player] Trigger Not Supported: {hit.collider.gameObject}", hit.collider.gameObject);
    }
}
