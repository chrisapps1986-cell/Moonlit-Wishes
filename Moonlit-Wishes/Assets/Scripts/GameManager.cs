using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;
    public bool gameOver = false;

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }

    public void LoseLife()
    {
        lives--;

        if (lives <= 0)
        {
            GameOver();
        }
    }

    // Start game using the scene manager
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }


    // Exit the game when the Exit Button is pressed
    public void ExitGame()
    {

// For exiting the game in the Unity Editor to test if the button is working
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
// Actual code to Quit the game when the Exit Button is pressed for when the game is an exe file
        Application.Quit();
#endif 
    }



    public void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over!");
    }
}