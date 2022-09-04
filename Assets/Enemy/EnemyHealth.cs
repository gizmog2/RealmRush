using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    int currentHitPoints = 0;
    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
        //AddRigidbody();

    }

    /*private void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }*/

   

    void ProcessHit()
    {
        currentHitPoints--;
        Debug.Log(currentHitPoints);
        if (currentHitPoints <= 0)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }
}
