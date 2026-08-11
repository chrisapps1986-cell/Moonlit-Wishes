using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // References
    public int score = 0;
    public int maxLives = 3;
    public int currentLives;

    public float waitForGoddessDespawn = 5f;

    public HealthBar healthBar;

    public GameObject MainUI;
    public GameObject player;
    public GameObject gameOverUI;

    public GameObject objectSpawnerLeft;
    public GameObject objectSpawnerRight;

    // Missed star sound
    public AudioSource audioSource;
    public AudioClip missedSound;
    public AudioClip moonGoddessSound;

    // Main Menu UI references
    public GameObject MainMenuUI;
    public GameObject AboutTheGameUI;
    public GameObject HowToPlayUI;
    public GameObject CreditsUI;

    // Moon Goddess reference
    public GameObject MoonGoddess;

    public TMP_Text scoreText;

    // Tracks the health refill
    private bool moonGoddessHeal = false;

    // Allows other scripts to access the GameManager
    public static GameManager instance;


    void Awake()
    {
        // Has a GameManager been created yet?
        if (instance == null)
        {
            // This is the first GameManager
            instance = this;

            // Keep it alive between scenes
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // Replace the old GameManager
            Destroy(instance.gameObject);

            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
    }


    private void Start()
    {
        // Make sure the game is running normally
        Time.timeScale = 1f;
        AudioListener.pause = false;

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


        if (currentLives == 1)
        {
            GoddessAppear();
        }


        if (currentLives <= 0)
        {
            GameOver();
        }
    }


    public void PlayMissedSound()
    {
        if (audioSource != null && missedSound != null)
        {
            audioSource.PlayOneShot(missedSound);
        }
    }

    public void PlayMoonGoddessSound()
    {
        if (audioSource != null && moonGoddessSound != null)
        {
            audioSource.PlayOneShot(moonGoddessSound);
        }
    }



    public void AddScore(int amount)
    {
        score += amount;

        UpdateScoreText();

        Debug.Log("" + score);


        if (score % 100 == 0 && !moonGoddessHeal)
        {
            FillHealth();

            GoddessAppear();
            PlayMoonGoddessSound();

            StartCoroutine(WaitGoddessDissapear());
        }
        else
        {
            moonGoddessHeal = false;
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


    private void GoddessAppear()
    {
        MoonGoddess.SetActive(true);
    }


    IEnumerator WaitGoddessDissapear()
    {
        yield return new WaitForSeconds(waitForGoddessDespawn);

        GoddessDissapear();
    }


    private void GoddessDissapear()
    {
        MoonGoddess.SetActive(false);
    }


    private void UpdateScoreText()
    {
        scoreText.text = "" + score;
    }


    public void StartGame()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;

        SceneManager.LoadScene(1);
    }


    public void RestartLevel()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }


    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


    public void ExitBackToMenu()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;

        SceneManager.LoadScene(0);
    }


    public void GameOver()
    {
        MainUI.SetActive(false);

        player.SetActive(false);

        objectSpawnerLeft.SetActive(false);
        objectSpawnerRight.SetActive(false);

        gameOverUI.SetActive(true);


        Time.timeScale = 0f;

        AudioListener.pause = true;
    }


    public void AboutTheGame()
    {
        MainMenuUI.SetActive(false);

        AboutTheGameUI.SetActive(true);
    }


    public void BackButtonAboutTheGame()
    {
        AboutTheGameUI.SetActive(false);

        MainMenuUI.SetActive(true);
    }

    public void Credits()
    {
        MainMenuUI.SetActive(false);

        CreditsUI.SetActive(true);
    }

    public void BackButtonCredits()
    {
        CreditsUI.SetActive(false);

        MainMenuUI.SetActive(true);
    }


    public void HowToPlay()
    {
        MainMenuUI.SetActive(false);

        HowToPlayUI.SetActive(true);
    }


    public void BackButtonHowToPlay()
    {
        HowToPlayUI.SetActive(false);

        MainMenuUI.SetActive(true);
    }
}