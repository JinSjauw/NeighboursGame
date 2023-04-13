using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingType
{
    RESIDENTIAL,
    COMMERCIAL,
    HYBRID,
}

public enum BuildingTier
{
    EARLY,
    MID,
    LATE,
}

public abstract class Building : MonoBehaviour
{
    [SerializeField] protected int socialValue;
    [SerializeField] protected int commercialValue;
    [SerializeField] protected int buildingCost;
    [SerializeField] protected BuildingType type;
    [SerializeField] protected BuildingTier tier;
    [SerializeField] protected Transform buildingPrefab;
    [SerializeField] protected List<Building> upgradeList;
    [SerializeField] protected Transform upgradeButtonPrefab;
    [SerializeField] protected Transform buttonContainer;
    [SerializeField] protected Transform upgradeMenu;
    
    public BuildingType Type
    {
        get { return type; }
    }
    public BuildingTier Tier
    {
        get{ return tier; }
    }
    public int SocialValue
    {
        get { return socialValue; }
    }
    public int CommercialValue
    {
        get { return commercialValue;  }
    }

    public int BuildingCost
    {
        get { return buildingCost; }
    }

    public Transform BuildingPrefab
    {
        get { return buildingPrefab;  }
    }

    public void UpgradeMenu(bool _state)
    {
        upgradeMenu.gameObject.SetActive(_state);
    }
    
    public abstract void Init();
    
    public abstract List<Building> GetUpgradesList();
}
