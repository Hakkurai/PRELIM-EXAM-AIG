using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static string previousSceneName;

    public void RetryLevel()
    {
         SceneManager.LoadScene(previousSceneName);
        

    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
