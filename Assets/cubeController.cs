using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("I exist!");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)) {
            this.transform.Rotate(0,0,10 * Time.deltaTime);
        }
    }
}
