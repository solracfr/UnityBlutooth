using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int enemyScoreValue;

    ScoreBoard scoreBoard; // so script class names can be used as var types!!!

    void Start() 
    {
        scoreBoard = FindObjectOfType<ScoreBoard>(); // resource intensive and risky, but we can safely use here because there is only one scoreboard to refer to, and not many enemies appear
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        KillEnemy();
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity); // creates GameObject for instance of vfx; requires particle effects to "play on Awake"
        vfx.transform.parent = parent; // dumps GameObject of vfx instance to "Spawn At Runtime" GameObject
        Destroy(this.gameObject);
    }

    private void ProcessHit()
    {
        scoreBoard.IncreaseScore(enemyScoreValue);
    }
}
