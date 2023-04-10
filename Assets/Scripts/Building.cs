using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingType
{
    RESIDENTIAL,
    COMMERCIAL,
    HYBRID,
}

public abstract class Building : MonoBehaviour
{

    protected BuildingType type;
    private float socialValue;
    private float commercialValue;
    
    public float SocialValue { get; private set; }
    public float CommercialValue { get; private set; }

    
}
