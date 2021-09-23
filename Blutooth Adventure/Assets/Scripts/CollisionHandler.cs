using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadLevelDelay = 1f;

    private string reloadLevel = "ReloadLevel";


    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"{this.name} has triggered {other.gameObject.name}"); // printing to the log using string interpolation

        StartCrashSequence();
    }

    private void StartCrashSequence()
    {
        GetComponent<PlayerControls>().enabled = false;
        Invoke(reloadLevel, loadLevelDelay); // remember that method name should be a string
    }

    void ReloadLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentLevel);
    }
}
