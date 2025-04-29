
using System.Collections.Generic;
using UnityEngine;

public class Saveble : MonoBehaviour
{
    public static List<Saveble> savebles = new List<Saveble>();
   
    public int id;

    private void Awake()
    {
        savebles.Add(this);
    }

    private void OnDestroy()
    {
        savebles.Remove(this);
    }

    public void Save()
    {
        string key = "saveble_" + id + "_";
        PlayerPrefs.SetInt(key + "active", gameObject.activeSelf ? 1 : 0);
        PlayerPrefs.SetFloat(key + "position_x", transform.position.x);
        PlayerPrefs.SetFloat(key + "position_y", transform.position.y);
    }

    public void Load()
    {
        string key = "saveble_" + id + "_";
        if (PlayerPrefs.HasKey(key + "active"))
        {
            gameObject.SetActive(PlayerPrefs.GetInt(key + "active") == 1);
        }
        if (PlayerPrefs.HasKey(key + "position_x") && PlayerPrefs.HasKey(key + "position_y"))
        {
            Vector3 position = new Vector3(PlayerPrefs.GetFloat(key + "position_x"), PlayerPrefs.GetFloat(key + "position_y"));
            transform.position = position;
        }
    }

    public static void SaveAll()
    {
        foreach (var saveble in savebles)
        {
            saveble.Save();
        }
    }

    public static void LoadAll()
    {
        foreach (var saveble in savebles)
        {
            saveble.Load();
        }
    }
}
