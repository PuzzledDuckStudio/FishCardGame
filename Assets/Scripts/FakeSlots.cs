using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeSlots : MonoBehaviour
{
    public EquipmentSlot[] equipSlots = new EquipmentSlot[5];
    public FishSlot[] fishSlots = new FishSlot[5];
    public Player owner;
    private Card[] deck = new Card[40];

    [SerializeField]
    private Card testCard;

    void Start()
    {
        FillDeck();

        if(owner == null)
        {
            owner = GetComponent<Player>();
        }
        for (int i = 0; i < equipSlots.Length; i++)
        {
            equipSlots[i] = new EquipmentSlot();
        }

        for (int i = 0; i < fishSlots.Length; i++)
        {
            fishSlots[i] = new FishSlot();
        }
    }

    public void PlaceInSlot(Card card)
    {
        switch(card.GetType().ToString())
        {
            case "FishCard":
                {
                    for (int i = 0; i < fishSlots.Length; i++)
                    {
                        if (!fishSlots[i].isTaken)
                        {
                            fishSlots[i].OnPlace(this, card);
                            return;
                        }
                    }
                    break;
                }
            case "EquipmentCard":
                {
                    for (int i = 0; i < equipSlots.Length; i++)
                    {
                        if (!equipSlots[i].isTaken)
                        {
                            equipSlots[i].OnPlace(this, card);
                            return;
                        }
                    }
                    break;
                }
            default:
                Debug.Log("Couldnt infer the type of card being placed.");
                break;
        }


    }

    public void EquipCurrentEquipment()
    {
        for (int i = 0; i < owner.currentHand.Length; i++)
        {
            if (owner.currentHand[i] && owner.currentHand[i].GetType().ToString() == "EquipmentCard")
            {
                //place the first card in owners hand
                PlaceInSlot(owner.currentHand[i]);

                //remove the card from players hand
                owner.currentHand[i] = null;

                return;
            }
        }
    }

    public void PlayFishCard()
    { 
        for (int i = 0; i < owner.currentHand.Length; i++)
        {
            if(owner.currentHand[i] && owner.currentHand[i].GetType().ToString() == "FishCard")
            {
                //place the first card in owners hand
                PlaceInSlot(owner.currentHand[i]);

                //remove the card from players hand
                owner.currentHand[i] = null;

                return;
            }
        }
    }

    public void DrawCard()
    {
        for (int i = 0; i < owner.currentHand.Length; i++)
        {
            if (!owner.currentHand[i])
            {
                owner.currentHand[i] = deck[deck.Length - (i + 1)];
                return;
            }
            else if (i == owner.currentHand.Length - 1 && owner.currentHand[i]) Debug.Log("Your hand is full!");
        }
    }

    private void FillDeck()
    {
        for (int i = 0; i < deck.Length; i++)
        {
            deck[i] = testCard;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}

public interface ISlots
{
    void OnPlace(FakeSlots slot, Card card);
}
