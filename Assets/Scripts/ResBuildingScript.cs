using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class ResBuildingScript : MonoBehaviour
{
    [SerializeField]
    private int BuildingSize; //1 = small, 2 = med, 3 = big, has to do with the random Householdsize

    public int HouseholdSize;
    public int SocialWorth;
    private int MovingOutTime;

    public GameManager gameManager;

    public List<FamilyScript> FamiliesInBuilding = new List<FamilyScript>();

    public GameObject PromptUI;
    public TextMeshProUGUI CitizenName;
    public TextMeshProUGUI Prompt;


    private void Awake()
    {
        PopulateBuilding();
        gameManager = FindObjectOfType<GameManager>();
        gameManager.AllBuildings.Add(this.gameObject);
    }

    private void PopulateBuilding() //Check this one very well
    {
        switch (BuildingSize)
        {
            case 1:
                FamiliesInBuilding.Add(new FamilyScript());
                FamilyScript fam = FamiliesInBuilding.Last();
                fam.FamilyName = gameManager.LastNames[Random.Range(0, gameManager.LastNames.Count)];

                for(int i = Random.Range(1,5); i>0; i--)
                {
                    InhabitantScript member = new InhabitantScript();
                    member.FirstName = gameManager.FirstNames[Random.Range(0, gameManager.LastNames.Count)];
                    member.LastName = fam.FamilyName;
                    fam.FamilyMembers.Add(member);
                    gameManager.Inhabitants.Add(member);
                }
                

                break;
            case 2:
                for(int i = 2; i > 0; i--)
                {
                    FamiliesInBuilding.Add(new FamilyScript());
                    FamilyScript famv2 = FamiliesInBuilding.Last();
                    famv2.FamilyName = gameManager.LastNames[Random.Range(0, gameManager.LastNames.Count)];

                    for (int n = Random.Range(1, 5); n > 0; n--)
                    {
                        InhabitantScript member = new InhabitantScript();
                        member.FirstName = gameManager.FirstNames[Random.Range(0, gameManager.LastNames.Count)];
                        member.LastName = famv2.FamilyName;
                        famv2.FamilyMembers.Add(member);
                        gameManager.Inhabitants.Add(member);
                    }
                }
                break;
            case 3:
                for (int i = 6; i > 0; i--)
                {
                    FamiliesInBuilding.Add(new FamilyScript());
                    FamilyScript famv3 = FamiliesInBuilding.Last();
                    famv3.FamilyName = gameManager.LastNames[Random.Range(0, gameManager.LastNames.Count)];

                    for (int g = Random.Range(1, 5); g > 0; g--)
                    {
                        InhabitantScript member = new InhabitantScript();
                        member.FirstName = gameManager.FirstNames[Random.Range(0, gameManager.LastNames.Count)];
                        member.LastName = famv3.FamilyName;
                        famv3.FamilyMembers.Add(member);
                        gameManager.Inhabitants.Add(member);
                    }
                }
                break;
        }
    }

    public void DeactivateSequence()
    {
        StartCoroutine(DeactivationTimer());
    }

    public IEnumerator DeactivationTimer()
    {
        MovingOutTime = Random.Range(10, 30);
        yield return new WaitForSeconds(MovingOutTime);
        RemoveFamilyFromBuilding();
    }

    private void RemoveFamilyFromBuilding()
    {
        //grab family from this building from familyList and remove it (and deactive any companies associated with family)
    }
}