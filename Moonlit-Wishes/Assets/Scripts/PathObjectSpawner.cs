using System.Collections;
using UnityEngine;

public class PathObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform[] pathPoints;

    public float minimumSpawnDelay = 1f;
    public float maximumSpawnDelay = 3f;

    public float minimumGapBetweenStars = 1.5f;

    public float spinSpeed = 200f;

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

            while (Time.time < nextAllowedSpawnTime)
            {
                yield return null;
            }

            SpawnStar();

            nextAllowedSpawnTime =
                Time.time + minimumGapBetweenStars;
        }
    }

    void SpawnStar()
    {
        GameObject newStar = Instantiate(
            objectPrefab,
            pathPoints[0].position,
            Quaternion.identity
        );

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