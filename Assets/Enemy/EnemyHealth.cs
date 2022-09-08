using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;

    [Tooltip("Add amount to maxHitPoints when the enemy dies.")]
    [SerializeField] int difficultyRamp = 1;
	int currentHitPoints = 0;
	Enemy enemy;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
        //AddRigidbody();

    }
    
	void Start()
	{
		enemy = GetComponent<Enemy>();
	}

    /*private void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }*/

   

    void ProcessHit()
    {
        currentHitPoints--;
        
        if (currentHitPoints <= 0)
        {
            //Destroy(gameObject);
	        gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
	        enemy.RewardGold();
        }
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }
}
