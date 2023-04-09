using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    
    //Listen for player actions
    //Subscribe to playerInput EventHandlers.
    private int turnCounter;
    private int actionCounter;
    [SerializeField] private TextMeshProUGUI turnCounterText;
    [SerializeField] private int maxActions;
    
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
        //Do stuff...
    }
}
