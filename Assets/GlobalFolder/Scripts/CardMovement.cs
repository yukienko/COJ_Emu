using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;

    // ドラックが開始したとき呼ばれる.
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log(1);

    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // ドラック中に呼ばれる.
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPosition = GetLocalPosition(eventData.position);
        transform.position = localPosition;
        Debug.Log(2);
    }

    private Vector2 GetLocalPosition(Vector2 screenPosition)
    {
        Vector2 result = Vector2.zero;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, screenPosition, Camera.main, out result);

        return result;
    }


    // ドラックが終了したとき呼ばれる.
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log(3);
    }
}
