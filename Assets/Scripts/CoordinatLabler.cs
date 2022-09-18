using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinatLabler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.black;
    [SerializeField] Color blockedColor = Color.green;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0f);

    TextMeshPro lable;
    Vector2Int coordinates = new Vector2Int();
    //Waypoint waypoint;
    GridManager gridManager;

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        lable = GetComponent<TextMeshPro>();
        lable.enabled = false;
        //waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
            lable.enabled = true;
        }
        

        SetLableColor();

        ToggleLabels();
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            lable.enabled = !lable.IsActive();
        }
    }

    void SetLableColor()
    {
        if (gridManager == null) {return;}

        Node node = gridManager.GetNode(coordinates);

        if (node ==null) { return; }

        if (!node.isWalkable)
        {
            lable.color = blockedColor;
        }
        else if (node.isPath)
        {
            lable.color = pathColor;
        }
        else if (node.isExplored)
        {
            lable.color = exploredColor;
        }        
        else
        {
            lable.color = defaultColor;
        }

        /*if (!waypoint.IsPlaceable)
        {
            lable.color = blockedColor;
        }
        else
        {
            lable.color = defaultColor;
        }*/
    }

    void DisplayCoordinates()
    {
        if (gridManager == null) { return; }
        
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / gridManager.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridManager.UnityGridSize);
        lable.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
