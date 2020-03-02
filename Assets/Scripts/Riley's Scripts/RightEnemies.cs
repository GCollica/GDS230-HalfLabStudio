using UnityEngine;

public class RightEnemies : MonoBehaviour
{
    public float speed = 5f;

    private Transform target;
    private int rightWaypointIndex = 0;

    void Start()
    {
        target = RightWaypoints.rightWaypoints[0];
    }

    void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (rightWaypointIndex >= RightWaypoints.rightWaypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        rightWaypointIndex++;
        target = RightWaypoints.rightWaypoints[rightWaypointIndex];
    }
}
