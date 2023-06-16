using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot : ISlots
{
    public bool isTaken = false;
    public Card cardInSlot;
    public void OnPlace(FakeSlots slotManager, Card card)
    {
        List<Stat> equipStats = card.GetCardInfo().GetCardModifiers();
        FishSlot[] fishOnField = slotManager.fishSlots;

        for (int i = 0; i < fishOnField.Length; i++)
        {
            if (fishOnField[i].isTaken)
            {
                CardInfo cardInfo = fishOnField[i].cardInSlot.cardInfo;
                Stat[] cardStats = cardInfo.GetCardStats();
                //loop through all the players card stats to make sure we're assigning a modifier to the correct stat
                for (int j = 0; j < cardStats.Length; j++)
                {
                    //loop through the equipment stats so we can assign each equipment stat to any corresponding fish card stats
                    for (int k = 0; k < equipStats.Count; k++)
                    {
                        if (cardStats[j].type == equipStats[k].type)
                        {
                            Debug.Log($"Modifier with value of {equipStats[k].GetValue()} added to creature stats with base value of {cardStats[j].GetValue()}");
                            cardStats[j].AddModifier(equipStats[k].GetValue());
                        }
                    }
                    
                }  
            }
        }

        cardInSlot = card;
        isTaken = true;

    }
}
