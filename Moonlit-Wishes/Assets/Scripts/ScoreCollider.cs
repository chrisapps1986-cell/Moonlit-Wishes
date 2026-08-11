using UnityEngine;

public class ScoreCollider : MonoBehaviour
{
    public GameManager gameManager;

    public AudioSource audioSource;
    public AudioClip caughtSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Rabbit detected: " + other.gameObject.name);

        if (other.CompareTag("Star"))
        {
            Debug.Log("Star caught!");

            gameManager.AddScore(1);

            if (audioSource != null && caughtSound != null)
            {
                audioSource.PlayOneShot(caughtSound);
            }

            Destroy(other.gameObject);
        }
    }
}