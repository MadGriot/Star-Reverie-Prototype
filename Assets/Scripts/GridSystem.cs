using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem
{
    private int width;
    private int length;
    private float cellSize;
    private GridObject[,] gridObjectArray;
    public GridSystem(int width, int length, float cellSize)
    {
        this.width = width;
        this.length = length;
        this.cellSize = cellSize;

        gridObjectArray = new GridObject[width, length];
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < length; z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                new GridObject(this, gridPosition);
                gridObjectArray[x, z] = new GridObject(this, gridPosition);

            }
        }
    }

    public Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 0, z) * cellSize;
    }

    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return new GridPosition(
            Mathf.RoundToInt(worldPosition.x / cellSize),
            Mathf.RoundToInt(worldPosition.z / cellSize));
    }

    public void CreateDebugObjects(Transform debugPrefab)
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < length; z++)
            {
                GameObject.Instantiate(debugPrefab, GetWorldPosition(x, z), Quaternion.identity);
            }
        }
    }
}

