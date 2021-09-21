using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other) 
    {
        Debug.Log(this.name + " collided with " + other.gameObject.name); // "this.name" does the same thing as "gameObject.name"
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log($"{this.name} has triggered {other.gameObject.name}"); // printing to the log using string interpolation
    }
}
