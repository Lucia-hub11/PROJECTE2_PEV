using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsPatrolBalloon : MonoBehaviour
{
    public float Speed = 2;
    public Transform[] Waypoints;
    public float MinDistance = 0.01f;

    private int CurrentWaypointIndex;

    Transform CurrentWaypoint => Waypoints[CurrentWaypointIndex];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CloseToWaypoint())
            ChangeWaypoint();
        Move();
    }

    private bool CloseToWaypoint()
    {
        return Vector3.Distance(transform.position, CurrentWaypoint.position) < MinDistance;
    }
    private void ChangeWaypoint()
    {
        CurrentWaypointIndex++;

        if (CurrentWaypointIndex >= Waypoints.Length)
            CurrentWaypointIndex = 0;
    }

    private void Move()
    {
        transform.LookAt(CurrentWaypoint);
        transform.Translate(transform.forward * Speed * Time.deltaTime, Space.World);
    }
}
