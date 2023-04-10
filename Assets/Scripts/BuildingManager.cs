using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private Transform buildingPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get the gridObject of the click
        //Place building
        if (Input.GetMouseButton(0))
        {
            LevelGrid.Instance.PlaceBuilding(Mouse.GetPosition(), buildingPrefab);
        }
        
        //After every action collect money from all the buildings?
    }
}
