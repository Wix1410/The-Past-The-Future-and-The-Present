using UnityEngine;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{
    [Header("Bindings")]    
    public Slider healthSlider;
    public Player player;

    private void Start()
    {
        healthSlider.maxValue = player.MaxHp;
    }

    void Update()
    {
        healthSlider.value = player.currentHp;
    }
}
