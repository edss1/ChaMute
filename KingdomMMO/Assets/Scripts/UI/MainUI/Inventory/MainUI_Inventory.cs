//MainUI_Inventory 스크립트
/*
 * 작성일자 : 2021-06-14
스크립트 설명 : 인벤토리를 출력하는 스크립트
스크립트 사용법 : 
                 
수정일자(1차) :                                       
수정내용(1차) :                                   
                                  
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI_Inventory : MonoBehaviour
{
    [SerializeField]
    Button inventoryPanelPopupButton;
    [SerializeField]
    Button inventoryPanelExitButton;
    [SerializeField]
    Image inventoryImage;
    // Start is called before the first frame update
    void Start()
    {
        inventoryImage.gameObject.SetActive(false);
        inventoryPanelPopupButton.onClick.AddListener(PopupButton);
        inventoryPanelExitButton.onClick.AddListener(ExitButton);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    //일시정지 활성화
    void PopupButton()
    {
        inventoryImage.gameObject.SetActive(true);
    }

    void ExitButton()
    {
        
        inventoryImage.gameObject.SetActive(false);
    }
}
