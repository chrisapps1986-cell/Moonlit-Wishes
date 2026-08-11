using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public Transform[] pathPoints;

    public float startingSpeed = 2f;
    public float speedIncreasePerSecond = 0.05f;
    public float maximumSpeed = 6f;

    public GameObject missedSparkleEffect;

    private int currentPoint = 0;
    private bool isInitialized = false;


    public void SetupPath(Transform[] masterPoints)
    {
        pathPoints = masterPoints;
        currentPoint = 0;

        if (pathPoints != null && pathPoints.Length > 0)
        {
            transform.position = pathPoints[0].position;
            isInitialized = true;
        }
    }


    void Update()
    {
        if (!isInitialized ||
            pathPoints == null ||
            pathPoints.Length == 0)
        {
            return;
        }

        if (pathPoints[currentPoint] == null)
        {
            return;
        }


        float currentSpeed =
            startingSpeed +
            Time.timeSinceLevelLoad * speedIncreasePerSecond;

        currentSpeed = Mathf.Min(
            currentSpeed,
            maximumSpeed
        );


        transform.position = Vector3.MoveTowards(
            transform.position,
            pathPoints[currentPoint].position,
            currentSpeed * Time.deltaTime
        );


        if (Vector3.Distance(
            transform.position,
            pathPoints[currentPoint].position
        ) < 0.1f)
        {
            currentPoint++;


            if (currentPoint >= pathPoints.Length)
            {
                // Create the dark sparkle effect
                if (missedSparkleEffect != null)
                {
                    GameObject sparkle = Instantiate(
                        missedSparkleEffect,
                        transform.position,
                        Quaternion.identity
                    );

                    Destroy(sparkle, 1f);
                }


                // Lose health and play the missed sound
                if (GameManager.instance != null)
                {
                    GameManager.instance.MissedMoonCake();

                    GameManager.instance.PlayMissedSound();
                }


                // Remove the missed star
                Destroy(gameObject);
            }
        }
    }
}