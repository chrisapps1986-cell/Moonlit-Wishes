using System.Collections;
using UnityEngine;

public class PathObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform[] pathPoints;

    public GameObject spawnSparkleEffect;

    public float minimumSpawnDelay = 1f;
    public float maximumSpawnDelay = 3f;

    public float minimumGapBetweenStars = 1.5f;

    public float spinSpeed = 200f;

    public float spawnRateIncrease = 0.02f;

    public float fastestMinimumDelay = 0.3f;
    public float fastestMaximumDelay = 0.8f;
    public float smallestGapBetweenStars = 0.5f;

    private static float nextAllowedSpawnTime = 0f;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            float randomDelay = Random.Range(
                minimumSpawnDelay,
                maximumSpawnDelay
            );

            yield return new WaitForSeconds(randomDelay);

            if (Time.time < nextAllowedSpawnTime)
            {
                continue;
            }

            SpawnStar();

            nextAllowedSpawnTime =
                Time.time + minimumGapBetweenStars;

            minimumSpawnDelay -= spawnRateIncrease;
            maximumSpawnDelay -= spawnRateIncrease;
            minimumGapBetweenStars -= spawnRateIncrease;

            minimumSpawnDelay =
                Mathf.Max(minimumSpawnDelay, fastestMinimumDelay);

            maximumSpawnDelay =
                Mathf.Max(maximumSpawnDelay, fastestMaximumDelay);

            minimumGapBetweenStars =
                Mathf.Max(minimumGapBetweenStars, smallestGapBetweenStars);
        }
    }

    void SpawnStar()
    {
        GameObject newStar = Instantiate(
            objectPrefab,
            pathPoints[0].position,
            Quaternion.identity
        );

        if (spawnSparkleEffect != null)
        {
            GameObject sparkle = Instantiate(
                spawnSparkleEffect,
                newStar.transform.position,
                Quaternion.identity
            );

            Destroy(sparkle, 1f);
        }

        PathFollower pathFollower =
            newStar.GetComponent<PathFollower>();

        if (pathFollower != null)
        {
            pathFollower.SetupPath(pathPoints);
        }

        Rigidbody2D rb =
            newStar.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.angularVelocity = spinSpeed;
        }
    }
}