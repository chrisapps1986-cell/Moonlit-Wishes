using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public Transform[] pathPoints;
    public float moveSpeed = 2f;

    private int currentPoint = 0;

    void Update()
    {
       
        if (pathPoints == null || pathPoints.Length == 0)
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
                Destroy(gameObject);
                return;
            }
        }
    }
}