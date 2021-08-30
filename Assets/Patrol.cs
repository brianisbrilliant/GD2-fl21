using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{

    public Transform[] points;      // the array of patrol points

    private int destPoint = 0;      // the current point to go to
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();

        // keep it from stopping at each patrol point.
        agent.autoBraking = false;

        GoToNextPoint();
    }

    void GoToNextPoint() {
        // if no points exist
        if(points.Length == 0) {
            return;     // exit this method()
        }

        // Set the agent to go to the currently selected destination
        agent.destination = points[destPoint].position;

        // choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }

    // Update is called once per frame
    void Update()
    {
        // when the AI gets close to a destination, 
        // go to the next point
        // ! is the NOT operator
        if(!agent.pathPending && agent.remainingDistance < 0.5f) {
            GoToNextPoint();
        }
    }
}
