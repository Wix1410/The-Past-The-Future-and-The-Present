using System.Collections.Generic;
using UnityEngine;

public class DoorsButton : MonoBehaviour
{
    public List<Doors> enable = new List<Doors>();
    public List<Doors> disable = new List<Doors>();
    public List<Doors> switchable = new List<Doors>();
    public List<Doors> switchableHold = new List<Doors>();
    public List<DoorItemRequirement> keyOpen = new List<DoorItemRequirement>();

    public void TurnOn(Player player)
    {
        for (int i = 0; i < enable.Count; i++)
        {
            
        }
        for (int i = 0; i < disable.Count; i++)
        {
            disable[i].Close();
        }
        for (int i = 0; i < switchable.Count; i++)
        {
            
        }
        for (int i = 0; i < switchableHold.Count; i++)
        {
            
        }
        for (int i = 0; i < keyOpen.Count; i++)
        {
            if(player.items.Contains(keyOpen[i].key))
            {
                keyOpen[i].door.Open();
                player.items.Remove(keyOpen[i].key);
            }
        }
    }
    public void TurnOff()
    {

    }
    [System.Serializable]
    public struct DoorItemRequirement
    {
        public Doors door;
        public Item key;
    }
}
