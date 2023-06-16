using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnState : MonoBehaviour
{
    IState currentState;
    public TurnBegin beginState = new TurnBegin();
    public TurnPlacement placeState = new TurnPlacement();
    public TurnCombat combatState = new TurnCombat();
    public TurnEnd endState = new TurnEnd();

    public Player player;
    public Player opponent;

    public Button draw;
    public Button playFish;
    public Button playEquip;

    private void Start()
    {
        ChangeState(beginState);
    }

    private void Update()
    {
        if(currentState != null)
        {
            currentState.UpdateState(this);
        }
    }

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        currentState.OnEnter(this);
    }

    public void GotoBeginState()
    {
        ChangeState(beginState);
    }

    public void GotoPlacementState()
    {
        ChangeState(placeState);
    }

    public void GotoCombatState()
    {
        ChangeState(combatState);
    }

    public void GotoEndState()
    {
        ChangeState(endState);
    }
}

public interface IState
{
    void OnEnter(TurnState stateController);
    void UpdateState(TurnState stateController);
    void OnExit(TurnState stateController);
}