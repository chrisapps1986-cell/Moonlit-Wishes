using UnityEngine;

public class StarCollisionEffect : MonoBehaviour
{
    public GameObject sparkleEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Score"))
        {
            GameObject sparkle = Instantiate(
                sparkleEffect,
                transform.position,
                Quaternion.identity
            );

            Destroy(sparkle, 1f);
        }
    }
}