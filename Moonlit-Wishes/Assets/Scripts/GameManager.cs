using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    // References
    public int score = 0;
    public int maxLives = 3;
    public int currentLives;
    public HealthBar healthBar;
    public GameObject MainUI;
    public GameObject player;
    public GameObject gameOverUI;
    public GameObject objectSpawnerLeft;
    public GameObject objectSpawnerRight;



    public TMP_Text scoreText;

    // A boolean to track when the player reaches a score of 100
    private bool moonGoddessHeal = false;

      // We create a static instance of the game manager that can be accessed by any script from anywhere
    public static GameManager instance;

        void Awake()
    {
        // Has a GameManager been created yet?
        if(instance == null)
        {
            // This is the first game manager, store a reference to it
            instance = this;

            // Keep this game object alive throughout the life of the game
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // If a game manager already exists, then destroy this
            // Destroy(this.gameObject);
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }


    private void Start()
    {
        UpdateScoreText();
        currentLives = maxLives;
    }

    public void MissedMoonCake()
    {

        if (currentLives > 0)
        {
            currentLives--;

            if (healthBar != null)
            {
                healthBar.UpdateMoonCakesUI(currentLives);
            }
        }

        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    public void AddScore(int amount)
    {
        score += amount;

        UpdateScoreText();

        Debug.Log("" + score);

        if (score >= 100 && !moonGoddessHeal)
        {
            FillHealth();
        }
    }

    private void FillHealth()
    {
        moonGoddessHeal = true;
        currentLives = maxLives;

        if (healthBar != null)
        {
            healthBar.UpdateMoonCakesUI(currentLives);
        }
        
    }


    private void UpdateScoreText()
    {
        scoreText.text = "" + score;
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void RestartLevel()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
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
        MainUI.SetActive(false);
        player.SetActive(false);
        objectSpawnerLeft.SetActive(false);
        objectSpawnerRight.SetActive(false);
        gameOverUI.SetActive(true);
    }

}