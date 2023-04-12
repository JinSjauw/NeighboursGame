using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidentialBuilding : Building
{
    public override List<Building> GetUpgradesList()
    {
        return upgradeList;
    }
}
