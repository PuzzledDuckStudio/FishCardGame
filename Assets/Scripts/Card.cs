using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField]
    protected string cardName = string.Empty;

    [SerializeField]
    public CardInfo cardInfo;

    public virtual void PlayCard()
    {

    }

    public void DiscardCard()
    {

    }

    public CardInfo GetCardInfo()
    {
        return cardInfo;
    }


    // Start is called before the first frame update
    void Awake()
    {
        cardInfo = new CardInfo(cardName, 10, 2, 3, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
