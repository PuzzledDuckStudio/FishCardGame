using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCombat : MonoBehaviour
{
    [SerializeField]
    public Card attacker;
    [SerializeField]
    public Card defender;

    public CardCombat(Card attacker, Card defender)
    {
        this.defender = defender;
        this.attacker = attacker;

        Attack(attacker, defender);
        Attack(defender, attacker);
    }

    private void Attack(Card attacker, Card defender)
    {
        defender.GetCardInfo().ReduceHealth(attacker.GetCardInfo().GetCardStats()[2].GetValue());
        Debug.Log($"{attacker.name} has attacked {defender.name} for {attacker.GetCardInfo().GetCardStats()[2].GetValue()} damage.");
        Debug.Log($"{defender.name} now has {defender.GetCardInfo().GetCardStats()[0].GetValue()} health!");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
