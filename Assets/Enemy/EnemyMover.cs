using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField][Range(0, 2)] float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {        
        StartCoroutine(FollowPath());        
        //PrintWaypointName();
        //InvokeRepeating("PrintWaypointName", 0, 1f);
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);  // направление в которое смотрит обьект

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
    }
}
