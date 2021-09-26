using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float delayBeforeDestroy = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, delayBeforeDestroy);   
    }
}
