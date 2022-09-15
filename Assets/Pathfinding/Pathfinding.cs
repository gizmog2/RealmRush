using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    [SerializeField] Node currentSearchNode;
    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid;

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if (gridManager != null)
        {
            grid = gridManager.Grid;
        }
    }

    void Start()
    {
        ExploreNeibours();
    }

    void ExploreNeibours()
    {
        List<Node> neighbors = new List<Node>();
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoord = currentSearchNode.coordinates + direction;

            if (grid.ContainsKey(neighbourCoord))
            {
                neighbors.Add(grid[neighbourCoord]);

                //TODO: Remove after testing
                grid[neighbourCoord].isExplored = true;
                grid[currentSearchNode.coordinates].isPath = true;
            }
        }
    }
}
