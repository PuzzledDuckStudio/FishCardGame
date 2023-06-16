using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private float cardSpacingWidthFactor;
    [SerializeField] private float cardSpacingHeightFactor;
    [SerializeField] private int maxCards;

    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Deck deck;
    [SerializeField] private Canvas boardCanvas;

    private RectTransform rectTransform;

    public float CardSpacingWidthFactor => cardSpacingWidthFactor;
    public float CardSpacingHeightFactor => cardSpacingHeightFactor;
    public int CardCount => transform.childCount;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void DrawCard()
    {
        if (CardCount < maxCards && deck.DrawCard())
        {
            Vector3 deckScreenPosition = Camera.main.WorldToScreenPoint(deck.transform.position);
            Instantiate(cardPrefab, deckScreenPosition, Quaternion.AngleAxis(180.0f, Vector3.right), rectTransform);
        }

        SortCards();
    }

    public void OnCardReleased(UICard card, Vector2 screenPoint)
    {
        for (int i = 0; i < boardCanvas.transform.childCount; i++)
        {
            RectTransform slot = boardCanvas.transform.GetChild(i) as RectTransform;

            if (RectTransformUtility.RectangleContainsScreenPoint(slot, screenPoint, boardCanvas.worldCamera))
            {
                Destroy(card.gameObject);
                SortCards();
            }
        }
    }

    private void SortCards()
    {
        float cardWidth = cardPrefab.GetComponent<RectTransform>().rect.width * CardSpacingWidthFactor;
        float cardHeight = cardPrefab.GetComponent<RectTransform>().rect.height * CardSpacingHeightFactor;
        float handWidth = cardWidth * CardCount;
        Vector3 firstCardPosition = rectTransform.position - new Vector3(handWidth / 2.0f - cardWidth / 2.0f, rectTransform.rect.height / 2.0f - cardHeight / 2.0f, 0.0f);

        for (int i = 0; i < CardCount; i++)
        {
            UICard card = rectTransform.GetChild(i).GetComponent<UICard>();
            card.DesiredPosition = firstCardPosition + new Vector3(cardWidth * i, 0, 0);
            card.GetComponent<Canvas>().sortingOrder = i;
        }
    }
}
