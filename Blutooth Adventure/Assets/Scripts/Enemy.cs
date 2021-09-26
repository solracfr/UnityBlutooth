using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    void OnParticleCollision(GameObject other) 
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity); // creates GameObject for instance of vfx; requires particle effects to "play on Awake"
        vfx.transform.parent = parent; // dumps GameObject of vfx instance to "Spawn At Runtime" GameObject
        Destroy(this.gameObject);
    }
}
