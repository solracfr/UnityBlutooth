using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadLevelDelay = 1f;

    private string reloadLevel = "ReloadLevel";

    // Start is called before the first frame update
    void OnCollisionEnter(Collision other) 
    {
        Debug.Log(this.name + " collided with " + other.gameObject.name); // "this.name" does the same thing as "gameObject.name"
        GetComponent<PlayerControls>().enabled = false;
        Invoke(reloadLevel, loadLevelDelay); // remember that method name should be a string
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(1); // change number arg to something else later
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log($"{this.name} has triggered {other.gameObject.name}"); // printing to the log using string interpolation
    }
}
