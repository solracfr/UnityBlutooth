using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake() 
    {
        // if there's any other music players playing, don't spawn a new one
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;

        if (numMusicPlayers > 1)
            Destroy(this.gameObject);
        else 
            DontDestroyOnLoad(this.gameObject);
    }
}
