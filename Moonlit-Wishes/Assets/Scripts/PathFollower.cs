using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public Transform[] pathPoints;
    public float speed = 3f;
    public float reachDistance = 0.05f;

    private int currentPointIndex = 0;

    private void Update()
    {
        if (pathPoints == null || pathPoints.Length == 0)
        {
            return;
        }

        Transform targetPoint = pathPoints[currentPointIndex];

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPoint.position,
            speed * Time.deltaTime
        );

        float distanceToTarget = Vector3.Distance(transform.position, targetPoint.position);

        if (distanceToTarget <= reachDistance)
        {
            currentPointIndex++;

            if (currentPointIndex >= pathPoints.Length)
            {
                Destroy(gameObject);
            }
        }
    }
}