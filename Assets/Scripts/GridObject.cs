using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    // Start is called before the first frame update
    private GridPosition gridPosition;
    private GridSystem gridSystem;

    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
    }
}
