using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommercialBuilding : Building
{
    [SerializeField]
    private int BuildingSize; //1 = small, 2 = med, 3 = big, has to do with the random Householdsize

    public int IncomeAmount;
    public int IncomeMultiplier;
    public int PaymentInterval = 20;

    public int SocialWorth;

    [SerializeField]
    private int MinCapacity;
    [SerializeField]
    private int MaxCapacity;

    public GameManager gameManager;

    private void Awake()
    {
        IncomeMultiplier = 1;
        gameManager = FindObjectOfType<GameManager>();
        gameManager.AllBuildings.Add(this.gameObject);
        StartCoroutine(Payment());
    }

    public override void Init()
    {
        foreach (Transform button in buttonContainer)
        {
            Destroy(button);
        }
        
        //Build upgrade UI
        foreach (Building upgrade in upgradeList)
        {
            Transform button = Instantiate(upgradeButtonPrefab, buttonContainer);
            button.TryGetComponent(out UpgradeButton upgradeButton);
            upgradeButton.SetPrefab(upgrade.BuildingPrefab);
        }
    }
    
    public override List<Building> GetUpgradesList()
    {
        return upgradeList;
    }
    
    public void CheckCapacity() //should be checked every time the player uses a 'move' (places a building for example)
    {
        int ResBuildingsInArea = 0;
        //int ResBuildingsInArea; ...
        //get current gridpposition -> check for residential buildings in the 5x5 square around it (two spaces in each direction)

        if (ResBuildingsInArea >= MinCapacity && ResBuildingsInArea <= MaxCapacity)
        {
            //Check succesful
        }
        else
        {
            //unsuccesful, deactivates a residential building in range and reduces incomeMultiplier
        }
    }

    private IEnumerator Payment()
    {
        yield return new WaitForSeconds(PaymentInterval);
        gameManager.PlayerMoney += IncomeAmount * IncomeMultiplier;
        StartCoroutine(Payment());
    }
}

