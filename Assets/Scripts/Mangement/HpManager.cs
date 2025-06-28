using UnityEngine;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{
    [Header("Bindings")]    
    public Slider helthSlider;
    public Player player;

    void Update()
    {
        helthSlider.value = player.currentHp;
    }
}
