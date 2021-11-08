using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Node currentSearchNode;
    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    Dictionary<Vector2Int, Node> grid;

    GridManager gridManager;

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();

        if (gridManager != null)
            grid = gridManager.Grid;
    }

    void Start()
    {
        ExploreNeighbors();
    }

    void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborCoordinates = currentSearchNode.coordinates + direction;

            if (grid.ContainsKey(neighborCoordinates))
            {
                neighbors.Add(grid[neighborCoordinates]);

                // TODO: Remove after testing...
                grid[neighborCoordinates].isExplored = true;
                grid[currentSearchNode.coordinates].isPath = true;
            }
        }
    }
}
