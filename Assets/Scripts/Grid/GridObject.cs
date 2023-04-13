using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    private GridSystem<GridObject> gridSystem;
    private GridPosition gridPosition;
    private Building currentBuilding;
    private bool isOccupied;

    public GridObject(GridSystem<GridObject> _gridSystem, GridPosition _gridPosition)
    {
        gridSystem = _gridSystem;
        gridPosition = _gridPosition;
    }

    public GridPosition GetGridPosition()
    {
        return gridPosition;
    }
    
    public bool IsOccupied()
    {
        return isOccupied;
    }

    public void SetOccupied(bool _state)
    {
        isOccupied = _state;
    }

    public void SetBuilding(Building _building)
    {
        currentBuilding = _building;
    }

    public Building GetCurrentBuilding()
    {
        return currentBuilding;
    }
    
    public override string ToString()
    {
        return gridPosition.ToString() + "\r\n" + isOccupied;
    }
}
