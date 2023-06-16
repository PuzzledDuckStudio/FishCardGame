using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBegin : IState
{
    bool hasDrawn = false;
    public void OnEnter(TurnState stateController)
    {
        Debug.Log("Turn is beginning!");
        stateController.draw.interactable = true;
    }

    public void UpdateState(TurnState stateController)
    {
        //Debug.Log("Currently in the beginning of the turn.");
        if(hasDrawn)
        {
            Debug.Log("Player drew a card!");
        }
    }

    public void OnExit(TurnState stateController)
    {
        Debug.Log("Turn is moving from beginning state to next state.");
        stateController.draw.interactable = false;
    }
}
