using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEnd : IState
{
    public void OnEnter(TurnState stateController)
    {
        Debug.Log("Player is finishing up their turn!");
    }

    public void UpdateState(TurnState stateController)
    {
        //Debug.Log("Currently in the beginning of the turn.");
    }

    public void OnExit(TurnState stateController)
    {
        Debug.Log("Player has finished their turn.");
    }
}
