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
            }
        }
    }
}
