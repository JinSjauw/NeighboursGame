using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.Video;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance;

    [Header("UI Objects")] 
    [SerializeField] private TextMeshProUGUI moneyCounterText;
    
    [SerializeField] private List<Transform> buildingPrefabList;
    [SerializeField] private Transform buildingPrefab;
    [SerializeField] private List<Building> activeBuildingList;
    
    [SerializeField] private int moneyAmount;
    [SerializeField] private int socialAmount;
    
    private LevelGrid grid;
    
    public event EventHandler OnPlayerActed;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
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
            GameObject buildingObject = grid.PlaceBuilding(Mouse.GetPosition(), buildingPrefab);
            
            if (buildingObject == null)
            {
                return;
            }

            Building building = buildingObject.GetComponent<Building>();
        
            if (moneyAmount - building.BuildingCost < 0)
            {
                return;
            }
        
            activeBuildingList.Add(building);

            //Invoke playerAction eventHandler.
            OnPlayerAction();
        }
        
        
    }

    private void OnPlayerAction()
    {
        //Get All the building on the grid.
        //Get Their social values and Add money and social worth
        foreach (Building building in activeBuildingList)
        {
            moneyAmount += building.CommercialValue;
            socialAmount += building.SocialValue;
        }

        moneyCounterText.text = "$ " + moneyAmount;
        
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
