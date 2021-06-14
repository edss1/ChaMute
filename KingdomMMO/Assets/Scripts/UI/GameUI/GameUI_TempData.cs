//GameUI_TempData 스크립트
/*
 * 작성일자 : 2021-06-08
스크립트 설명 : 게임중 획득한 아이템을 출력해주는 스크립트
스크립트 사용법 : 
                 
수정일자(1차) :                                       
수정내용(1차) :                                   
                                  
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI_TempData : MonoBehaviour
{
    [SerializeField]
    Button tempDataPopupButton;
    [SerializeField]
    Button tempDataExitButton;
    [SerializeField]
    Image tempDataImage;

    // Use this for initialization
    void Start()
    {
        tempDataImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        tempDataPopupButton.onClick.AddListener(PopupButton);
        tempDataExitButton.onClick.AddListener(ExitButton);
    }

    void PopupButton()
    {
        tempDataImage.gameObject.SetActive(true);
    }

    void ExitButton()
    {
        tempDataImage.gameObject.SetActive(false);

    }

}
