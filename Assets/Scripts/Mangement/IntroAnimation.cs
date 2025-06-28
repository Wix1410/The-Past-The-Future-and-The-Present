using UnityEngine;

public class IntroAnimation : MonoBehaviour
{
    [Header("Movement")]
    public float moveCooldown = 0.5f;

    [Header("Bindings")]
    public Player player;
    public CheckPoints startCheckpoint;
    public Transform camera;
    public Transform endPosition;
    public Doors startDoors;
    public GameObject playerUI;

    private float moveTimer = 0f;

    private void Start()
    {
        player.enabled = false;
        playerUI.SetActive(false);
    }

    void Update()
    {
        if (moveTimer > 0)
        {
            moveTimer -= Time.deltaTime;
            return;
        }
        moveTimer = moveCooldown;
        transform.Translate(1, 0, 0);
        float distance = Vector3.Distance(transform.position, endPosition.position);
        if(distance <= 0.5f)
        {
            this.enabled = false;
        }
    }

    private void OnDisable()
    {
        startCheckpoint.SaveLevel();
        camera.SetParent(player.transform);
        player.enabled = true;
        startDoors.Close();
        playerUI.SetActive(true);
    }
}
