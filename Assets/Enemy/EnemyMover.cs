using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
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

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

        foreach(GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<Waypoint>());
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
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
	    gameObject.SetActive(false);
	    enemy.SteelGold();
    }
}
