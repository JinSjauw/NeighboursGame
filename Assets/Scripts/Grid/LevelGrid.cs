using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    public static LevelGrid Instance  { get; private set; }

    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float cellSize;
    
    [SerializeField] private Transform gridDebugObject;
    private GridSystem<GridObject> gridSystem;
   
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
        gridSystem.CreateDebugObjects(gridDebugObject);
    }

    public Vector3 GetTargetGridPosition(Vector3 _worldPosition)
    {
        return GetWorldPosition(GetGridPosition(_worldPosition));
    }
    
    public GridPosition GetGridPosition(Vector3 _worldPosition) => gridSystem.GetGridPosition(_worldPosition);
    
    public Vector3 GetWorldPosition(GridPosition _gridPosition) => gridSystem.GetWorldPosition(_gridPosition);

    public bool PlaceBuilding(Vector3 _targetPosition, Transform _buildingPrefab)
    {
        GridObject gridObject = gridSystem.GetGridObject(GetGridPosition(_targetPosition));
        if (gridObject.IsOccupied())
        {
            return false;
        }
        else
        {
            Instantiate(_buildingPrefab, GetWorldPosition(gridObject.GetGridPosition()), Quaternion.identity);
            gridObject.SetOccupied(true);

            return true;
        }
    }
}
