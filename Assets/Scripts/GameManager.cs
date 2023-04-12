using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float PlayerMoney;
    public int SocialCohesion;

    public TreeScript Tree;

    public static TurnSystem Instance;

    //Listen for player actions
    //Subscribe to playerInput EventHandlers.
    public int turnCounter;
    public int actionCounter;
    [SerializeField] private TextMeshProUGUI turnCounterText;
    [SerializeField] private int maxActions;

    [SerializeField] private int widthIncrease;
    [SerializeField] private int heightIncrease;

    public event EventHandler OnTurnChanged;

    public List<InhabitantScript> Inhabitants = new List<InhabitantScript>();
    public List<GameObject> AllBuildings= new List<GameObject>();

    public List<string> FirstNames= new List<string>();
    public List<string> LastNames= new List<string>();
    public List<string> RandomPrompts = new List<string>();

    void Start()
    {
        turnCounter = 0;
        actionCounter = 0;
        BuildingManager.Instance.OnPlayerActed += OnPlayerAction;
        AddFirstNames();
        AddLastNames();
        AddRandomPrompts();
        StartCoroutine(RandomPromptSequence());
    }

    private void OnPlayerAction(object _sender, EventArgs _e)
    {
        actionCounter++;
        if (actionCounter >= maxActions)
        {
            NextTurn();
        }
    }

    private void NextTurn()
    {
        actionCounter = 0;

        //Go to next Turn
        Debug.Log("NextTurn");
        turnCounter++;
        turnCounterText.text = "Turn: " + turnCounter;

        LevelGrid.Instance.AddAvailableSize(widthIncrease, heightIncrease);

        //Invoke OnTurnChangedEvent
        OnTurnChanged?.Invoke(null, EventArgs.Empty);
    }

    private void ActionUpdate()
    {
        //...
    }

    private void TurnUpdate()
    {
        Tree.UpdateTree();
    }

    private IEnumerator RandomPromptSequence()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(20, 40));
        Debug.Log("Prompt time");
        InhabitantScript PromptGiver = Inhabitants[UnityEngine.Random.Range(0, Inhabitants.Count)];
        GameObject PromptHouse = PromptGiver.Home;
        PromptHouse.GetComponent<ResidentialBuilding>().CitizenName.text = PromptGiver.FirstName + PromptGiver.LastName;
        PromptHouse.GetComponent<ResidentialBuilding>().CitizenName.text = RandomPrompts[UnityEngine.Random.Range(0,RandomPrompts.Count)]; //from list of random messages
        PromptHouse.GetComponent<ResidentialBuilding>().PromptUI.SetActive(true);
        yield return new WaitForSeconds(4);
        PromptHouse.GetComponent<ResidentialBuilding>().PromptUI.SetActive(false);
        StartCoroutine(RandomPromptSequence());
    }

    private void ConstructivePrompt()
    {
        //activates when: ...
    }

    private void HintPrompt()
    {
        //activates when player hasnt done something in over 20/30 seconds
    }

    private void AddFirstNames()
    {
        FirstNames.AddMany("Albert", "Anna", "Aberforth", "Ariana", "Bill", "Bianca", 
            "Boris", "Blake", "Cecil", "Cole", "Chris", "Corry", "Dianne", "David", 
            "Debby", "Dobby", "Frank", "Francisca", "Gary", "Gertrude", "Harry", "Hilda", 
            "Iggy", "Imogen", "Jasper", "Jackie", "Karen", "Karl", "Lary", "Linda", "Morris", 
            "Mandy", "Nigel", "Nora", "Oscar", "Olivia", "Peter", "Patty", "Darth");
    }

    private void AddLastNames()
    {
        LastNames.AddMany("Smith", "Dubois", "Hillard", "Jackson", "Donalds", "Horses",
           "Johnson", "Barsby", "Bose", "Soup", "Zabza", "Hawk", "Dough", "Conch",
           "Debster", "Jim", "Nettle", "Clover", "Vader", "Chums", "Brockle", "Starch",
           "Sato", "Holland", "Zutphen", "Bear", "Marx", "Beans", "Wheeler", "Peanut", "Bowl",
           "Mangler", "Terror", "Poubelle", "Williams", "Smeller", "Sanscul", "Soups", "Lord",
           "Toddson", "Cofveve", "Bing", "Croc", "Crumbs", "Crank", "Sneezer", "Snat");
    }

    private void AddRandomPrompts()
    {
        RandomPrompts.AddMany("Our borough is growing so quickly! I can't wait to see what he future has in store for us.", 
            "Our bakery is running well enough, but we could always use more customers", 
            "Say chief, how do you plan to keep this community thriving?", 
            "I love taking walks near the central tree and catching up with the neighbours.", 
            "I'm so glad we have so many skilled artisans around, it would take me ages to get this fixed.", 
            "Horses");
    }

}
