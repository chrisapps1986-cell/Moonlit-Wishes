using System.Collections;
using UnityEngine;

public class PathObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform[] pathPoints;
    public float[] spawnDelays;

    private int currentDelay = 0;

    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelays[currentDelay]);

            if (pathPoints!= null && pathPoints.Length > 0)
            {
                GameObject newObject = Instantiate(
                    objectToSpawn,
                    pathPoints[0].position,
                    Quaternion.identity
                );

                PathFollower pathFollower = newObject.GetComponent<PathFollower>();

                if (pathFollower != null)
                {
                    pathFollower.SetupPath(pathPoints);
                }
                
            }

            currentDelay++;
           
            if (currentDelay == spawnDelays.Length)
            {
                currentDelay = 0;
            }

        
        }
    }
}