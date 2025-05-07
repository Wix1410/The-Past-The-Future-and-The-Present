
using UnityEngine;


public class Destructable : MonoBehaviour
{
    public void DestroyObject()
    {
        gameObject.SetActive(false);
    }
}
