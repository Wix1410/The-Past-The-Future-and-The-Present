using UnityEngine;

public class FallCollect : Falling
{
    [Header("References")]
    public Coin coin;
    public override void OnFallOnObject(Collider2D box)
    {
        if (box != null && box.gameObject.CompareTag("Player"))
        {
            coin.CollectCoin();
        }
    }
}
