using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    void OnEnable()
    {
        GameManager.OnScoreChanged += ShowScore;
        GameManager.OnLivesChanged += ShowLives;
    }

    void OnDisable()
    {
        GameManager.OnScoreChanged -= ShowScore;
        GameManager.OnLivesChanged -= ShowLives;
    }

    void ShowScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    void ShowLives(int lives)
    {
        livesText.text = "Lives: " + lives;
    }
}