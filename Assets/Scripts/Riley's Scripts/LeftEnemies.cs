using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftEnemies : MonoBehaviour
{
    public float speed = 5f;

    private Transform target;
    private int leftWaypointIndex = 0;

    void Start()
    {
        target = LeftWaypoints.leftWaypoints[0];
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
        if (leftWaypointIndex >= LeftWaypoints.leftWaypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        leftWaypointIndex++;
        target = LeftWaypoints.leftWaypoints[leftWaypointIndex];
    }
}
