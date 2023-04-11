using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    public static TurnSystem Instance;

    //Listen for player actions
    //Subscribe to playerInput EventHandlers.
    private int turnCounter;
    private int actionCounter;
    [SerializeField] private TextMeshProUGUI turnCounterText;
    [SerializeField] private int maxActions;

    [SerializeField] private int widthIncrease;
    [SerializeField] private int heightIncrease;

    public event EventHandler OnTurnChanged;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }

    void Start()
    {
        BuildingManager.Instance.OnPlayerActed += OnPlayerAction;
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
}
