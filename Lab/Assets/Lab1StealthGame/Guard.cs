using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour {

    public Transform pathHolder;
    public float speed = 7;
    public float yieldTime = 1;
    public float turnSpeed;

    public Transform guard;

    private void Start()
    {
        StartCoroutine(GuardWalk());
    }

    IEnumerator TurnToFace(Vector3 lookTarget)
    {
        Vector3 dirToTarget = (lookTarget - guard.transform.position);
        float targetAngle = 90 - Mathf.Atan2(dirToTarget.z, dirToTarget.x) * Mathf.Rad2Deg;

        while (true)
        {
            
            
            yield return null;
        }

        
    }

    IEnumerator GuardWalk()
    {
        Transform startWaypoint = pathHolder.GetChild(0).transform;
        Transform previousWaypoint = startWaypoint;

        foreach (Transform waypoint in pathHolder)
        {
            //yield return StartCoroutine(TurnToFace(waypoint.position));
            yield return StartCoroutine(Move(guard.transform.position,waypoint.position, speed));
            yield return new WaitForSeconds(yieldTime);
            previousWaypoint = waypoint;
        }

        yield return StartCoroutine(Move(previousWaypoint.position, startWaypoint.position, speed));
        
        StartCoroutine(GuardWalk());
    }

    IEnumerator Move(Vector3 startingPosition, Vector3 destination, float speed)
    {
        while (transform.position != destination)
        {
            guard.transform.position = Vector3.MoveTowards(guard.transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 startPosition = pathHolder.GetChild(0).position;
        Vector3 previousPosition = startPosition;

        foreach (Transform waypoint in pathHolder)
        {
            Gizmos.DrawSphere(waypoint.position, .3f);
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;
        }

        Gizmos.DrawLine(previousPosition, startPosition);
    }
}
