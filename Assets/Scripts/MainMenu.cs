using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI bestText;

    void Start()
    {
        Time.timeScale = 1f;

        int best = PlayerPrefs.GetInt("HighScore", 0);
        bestText.text = "Best: " + best;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}