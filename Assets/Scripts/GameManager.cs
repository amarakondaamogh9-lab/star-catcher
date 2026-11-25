using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI comboText;
    public GameObject gameOverPanel;
    public int lives = 3;

    int score;
    float survivalTime; 
    int combo;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;
        gameOverPanel.SetActive(false);
        UpdateUI();
    }

    void Update()
    {
        survivalTime += Time.deltaTime;

        int minutes = (int)survivalTime / 60;
        int seconds = (int)survivalTime % 60;

        timerText.text = $"{minutes}:{seconds:00}";
    }

    public void AddScore(int amount)
    {
        combo++;
        score += amount * GetMultiplier();
        UpdateUI();
    }

    public void LoseLife()
    {
        combo = 0;
        lives--;
        comboText.text = "Combo: " + combo + " (x" + GetMultiplier() + ")";
        UpdateUI();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void AddLife()
    {
        lives++;
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
        comboText.text = "Combo: " + combo + " (x" + GetMultiplier() + ")";
    }

    int GetMultiplier()
    {
        if (combo >= 20)
        {
            return 5;
        }
        else if (combo >= 10)
        {
            return 3;
        }
        else if (combo >= 5)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);

        int best = PlayerPrefs.GetInt("HighScore", 0);
        if (score > best)
        {
            best = score;
            PlayerPrefs.SetInt("HighScore", best);
        }
        highScoreText.text = "High Score: " + best + "\nTime: " + timerText.text;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}