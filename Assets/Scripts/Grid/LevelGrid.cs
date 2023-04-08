using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    public static LevelGrid Instance  { get; private set; }
    
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float cellSize;

    [SerializeField] private int availableWidth;
    [SerializeField] private int availableHeight;

    [SerializeField] private Transform gridDebugObject;
    private GridSystem<GridObject> gridSystem;
    private GridObject[,] availableGrid;
   
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("More than one instance of LevelGrid");
            Destroy(gameObject);
            return;
        }
        Instance = this;
        
        gridSystem = new GridSystem<GridObject>(width, height, cellSize, (GridSystem<GridObject> _grid, GridPosition _gridPosition) => new GridObject(_grid, _gridPosition));
        availableGrid = new GridObject[width, height];
        GetAvailableGrid(availableGrid);
        Debug.Log(availableGrid.Length);
        gridSystem.CreateDebugObjects(gridDebugObject, availableGrid);
    }

    private void GetAvailableGrid(GridObject[,] _array)
    {
        GridObject middle = gridSystem.GetGridObject(new GridPosition(width / 2, height / 2 ));
        GridPosition middlePosition = middle.GetGridPosition();
        
        Debug.Log(middlePosition);

        for (int x = width / 2 - availableWidth; x < middlePosition.x + availableWidth + 1; x++)
        {
            for (int z = height / 2 - availableHeight; z < middlePosition.z + availableHeight + 1; z++)
            {
                GridObject gridObject = gridSystem.GetGridObject(new GridPosition(x, z));
                gridObject.SetOccupied(true);
                Debug.Log(x + " : " + z);
                _array[x, z] = gridObject;
            }
        }
    }
    
    public Vector3 GetTargetGridPosition(Vector3 _worldPosition)
    {
        return GetWorldPosition(GetGridPosition(_worldPosition));
    }
    
    public GridPosition GetGridPosition(Vector3 _worldPosition) => gridSystem.GetGridPosition(_worldPosition);
    
    public Vector3 GetWorldPosition(GridPosition _gridPosition) => gridSystem.GetWorldPosition(_gridPosition);

    public bool PlaceBuilding(Vector3 _targetPosition, Transform _buildingPrefab)
    {
        //Check if it is within availableGrid;
        GridPosition target = gridSystem.GetGridPosition(_targetPosition);
        GridObject gridObject = availableGrid[target.x, target.z];
        if (gridObject != null)
        {
            if (gridObject.IsOccupied())
            {
                return false;
            }
            
            Instantiate(_buildingPrefab, GetWorldPosition(gridObject.GetGridPosition()), Quaternion.identity);
            gridObject.SetOccupied(true);

            return true;
        }
        else
        {
            Debug.Log("Not in the grid!");
        }

        return false;
    }
}
