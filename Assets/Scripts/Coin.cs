using UnityEngine;

public class Coin : MonoBehaviour
{
    public void CollectCoin()
    {
        CoinManager.Instance.AddCoins(1);
        Destroy(gameObject);
    }
}
