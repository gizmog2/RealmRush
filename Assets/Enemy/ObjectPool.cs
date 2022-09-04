using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float spawnTimer = 1f;
    void Start()
    {
        StartCoroutine(CreateEnemy1());
    }

    
    IEnumerator CreateEnemy1()
    {
        while (true)
        {
            Instantiate(enemy, transform);
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
