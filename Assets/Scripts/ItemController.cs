using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public enum itemType {Gun, Flashlight, Banana};
    public itemType thisItem = itemType.Gun;

    public Transform bulletSpawn;
    public Rigidbody bulletPrefab;
    public float bulletSpeed = 50;

    [Header("Audio")]
    
    public AudioSource aud;
    public AudioClip gunshotClip;
    [Range(0f,1f)]
    public float gunshotVolume = .5f;

    public Light flashLight;

    Rigidbody rb;

    void Start() {
        rb = this.GetComponent<Rigidbody>();
    }

    public void Fire() {
        if(thisItem == itemType.Gun) {
            Debug.Log("Starting Fire() in itemController");
            Rigidbody bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation); 
            bullet.AddRelativeForce(Vector3.forward * bulletSpeed, ForceMode.Impulse);
            Destroy(bullet.gameObject, 4);
            aud.PlayOneShot(gunshotClip, gunshotVolume);
        }
        else if(thisItem == itemType.Flashlight) {
            // flashlight code here.
            flashLight.GetComponent<Light>().enabled = !flashLight.GetComponent<Light>().enabled;
        }
        else if(thisItem == itemType.Banana) {

        }
    }

    public void Drop() {
        this.transform.SetParent(null);
        // set rigidbody to isKinematic = false;
        rb.isKinematic = false;
        // throw item forward.
        this.transform.Translate(Vector3.forward * 1);
        rb.AddRelativeForce(Vector3.forward * 10, ForceMode.Impulse);
    }
}
