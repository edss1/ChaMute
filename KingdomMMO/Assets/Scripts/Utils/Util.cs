//Util 스크립트
/*
 * 작성일자 : 2021-04-29                                 
스크립트 설명 : 범용적으로 쓰이는 함수를 모아둔 스크립트
스크립트 사용법 : 
                 
수정일자(1차) :                                       
수정내용(1차) :                                   
                                  
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Util : MonoBehaviour
{
    public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component //Component 추가
    {
        T component = go.GetComponent<T>();
        if (component == null)
            component = go.AddComponent<T>();

        return component;

    }

    public static void ColorChange(int status, int statusTemp, Text text)
    {
        if (statusTemp > status)
            text.color = new Color(255, 0, 0);
        else
            text.color = new Color(0, 0, 0);
    }
}
