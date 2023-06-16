using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfo
{
    private string name;
    private Stat healthVal;
    private Stat armorVal;
    private Stat attackVal;
    private Stat sizeInSlots;
    private Stat baitCost;
    private readonly bool isCreature;
    //private Bait baitType;
    private List<Stat> modifiers;

    public CardInfo(string desiredName, List<Stat> modifiers)
    {
        name = desiredName;
        healthVal = new Stat(0, "health");
        armorVal = new Stat(0, "armor");
        attackVal = new Stat(0, "attack");
        sizeInSlots = new Stat(0, "size");
        baitCost = new Stat(0, "baitCost");
        isCreature = false;
        this.modifiers = modifiers;
    }

    public CardInfo(string desiredName, int healthVal, int armorVal, int attackVal, int sizeInSlots, int baitCost)
    {
        name = desiredName;
        this.healthVal = new Stat(healthVal, "health");
        this.armorVal = new Stat(armorVal, "armor");
        this.attackVal = new Stat(attackVal, "attack");
        this.sizeInSlots = new Stat(sizeInSlots, "size");
        this.baitCost = new Stat(baitCost, "baitCost");
        isCreature = true;
    }

    public Stat[] GetCardStats()
    {
        Stat[] stats = { healthVal, armorVal, attackVal, sizeInSlots, baitCost };
        //for (int i = 0; i < stats.Length; i++)
        //{
        //    Debug.Log($"{stats[i].type} : {stats[i].GetValue()}");
        //}
        return stats;
    }

    public string GetCardName()
    {
        return name;
    }

    public List<Stat> GetCardModifiers()
    {
        return modifiers;
    }

    public void ReduceHealth(int amount)
    {
        healthVal.ReduceValue(amount);
    }
}
