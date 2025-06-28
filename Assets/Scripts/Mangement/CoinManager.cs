using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [Header("Audio")]

    public static CoinManager Instance;

    public TMP_Text coinCountText;

    public int coinCount = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        coinCountText.SetText(coinCount.ToString());
    }
    public void AddCoins(int count)
    {
        coinCount += count;
        coinCountText.SetText(coinCount.ToString());
    }
    public void ResetCoin()
    {
        coinCount = 0;
        coinCountText.SetText(coinCount.ToString());
    }
}
