using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPlacement : IState
{
   public void OnEnter(TurnState stateController)
    {
        Debug.Log("Player is now placing cards!");
        stateController.playFish.interactable = true;
        stateController.playEquip.interactable = true;
    }

    public void UpdateState(TurnState stateController)
    {
        //Debug.Log("Currently in the beginning of the turn.");
    }

    public void OnExit(TurnState stateController)
    {
        Debug.Log("Turn is moving from placement state to next state.");
        stateController.playFish.interactable = false;
        stateController.playEquip.interactable = false;
    }
}
