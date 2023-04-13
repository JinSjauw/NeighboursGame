using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private Transform buildingPrefab;

    public void SetPrefab(Transform _prefab)
    {
        buildingPrefab = _prefab;
    }
    
    public void OnClick()
    {
        BuildingManager.Instance.UpgradeBuilding(buildingPrefab, transform.root);
    }
}
