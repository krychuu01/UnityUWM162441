using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad3_lab5 : MonoBehaviour
{
    [SerializeField]
    private List<Vector3> waypoints;
    public float moveSpeed = 3f;
    private int currentWaypointIndex = 0;
    private bool movingForward = true;

    void Update()
    {
        if (waypoints.Count == 0) return;

        Vector3 targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, moveSpeed * Time.deltaTime);
        Debug.Log("obecny waypoint: " + currentWaypointIndex);

        if (transform.position == targetWaypoint)
        {
            if (movingForward)
            {
                if (currentWaypointIndex < waypoints.Count - 1)
                {
                    currentWaypointIndex++;
                }
                else
                {
                    movingForward = false;
                }
            }
            else
            {
                if (currentWaypointIndex > 0)
                {
                    currentWaypointIndex--;
                }
                else
                {
                    movingForward = true;
                }
            }
        }
    }
}
