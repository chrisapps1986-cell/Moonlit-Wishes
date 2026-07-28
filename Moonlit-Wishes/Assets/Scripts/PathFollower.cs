using Microsoft.Extensions.Logging.Abstractions;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public Transform[] pathPoints;
    public float moveSpeed = 2f;

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

        if (!isInitialized || pathPoints == null || pathPoints.Length == 0)
        {
            return;
        }

        if (pathPoints[currentPoint] == null)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            pathPoints[currentPoint].position,
            moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(
            transform.position,
            pathPoints[currentPoint].position
        ) < 0.1f)
        {
            currentPoint++;

            if (currentPoint >= pathPoints.Length)
            {
                if (GameManager.instance != null)
                {
                    GameManager.instance.MissedMoonCake();
                }
                
                Destroy(gameObject);
                return;
            }
        }
    }
}