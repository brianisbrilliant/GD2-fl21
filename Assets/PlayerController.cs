using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform bulletSpawn;
    public Rigidbody bulletPrefab;
    public float bulletSpeed = 50;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            Fire();
        }
    }

    void Fire() {
        Rigidbody bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation); 
        bullet.AddRelativeForce(Vector3.forward * bulletSpeed, ForceMode.Impulse);
        Destroy(bullet.gameObject, 4);
    }
}
