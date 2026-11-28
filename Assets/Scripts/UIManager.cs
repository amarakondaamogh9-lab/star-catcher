using UnityEngine;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI comboText;

    int lastCombo;
    int lastMultiplier = 1;
    Coroutine popRoutine;

    void OnEnable()
    {
        GameManager.OnScoreChanged += ShowScore;
        GameManager.OnLivesChanged += ShowLives;
        GameManager.OnComboChanged += ShowCombo;
    }

    void OnDisable()
    {
        GameManager.OnScoreChanged -= ShowScore;
        GameManager.OnLivesChanged -= ShowLives;
        GameManager.OnComboChanged -= ShowCombo;
    }

    void ShowScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    void ShowLives(int lives)
    {
        livesText.text = "Lives: " + lives;
    }

    void ShowCombo(int combo, int multiplier)
    {
        comboText.text = "Combo: " + combo + " (x" + multiplier + ")";

        if (combo == 0 && lastCombo > 0)
        {
            PlayPop(0.6f, Color.red);
        }
        else if (multiplier > lastMultiplier)
        {
            PlayPop(1.8f, Color.white);
        }
        else if (combo > lastCombo)
        {
            PlayPop(1.2f, Color.yellow);
        }

        lastCombo = combo;
        lastMultiplier = multiplier;
    }

    void PlayPop(float size, Color color)
    {
        if (popRoutine != null)
        {
            StopCoroutine(popRoutine);
        }
        popRoutine = StartCoroutine(ComboPop(size, color));
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
}