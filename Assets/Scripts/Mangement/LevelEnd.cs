using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public string levelToLoad;
    public void NextLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
