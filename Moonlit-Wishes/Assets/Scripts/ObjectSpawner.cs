using System.Collections;
using UnityEngine;

public class PathObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform[] pathPoints;
    public float[] spawnDelays;

    private int delayIndex = 0;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelays[delayIndex]);

            GameObject newObject = Instantiate(objectPrefab, pathPoints[0].position, Quaternion.identity);

            newObject.GetComponent<PathFollower>().pathPoints = pathPoints;

            delayIndex++;

            if (delayIndex >= spawnDelays.Length)
            {
                delayIndex = 0;
            }
        }
    }
}