//GameUI_Pause 스크립트
/*
 * 작성일자 : 2021-06-08
스크립트 설명 : 일시정지 스크립트
스크립트 사용법 : 
                 
수정일자(1차) :                                       
수정내용(1차) :                                   
                                  
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI_Pause : MonoBehaviour
{
    bool isPause;
    [SerializeField]
    Button pauseButtonTrue;
    [SerializeField]
    Button pauseButtonFalse;

    // Use this for initialization
    void Start()
    {
        isPause = false;
        pauseButtonFalse.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        pauseButtonTrue.onClick.AddListener(IsPauseTrue);
        pauseButtonFalse.onClick.AddListener(IsPauseFalse);
    }

    //일시정지 활성화
    void IsPauseTrue()
    {
        Time.timeScale = 0;
        pauseButtonFalse.gameObject.SetActive(true);
    }

    void IsPauseFalse()
    {
        pauseButtonFalse.gameObject.SetActive(false);
        Time.timeScale = 1;
        
    }

}
