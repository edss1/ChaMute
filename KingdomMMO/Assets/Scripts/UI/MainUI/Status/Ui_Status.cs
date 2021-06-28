using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_Status : MonoBehaviour
{
    PlayerStatus status;

    [Header("STR")]
    [SerializeField]
    public Text strPointText;   //힘스탯 포인트 텍스트
    [HideInInspector]
    public int strPoint;        //힘스탯 포인트
    [SerializeField]
    Text requirePointText;      //요구하는 스탯 포인트
    int requirePoint;           //요구하는 스탯
    [HideInInspector]
    public int strTemp;         //힘스탯 잠깐 저장하는 용도
    [SerializeField]
    Button strPlusButton;       //힘스탯 추가 버튼
    [SerializeField]
    Button strMinusButton;      //힘스탯 마이너스 버튼



    [SerializeField]
    Button Confirm;


    // Start is called before the first frame update
    void Start()
    {
        strPoint = 1;
        strTemp = strPoint;


        //onClick.AddListener(() => SlotToEquipItem(weaponBtn, Equip.WEAPON));
        strPlusButton.onClick.AddListener(() => ClickPlus(strPlusButton));
        Confirm.onClick.AddListener(ConfirmStatus);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ClickPlus(Button btn)
    {
        if (btn == strPlusButton)
        {
            strTemp++;
            strPointText.text = strTemp.ToString();
        }
    }

    void ConfirmStatus()
    {
        strPoint = strTemp;
    }

    
}
