using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    BoxCollider enemyBoxCollider;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
    }

    private void AddNonTriggerBoxCollider()
    {
        enemyBoxCollider = gameObject.AddComponent<BoxCollider>();
        enemyBoxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        print("Particles collided with enemy!" + gameObject.name);
        GameObject fx = Instantiate(deathFX,transform.position, Quaternion.identity); //We are putting in the position since we are instantiating the particle
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
