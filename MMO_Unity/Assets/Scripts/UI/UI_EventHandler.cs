using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public Action<PointerEventData> OnClickHandler = null;
    public Action<PointerEventData> OnDragHandler = null;
    public Action<PointerEventData> EndDragHandler = null;
    public Action<PointerEventData> PointerDownHandler = null;
    public Action<PointerEventData> PointerUpHandler = null;

    //드래그했을때
    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragHandler != null)
            OnDragHandler.Invoke(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (EndDragHandler != null)
            EndDragHandler.Invoke(eventData);
    }

    //클릭했을때
    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnClickHandler != null)
            OnClickHandler.Invoke(eventData);
    }

    //터치를 눌렀을때
    public void OnPointerDown(PointerEventData eventData)
    {
        if (PointerDownHandler != null)
            PointerDownHandler.Invoke(eventData);
    }

    //터치를 뗏을때
    public void OnPointerUp(PointerEventData eventData)
    {
        if (PointerUpHandler != null)
            PointerUpHandler.Invoke(eventData);
    }

    
}
