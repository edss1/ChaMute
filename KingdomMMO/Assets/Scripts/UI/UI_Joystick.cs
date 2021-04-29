//UI_Joystic 스크립트
/*
 * 작성일자 : 2021-04-29                                 
스크립트 설명 : 조이스틱
스크립트 사용법 : 
                 
수정일자(1차) :                                       
수정내용(1차) :                                   
                                  
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Joystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform lever;

    private RectTransform rectTransform;

    [SerializeField]
    private float leverRange;

    public Vector2 inputDir;
    public bool isInput = false; 


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        leverRange = 45.0f;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
        isInput = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
        isInput = true;
    }

    private void ControlJoystickLever(PointerEventData eventData)
    {
        inputDir = eventData.position - rectTransform.anchoredPosition;
        Vector2 clampedDir = inputDir.magnitude < leverRange ? inputDir : inputDir.normalized * leverRange;
        lever.anchoredPosition = clampedDir;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector2.zero;
        isInput = false;
    }

}
