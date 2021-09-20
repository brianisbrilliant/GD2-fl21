using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimPatrol : MonoBehaviour
{

    public Animator anim;
    public Transform[] points;      // the array of patrol points

    public Transform target;        // this is the player.
    public float detectionDistance = 10f;

    private int destPoint = 0;      // the current point to go to
    private NavMeshAgent agent;

    private bool waiting = false;
    private bool startAttacking = false;
    private bool stopAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting Start()");
        agent = this.GetComponent<NavMeshAgent>();

        // // keep it from stopping at each patrol point.
        // agent.autoBraking = false;

        StartCoroutine(GoToNextPoint());
    }

    IEnumerator GoToNextPoint() {
        Debug.Log("Starting GoToNextPoint()");
        // if no points exist
        if(points.Length == 0) {
            yield return new WaitForEndOfFrame();     // exit this method()
        }

        // wait here for 2 seconds
        Debug.Log("Starting to wait.");
        waiting = true;
        // agent.destination = this.transform.position;
        yield return new WaitForSeconds(2);
        waiting = false;
        Debug.Log("Done Waiting, going to next point.");

        // Set the agent to go to the currently selected destination
        agent.destination = points[destPoint].position;

        // choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", agent.velocity.magnitude);
        anim.SetBool("Attacking", startAttacking);

        // when the AI gets close to a destination, 
        // go to the next point
        // ! is the NOT operator

        float distanceFromTarget = Vector3.Distance(target.position, this.transform.position);

        if(distanceFromTarget < detectionDistance && startAttacking == false) {
            Debug.Log("<color=yellow>I see the target!</color>");
            // stop patrolling, follow target
            startAttacking = true;
            stopAttacking = false;      //reset
            // start following the player
        }

        // if the target is far away
        if(distanceFromTarget > detectionDistance * 1.5f && stopAttacking == false){
            Debug.Log("<color=cyan>Stop attacking!</color>");
            stopAttacking = true;
            startAttacking = false;         // reset
        }

        if(startAttacking) {
            agent.destination = target.position;
        }
    
        // if player is close (vector3.distance), agent.dest = player
        // else if, do the following stuff.
        else if(!agent.pathPending && agent.remainingDistance < 0.5f && !waiting) {
            StartCoroutine(GoToNextPoint());
        }

    }
}
