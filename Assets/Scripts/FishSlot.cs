using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSlot : ISlots
{
    public bool isTaken = false;
    public Card cardInSlot;
    public void OnPlace(FakeSlots slotManager, Card card)
    {
        Debug.Log($"{slotManager.owner} just played card: {card.name}");

        cardInSlot = card;
        isTaken = true;

    }
}
