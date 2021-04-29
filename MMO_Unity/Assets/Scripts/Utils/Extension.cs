
//Extension 스크립트
/*
 * 작성일자 : 2021-04-14                                 
스크립트 설명 : 사용자 정의 메서드를 추가할 수 있다(어느 클래스에서 확장메서드를 적용할지 결정)
스크립트 사용법 : Generic(T)가 아니면서 static 클래스에만 정의되며 static 메서드로 정의한다
                 this를 첫번째 매개변수로 사용하여 this.[정의된함수] 형식으로 사용한다.
수정일자(1차) : GetOrAddComponent<T> 추가                                     
수정내용(1차) : gameObject.으로 접근가능                                  
                                  
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public static class Extension
{

    public static T GetOrAddComponent<T>(this GameObject go) where T : UnityEngine.Component //Component 추가
    {
        return Util.GetOrAddComponent<T>(go);

    }

    //원 함수에 this를 추가한다
    /// <summary>
    /// BindEventClick : UI 클릭
    /// </summary>
    public static void BindEventClick(this GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_Base.BindEvent(go,action,type);
    }

    /// <summary>
    /// BindEventPointerDown : UI에서 터치를 뗀다
    /// </summary>
    public static void BindEventPointerDown(this GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.PointerDown)
    {
        UI_Base.BindEvent(go, action, type);
    }

    /// <summary>
    /// BindEventPointerUp : UI에서 터치를 한다
    /// </summary>
    public static void BindEventPointerUp(this GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.PointerUp)
    {
        UI_Base.BindEvent(go, action, type);
    }

    /// <summary>
    /// BindEventDrag : UI를 드래그한다
    /// </summary>
    public static void BindEventDrag(this GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Drag)
    {
        UI_Base.BindEvent(go, action, type);
    }

    /// <summary>
    /// BindEventEndDrag : UI를 드래그하고 터치를 뗀다
    /// </summary>
    public static void BindEventEndDrag(this GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.EndDrag)
    {
        UI_Base.BindEvent(go, action, type);
    }

    public static bool IsValid(this GameObject go)
    {
        return go != null && go.activeSelf;
    }
   
}