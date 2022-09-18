using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Tile> path = new List<Tile>();
	[SerializeField][Range(0, 2)] float speed = 1f;
    
	Enemy enemy;
	
    // Start is called before the first frame update
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());        
        //PrintWaypointName();
        //InvokeRepeating("PrintWaypointName", 0, 1f);
    }
    
	void Start()
	{
		enemy = GetComponent<Enemy>();
	}

    void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        //foreach(GameObject waypoint in waypoints)
        foreach (Transform child in parent.transform)
        {
            Tile waypoint = (child.GetComponent<Tile>());

            if (waypoint != null)
            {
                path.Add(waypoint);
            }
            
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        gameObject.SetActive(false);
        enemy.SteelGold();
    }

    IEnumerator FollowPath()
    {
        foreach (Tile waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
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
