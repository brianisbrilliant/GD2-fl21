using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour
{
    public int health = 10;

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Bullet")) {
            health -= 1;
            if(health <= 0) {
                // destroy navmesh parent
                // Destroy(this.transform.parent.gameObject);      // if this is the hip, destroy NavMeshAgent parent. 
                Destroy(this.gameObject, 2);       // if this is the NavMeshAgent, destroy this gameobject.
                Destroy(this.GetComponent<UnityEngine.AI.NavMeshAgent>());

                // make a list of components
                Component[] rigidbodies;

                // get all of the rigidbody components in all of the children of this object
                rigidbodies = GetComponentsInChildren<Rigidbody>();

                // do this to each rigidbody in the list of rigidbodies.
                foreach(Rigidbody rb in rigidbodies) {
                    // make it an orphan (no parents)
                    rb.transform.SetParent(null);
                    // let gravity mess with it
                    rb.isKinematic = false;
                    // add force in random direction
                    rb.AddRelativeForce(Random.Range(-1,1), Random.Range(-1,1), Random.Range(-1,1), ForceMode.Impulse);
                }
            }
        }
    }
}
