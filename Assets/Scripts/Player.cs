using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public Card[] currentHand = new Card[6];

    public FakeSlots cardsOnBoard;

    // Start is called before the first frame update
    void Start()
    {
        if(cardsOnBoard == null)
        {
            cardsOnBoard = GetComponent<FakeSlots>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
