using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    ItemController item;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            Debug.Log("Mouse0 presed!");
            if(item != null) {
                Debug.Log("Calling item.Fire()");
                item.Fire();
            }
        }

        if(Input.GetKeyDown(KeyCode.Q)) {
            Debug.Log("Q pressed.");
            if(item != null) {
                item.Drop();
                item = null;
            }
        }
    }

    public Transform hand;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Pickupable")) {
            if(item == null) {
                // we can pick up the object!
                item = other.gameObject.GetComponent<ItemController>();
                // move the object to our hand.
                other.gameObject.transform.position = hand.position;
                // make the object a child of the hand so it follows.
                other.gameObject.transform.SetParent(hand);
                // make the object face the same direction as the hand.
                other.gameObject.transform.rotation = hand.rotation;
                // keep the gun from falling
                other.GetComponent<Rigidbody>().isKinematic = true;
            }
            else {
                Debug.Log("Already holding something.");
            }
        }
    }
}
