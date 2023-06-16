using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentCard : Card
{
    // Start is called before the first frame update
    [SerializeField]
    private List<Stat> modifiers = new List<Stat>();
    void Awake()
    {
        modifiers.Add(new Stat(5, "attack"));
        cardInfo = new CardInfo(cardName, modifiers);
    }

    public override void PlayCard()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
