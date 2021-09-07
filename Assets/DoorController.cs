using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    Animator anim;

    void Start() {
        anim = this.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            anim.SetTrigger("OpenDoor");
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            anim.SetTrigger("CloseDoor");
        }
    }
}
