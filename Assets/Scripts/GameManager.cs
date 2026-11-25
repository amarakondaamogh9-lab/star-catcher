using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections; 

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
    Coroutine popRoutine;

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
        int oldMultiplier = GetMultiplier();
        combo++;
        int newMultiplier = GetMultiplier();

        score += amount * newMultiplier;
        UpdateUI();

        if (newMultiplier > oldMultiplier)
        {
            PlayPop(1.8f, Color.white);
        }
        else
        {
            PlayPop(1.2f, Color.yellow);
        }
    }

    public void LoseLife()
    {
        combo = 0;
        PlayPop(0.6f, Color.red);
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

    IEnumerator ComboPop(float startSize, Color flashColor)
    {
        float duration = 0.25f;
        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            float progress = t / duration;

            float size = Mathf.Lerp(startSize, 1f, progress);
            comboText.transform.localScale = Vector3.one * size;
            comboText.color = Color.Lerp(flashColor, Color.yellow, progress);

            yield return null;
        }

        comboText.transform.localScale = Vector3.one;
        comboText.color = Color.yellow;
    }

    void PlayPop(float size, Color color)
    {
        if (popRoutine != null)
        {
            StopCoroutine(popRoutine);
        }
        popRoutine = StartCoroutine(ComboPop(size, color));
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