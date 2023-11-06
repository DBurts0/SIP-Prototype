using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    public GameObject wayPoint1;
    public GameObject wayPoint2;
    public GameObject wayPoint3;
    public GameObject currentWaypoint;
    public GameObject[] patrolRoute;

    // Variable for direction to the next waypoint
    public Vector3 targetDirection;
    private CharacterData data;
    private CharacterController controller;
    private CharacterMovement movement;
    public Vector3 currentWaypointPosition;
    // Start is called before the first frame update
    void Start()
    {
        
        currentWaypoint = patrolRoute[0];
        currentWaypointPosition = currentWaypoint.transform.position;
        data = GetComponent<CharacterData>();
        controller = GetComponent<CharacterController>();
        movement = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
            //Move and rotate towards the current waypoint
            RotateTo(currentWaypointPosition, data.turnSpeed);
            MoveTo(currentWaypointPosition, data.moveSpeed);
            // If the enemy reaches their waypoint change their new goal to the next waypoint
            if (transform.position == currentWaypointPosition)
            {
                if (currentWaypoint == patrolRoute[0])
                {
                    currentWaypoint = patrolRoute[1];
                    currentWaypointPosition = currentWaypoint.transform.position;
                }
                else if (currentWaypoint == patrolRoute[1])
                {
                    currentWaypoint = patrolRoute[2];
                    currentWaypointPosition = currentWaypoint.transform.position;
            }
                else if (currentWaypoint == patrolRoute[2])
                {
                    currentWaypoint = patrolRoute[0];
                    currentWaypointPosition = currentWaypoint.transform.position;
            }
            }
        
    }

    void RotateTo(Vector3 target, float speed)
    {
        // Get the direction of the target
        targetDirection = target - transform.position;
        // Rotate towards the target over time
        Quaternion rotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, speed * Time.deltaTime);
    }

    void MoveTo(Vector3 target, float speed)
    {
        // Move towards the target
        transform.position = Vector3.MoveTowards(transform.position, target, speed * 0.5f * Time.deltaTime);
    }


}
