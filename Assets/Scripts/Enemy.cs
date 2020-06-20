using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int hits = 10;

    BoxCollider enemyBoxCollider;
    ScoreBoard scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerBoxCollider()
    {
        enemyBoxCollider = gameObject.AddComponent<BoxCollider>();
        enemyBoxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        hits--;
        if (hits <= 1)
            KillEnemy();
    }

    private void ProcessHit()
    {
        scoreBoard.ScoreHit(scorePerHit);
    }

    private void KillEnemy()
    {
        print("Particles collided with enemy!" + gameObject.name);
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity); //We are putting in the position since we are instantiating the particle
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
