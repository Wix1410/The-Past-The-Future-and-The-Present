using UnityEngine;

public class Chest : MonoBehaviour
{
    [Header("Settings")]
    public Item item = Item.None;

    [Header("References")]
    public SpriteRenderer spriteRenderer;
    public Sprite openSprite;
    public Sprite closedSprite;

    private void Start()
    {
        RefreshSprite();
    }

    public void RefreshSprite()
    {
        if (item == Item.None)
        {
            spriteRenderer.sprite = openSprite;
        }
        else
        {
            spriteRenderer.sprite = closedSprite;
        }
    }

    public void OpenChest(Player player)
    {
        if (item == Item.None)
        {
            return;
        }
        // Logic to open the chest, e.g., play an animation, give items, etc.
        player.items.Add(item);
        item = Item.None; // Remove the item from the chest after opening
        RefreshSprite(); // Update the sprite to show the chest is empty
    }
    private void OnDrawGizmosSelected()
    {
        RefreshSprite();
    }
}