using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] private int maxCardCount;

    private int cardCount;
    public int CardCount => cardCount;

    private float startingHeight;

    private void Start()
    {
        startingHeight = transform.localScale.y;
        cardCount = maxCardCount;
    }

    // TODO: return the card you actually get here
    public bool DrawCard()
    {
        if (cardCount == 0)
        {
            return false;
        }

        cardCount--;
        transform.localScale = new Vector3(transform.localScale.x, (float)cardCount / maxCardCount * startingHeight, transform.localScale.z);
        return true;
    }
}
