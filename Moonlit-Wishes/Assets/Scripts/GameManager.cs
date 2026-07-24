using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;
    public bool gameOver = false;

    public TMP_Text scoreText;

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;

        UpdateScoreText();

        Debug.Log("" + score);
    }

    private void UpdateScoreText()
    {
        scoreText.text = "" + score;
    }

    public void LoseLife()
    {
        lives--;

        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over!");
    }
}