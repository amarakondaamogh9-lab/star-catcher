using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static event Action<int> OnScoreChanged;
    public static event Action<int> OnLivesChanged;
    public static event Action<int, int> OnComboChanged;
    public static event Action<float> OnTimeChanged;
    public static event Action<int, int, float> OnGameOver;

    public int lives = 3;
    public bool isGameOver;

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
        UpdateUI();
    }

    void Update()
    {
        survivalTime += Time.deltaTime;
        OnTimeChanged?.Invoke(survivalTime);
    }

    public void AddScore(int amount)
    {
        combo++;
        score += amount * GetMultiplier();
        UpdateUI();
    }

    public void AddLife()
    {
        lives++;
        UpdateUI();
    }

    public void LoseLife()
    {
        combo = 0;
        lives--;
        UpdateUI();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void UpdateUI()
    {
        OnScoreChanged?.Invoke(score);
        OnLivesChanged?.Invoke(lives);
        OnComboChanged?.Invoke(combo, GetMultiplier());
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
        isGameOver = true;
        Time.timeScale = 0f;

        int best = PlayerPrefs.GetInt("HighScore", 0);

        if (score > best)
        {
            best = score;
            PlayerPrefs.SetInt("HighScore", best);
        }

        OnGameOver?.Invoke(score, best, survivalTime);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}