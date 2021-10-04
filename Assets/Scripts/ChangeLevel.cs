using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public string destinationLevelName;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            SceneManager.LoadScene(destinationLevelName);
        }
    }
}
