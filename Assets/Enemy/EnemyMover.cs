﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{    
	[SerializeField][Range(0, 2)] float speed = 1f;
    List<Node> path = new List<Node>();

    Enemy enemy;
    GridManager gridManager;
    Pathfinding pathfinding;
	
    // Start is called before the first frame update
    void OnEnable()
    {
        RecalculatePath();
        ReturnToStart();
        StartCoroutine(FollowPath());
        //PrintWaypointName();
        //InvokeRepeating("PrintWaypointName", 0, 1f);
    }
    
	void Awake()
	{       
        enemy = GetComponent<Enemy>();
        gridManager = FindObjectOfType<GridManager>();
        pathfinding = FindObjectOfType<Pathfinding>();
	}

    void RecalculatePath()
    {
        path.Clear();
        path = pathfinding.GetNewPath();        
    }

    void ReturnToStart()
    {
        transform.position = gridManager.GetPositionFromCoordinates(pathfinding.StartCoordinates);
    }

    void FinishPath()
    {
        gameObject.SetActive(false);
        enemy.SteelGold();
    }

    IEnumerator FollowPath()
    {
        for (int i = 0; i < path.Count; i++)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = gridManager.GetPositionFromCoordinates(path[i].coordinates);
            float travelPercent = 0f;

            transform.LookAt(endPosition);  // Смотреть в определеннм направлении. 

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime*speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }

            //transform.position = waypoint.transform.position;
            //Debug.Log(waypoint.name);            
            //yield return new WaitForSeconds(waitTime);
        }

        //Destroy(gameObject);
        FinishPath();
    }
}
