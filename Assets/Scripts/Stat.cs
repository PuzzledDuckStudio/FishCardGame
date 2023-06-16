using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    private int baseVal;
    public string type { get; }

    public List<int> modifiers;

    public Stat(int baseVal, string type)
    {
        this.baseVal = baseVal;
        this.type = type;
        this.modifiers = new List<int>();
    }

    public void AddModifier(int amount)
    {
        modifiers.Add(amount);
        baseVal += amount;
    }

    public int GetValue()
    {
        return baseVal;
    }

    public void ReduceValue(int amount)
    {
        baseVal -= amount;
    }
}
