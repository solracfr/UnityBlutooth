using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] GameObject parentGameObject;
    [SerializeField] int enemyScoreValue;
    [SerializeField] int enemyHP;
    ScoreBoard _scoreBoard; // so script class names can be used as var types!!!
    Rigidbody _rigidbody;

    void Start()
    {
        _scoreBoard = FindObjectOfType<ScoreBoard>(); // resource intensive and risky, 
                                                      // but we can safely use here because there is only one scoreboard to refer to, and not many enemies appear
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        //AddRigidBody(); // currently unused.
    }

    void AddRigidBody()
    {
        _rigidbody = this.gameObject.AddComponent<Rigidbody>();
        _rigidbody.useGravity = false;
        _rigidbody.isKinematic = true;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (enemyHP < 1) // you could get in trouble if you have a strict condition like == 0
            KillEnemy();
    }

    void KillEnemy()
    {
        TriggerVFX(deathFX);
        Destroy(this.gameObject);
        _scoreBoard.IncreaseScore(enemyScoreValue); 
    }

    void ProcessHit()
    {
        enemyHP--;
        TriggerVFX(hitVFX);
    }

    void TriggerVFX(GameObject FX)
    {
        GameObject fx = Instantiate(FX, transform.position, Quaternion.identity); // creates GameObject for instance of vfx; requires particle effects to "play on Awake"
        fx.transform.parent = parentGameObject.transform; // dumps GameObject of vfx instance to "Spawn At Runtime" GameObject
                                                 // use Transforms to nest GameObjects into parents
    }
}
