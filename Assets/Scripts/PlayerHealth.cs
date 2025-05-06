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
        UpdateUI();

        if (currentLives <= 0)
        {
            SceneManager.LoadScene(gameOverSceneName);
        }
    }

    void UpdateUI()
    {
        livesText.text = "Lives: " + currentLives;
    }
}
