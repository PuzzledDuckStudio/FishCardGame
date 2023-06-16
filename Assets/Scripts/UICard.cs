using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UICard : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed; // Degrees per second
    [SerializeField] private float scaleSpeed;

    private Hand hand;

    private int sortingOrder;
    private bool isDragging;
    private Coroutine zoomInCoroutine;
    private Coroutine zoomOutCoroutine;

    public Vector2 DesiredPosition { get; set; }
    public Vector2 DesiredScale { get; set; } = Vector2.one;

    private void Start()
    {
        hand = GetComponentInParent<Hand>();
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(hand.transform as RectTransform, Input.mousePosition, hand.GetComponent<Canvas>().worldCamera, out position);

            transform.position = hand.transform.TransformPoint(position);
            transform.up = Vector3.RotateTowards(transform.up, new Vector3(0.0f, 1.0f, 1.0f), rotateSpeed * Mathf.Deg2Rad, 0.0f);
        }
        else
        {
            transform.up = Vector3.RotateTowards(transform.up, Vector3.up, rotateSpeed * Time.deltaTime * Mathf.Deg2Rad, 0.0f);
            transform.position = Vector2.MoveTowards(transform.position, DesiredPosition, moveSpeed * Time.deltaTime);
            transform.localScale = Vector3.MoveTowards(transform.localScale, DesiredScale, scaleSpeed * Time.deltaTime);
        }
    }

    public void OnBeginPointerDrag(BaseEventData eventData)
    {
        StopAllCoroutines();

        DesiredScale = Vector2.one;
        transform.localScale = DesiredScale;

        GetComponent<Image>().raycastPadding = Vector4.zero;
        GetComponent<Canvas>().sortingOrder = 100;

        isDragging = true;
    }

    public void OnEndPointerDrag(BaseEventData eventData)
    {
        PointerEventData pointerEventData = eventData as PointerEventData;

        isDragging = false;

        hand.OnCardReleased(this, pointerEventData.position);
    }

    public void OnPointerEnter(BaseEventData eventData)
    {
        if (zoomOutCoroutine != null)
        {
            StopCoroutine(zoomOutCoroutine);
        }
        
        zoomInCoroutine = StartCoroutine(ZoomIn());
    }

    public void OnPointerExit(BaseEventData eventData)
    {
        if (zoomInCoroutine != null)
        {
            StopCoroutine(zoomInCoroutine);
            GetComponent<Canvas>().sortingOrder = sortingOrder;
        }

        zoomOutCoroutine = StartCoroutine(ZoomOut());
    }

    private IEnumerator ZoomIn()
    {
        Rect bounds = GetComponent<RectTransform>().rect;

        DesiredPosition = new Vector2(DesiredPosition.x, bounds.height);
        DesiredScale = Vector2.one * 2;

        while (
            transform.position.x != DesiredPosition.x ||
            transform.position.y != DesiredPosition.y ||
            transform.localScale.x != DesiredScale.x ||
            transform.localScale.y != DesiredScale.y
        )
        {
            yield return null;
        }

        GetComponent<Image>().raycastPadding = new Vector4(
            bounds.width / 4, // Left
            0, // Bottom
            bounds.width / 4, // Right
            0 // Top
        );

        Canvas canvas = GetComponent<Canvas>();
        sortingOrder = canvas.sortingOrder;
        canvas.sortingOrder = 100;
    }

    private IEnumerator ZoomOut()
    {
        Rect bounds = GetComponent<RectTransform>().rect;

        DesiredPosition = new Vector2(DesiredPosition.x, bounds.height / (2 / transform.parent.GetComponent<Hand>().CardSpacingHeightFactor));
        DesiredScale = Vector2.one;

        while (
            transform.position.x != DesiredPosition.x ||
            transform.position.y != DesiredPosition.y ||
            transform.localScale.x != DesiredScale.x ||
            transform.localScale.y != DesiredScale.y
        )
        {
            yield return null;
        }

        GetComponent<Image>().raycastPadding = Vector4.zero;
        GetComponent<Canvas>().sortingOrder = sortingOrder;
    }
}
