using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCombat : IState
{
    public void OnEnter(TurnState stateController)
    {
        FishSlot[] playerSlots = stateController.player.cardsOnBoard.fishSlots;
        FishSlot[] opponentSlots = stateController.opponent.cardsOnBoard.fishSlots;

        //TODO: this line is to ensure the opponent has a card out. this is purely for testing. this needs to be DELETED
        stateController.opponent.cardsOnBoard.PlayFishCard();

        Debug.Log("Player is now entering combat!");
        for (int i = 0; i < playerSlots.Length; i++)
        {
            if(playerSlots[i].isTaken)
            {
                //the player has a fish summoned, now we loop through opponents cards to look for something to attack
                for (int j = 0; j < opponentSlots.Length; j++)
                {
                    if (opponentSlots[j].isTaken)
                    {
                        Card playersCard = stateController.player.cardsOnBoard.fishSlots[i].cardInSlot;
                        Card opponentsCard = stateController.opponent.cardsOnBoard.fishSlots[j].cardInSlot;
                        //we found a card to attack, so let's attack it!
                        new CardCombat(playersCard, opponentsCard);
                    }
                }
            }
        }
    }

    public void UpdateState(TurnState stateController)
    {
        //Debug.Log("Currently in the beginning of the turn.");
    }

    public void OnExit(TurnState stateController)
    {
        Debug.Log("Combat has finished, now moving to next state.");
    }
}
