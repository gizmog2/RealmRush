using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] [Range(0, 50)] int poolSize = 5;
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 1f;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemy, transform);
            pool[i].SetActive(false);
        }
    }

    void Start()
    {
        StartCoroutine(CreateEnemy1());
    }

    void EnableObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }

        }

        /*foreach (GameObject enemy in pool)
        {
            if (enemy.activeInHierarchy == false)
            {
                enemy.SetActive(true);
                return;
            }
            
        }*/
    }
    
    IEnumerator CreateEnemy1()
    {
        while (true)
        {
            //Instantiate(enemy, transform);
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
