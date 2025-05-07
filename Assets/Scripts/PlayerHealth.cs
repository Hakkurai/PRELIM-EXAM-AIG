using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;

    public TextMeshProUGUI livesText;
    public string gameOverSceneName = "GameOver";

    void Start()
    {
        currentLives = maxLives;
        UpdateUI();
    }

    public void TakeDamage(int amount)
{
    currentLives -= amount;
    Debug.Log("Player took damage. Lives left: " + currentLives);
    UpdateUI();

    if (currentLives <= 0)
    {
        // SceneManager.LoadScene(gameOverSceneName);
        GameOverManager.previousSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("GameOver");

        
    }
}


    void UpdateUI()
    {
        livesText.text = "Health: " + currentLives;
    }
}
