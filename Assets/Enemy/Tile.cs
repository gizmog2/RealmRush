using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;

    public bool IsPlaceable { get { return isPlaceable; } }

    GridManager gridManager;
    Pathfinding pathfinder;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinding>();
    }

    void Start()
    {
        pathfinder.NotifyReceivers();
        if (gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if (!IsPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }
    /*public bool GetIsPlaceble()
    {
        return isPlaceable;
    }*/
    void OnMouseDown()
    {
        if (gridManager.GetNode(coordinates).isWalkable && !pathfinder.WillBlockPath(coordinates))
        {
            bool isSuccessful = towerPrefab.CreateTower(towerPrefab, transform.position);
            //Instantiate(towerPrefab, transform.position, Quaternion.identity);
            if (isSuccessful)
            {
                gridManager.BlockNode(coordinates);
                pathfinder.NotifyReceivers();
            }            
        }
        
    }
   
}
