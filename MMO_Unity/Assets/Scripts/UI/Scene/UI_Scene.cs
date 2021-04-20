//UI_Scene 스크립트
/*
 * 작성일자 : 2021-04-14                                 
스크립트 설명 : 씬UI를 관리한다
스크립트 사용법 : 
                 
수정일자(1차) :                                       
수정내용(1차) :                                   
                                  
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Scene : UI_Base
{
    public override void Init()
    {
        Managers.UI.SetCanvas(gameObject, false);
    }
}
