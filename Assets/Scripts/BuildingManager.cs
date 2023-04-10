using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.Video;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance;

    [SerializeField] private List<Transform> buildingPrefabList;
    [SerializeField] private Transform buildingPrefab;
    public event EventHandler OnPlayerActed;
    private LevelGrid grid;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        //buildingPrefabList = new List<Transform>();
    }

    private void Start()
    {
        if (LevelGrid.Instance != null)
        {
            grid = LevelGrid.Instance;
        }
        else
        {
            Debug.Log("LevelGrid is NULL!");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //Get the gridObject of the click
        //Place building
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (grid.PlaceBuilding(Mouse.GetPosition(), buildingPrefab))
            {
                //Invoke playerAction eventHandler.
                OnPlayerAction();
            }
        }
    }

    private void OnPlayerAction()
    {
        OnPlayerActed?.Invoke(null, EventArgs.Empty);
    }

    public void OnClickResidential()
    {
        buildingPrefab = buildingPrefabList[0];
    }
    
    public void OnClickCommercial()
    {
        buildingPrefab = buildingPrefabList[1];
    }
}
