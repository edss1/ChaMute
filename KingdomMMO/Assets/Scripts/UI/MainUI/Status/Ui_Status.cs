using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_Status : MonoBehaviour
{
    PlayerStatus status;

    [Header("공용")]
    [SerializeField]
    public Text statusPointText;       //잔여 포인트
    public int statusPoint;       //잔여 포인트
    public int statusPointTemp;
    [SerializeField]
    Button Confirm;


    [Header("STR")]
    [SerializeField]
    public Text strPointText;   //힘스탯 포인트 텍스트
    [HideInInspector]
    public int strPoint;        //힘스탯 포인트
    [SerializeField]
    Text strRequirePointText;      //요구하는 스탯 포인트
    int strRequirePoint;           //요구하는 스탯
    [HideInInspector]
    public int strTemp;         //힘스탯 잠깐 저장하는 용도
    [SerializeField]
    Button strPlusButton;       //힘스탯 추가 버튼
    [SerializeField]
    Button strMinusButton;      //힘스탯 마이너스 버튼

    [Header("DEX")]
    [SerializeField]
    public Text dexPointText;
    [HideInInspector]
    public int dexPoint;
    [SerializeField]
    Text dexRequirePointText;
    int dexRequirePoint;
    [HideInInspector]
    public int dexTemp;
    [SerializeField]
    Button dexPlusButton;
    [SerializeField]
    Button dexMinusButton;


    [Header("AGI")]
    [SerializeField]
    public Text agiPointText;
    [HideInInspector]
    public int agiPoint;
    [SerializeField]
    Text agiRequirePointText;
    int agiRequirePoint;
    [HideInInspector]
    public int agiTemp;
    [SerializeField]
    Button agiPlusButton;
    [SerializeField]
    Button agiMinusButton;



    [Header("VIT")]
    [SerializeField]
    public Text vitPointText;
    [HideInInspector]
    public int vitPoint;
    [SerializeField]
    Text vitRequirePointText;
    int vitRequirePoint;
    [HideInInspector]
    public int vitTemp;
    [SerializeField]
    Button vitPlusButton;
    [SerializeField]
    Button vitMinusButton;

    [Header("INT")]
    [SerializeField]
    public Text intPointText;
    [HideInInspector]
    public int intPoint;
    [SerializeField]
    Text intRequirePointText;
    int intRequirePoint;
    [HideInInspector]
    public int intTemp;
    [SerializeField]
    Button intPlusButton;
    [SerializeField]
    Button intMinusButton;



    [Header("ENG")]
    [SerializeField]
    public Text engPointText;
    [HideInInspector]
    public int engPoint;
    [SerializeField]
    Text engRequirePointText;
    int engRequirePoint;
    [HideInInspector]
    public int engTemp;
    [SerializeField]
    Button engPlusButton;
    [SerializeField]
    Button engMinusButton;


    [Header("LUK")]
    [SerializeField]
    public Text lukPointText;
    [HideInInspector]
    public int lukPoint;
    [SerializeField]
    Text lukRequirePointText;
    int lukRequirePoint;
    [HideInInspector]
    public int lukTemp;
    [SerializeField]
    Button lukPlusButton;
    [SerializeField]
    Button lukMinusButton;


    // Start is called before the first frame update
    void Start()
    {
        strPoint = 1;
        dexPoint = 1;
        agiPoint = 1;
        vitPoint = 1;
        intPoint = 1;
        engPoint = 1;
        lukPoint = 1;

        statusPoint = 30;

        strTemp = strPoint;
        dexTemp = dexPoint;
        agiTemp = agiPoint;
        vitTemp = vitPoint;
        intTemp = intPoint;
        engTemp = engPoint;
        lukTemp = lukPoint;

        statusPointTemp = statusPoint;

        statusPointText.text = statusPoint.ToString();

        strPlusButton.onClick.AddListener(() => ClickPlus(strPlusButton));
        strMinusButton.onClick.AddListener(() => ClickMinus(strMinusButton));
        dexPlusButton.onClick.AddListener(() => ClickPlus(dexPlusButton));
        agiPlusButton.onClick.AddListener(() => ClickPlus(agiPlusButton));
        vitPlusButton.onClick.AddListener(() => ClickPlus(vitPlusButton));
        intPlusButton.onClick.AddListener(() => ClickPlus(intPlusButton));
        engPlusButton.onClick.AddListener(() => ClickPlus(engPlusButton));
        lukPlusButton.onClick.AddListener(() => ClickPlus(lukPlusButton));

        Confirm.onClick.AddListener(ConfirmStatus);

    }

    // Update is called once per frame
    void Update()
    {
        ColorChange(strPoint, strTemp, strPointText);

        strRequirePointText.text = strRequirePoint.ToString();
        dexRequirePointText.text = dexRequirePoint.ToString();
        agiRequirePointText.text = agiRequirePoint.ToString();
        vitRequirePointText.text = vitRequirePoint.ToString();
        intRequirePointText.text = intRequirePoint.ToString();
        engRequirePointText.text = engRequirePoint.ToString();
        lukRequirePointText.text = lukRequirePoint.ToString();

        strRequirePoint = CalculatorStatus(strTemp);
        dexRequirePoint = CalculatorStatus(dexTemp);
        agiRequirePoint = CalculatorStatus(agiTemp);
        vitRequirePoint = CalculatorStatus(vitTemp);
        intRequirePoint = CalculatorStatus(intTemp);
        engRequirePoint = CalculatorStatus(engTemp);
        lukRequirePoint = CalculatorStatus(lukTemp);
    }

    void ClickPlus(Button btn)
    {
        if (btn == strPlusButton)
        {
            if (statusPointTemp >= strRequirePoint)
            {
                strTemp++;
                statusPointTemp -= strRequirePoint;
                strPointText.text = strTemp.ToString();
                statusPointText.text = statusPointTemp.ToString();
            }
        }

        else if (btn == dexPlusButton)
        {
            if (statusPointTemp >= dexRequirePoint)
            {

                dexTemp++;
                statusPointTemp -= dexRequirePoint;
                dexPointText.text = dexTemp.ToString();
                statusPointText.text = statusPointTemp.ToString();
            }
        }
        else if (btn == agiPlusButton)
        {
            if (statusPointTemp >= agiRequirePoint)
            {

                agiTemp++;
                statusPointTemp -= agiRequirePoint;
                agiPointText.text = agiTemp.ToString();
                statusPointText.text = statusPointTemp.ToString();
            }
        }
        else if (btn == vitPlusButton)
        {
            if (statusPointTemp >= vitRequirePoint)
            {

                vitTemp++;
                statusPointTemp -= vitRequirePoint;
                vitPointText.text = vitTemp.ToString();
                statusPointText.text = statusPointTemp.ToString();
            }
        }
        else if (btn == intPlusButton)
        {
            if (statusPointTemp >= intRequirePoint)
            {

                intTemp++;
                statusPointTemp -= intRequirePoint;
                intPointText.text = intTemp.ToString();
                statusPointText.text = statusPointTemp.ToString();
            }
        }
        else if (btn == engPlusButton)
        {
            if (statusPointTemp >= engRequirePoint)
            {

                engTemp++;
                statusPointTemp -= engRequirePoint;
                engPointText.text = engTemp.ToString();
                statusPointText.text = statusPointTemp.ToString();
            }
        }
        else if (btn == lukPlusButton)
        {
            if (statusPointTemp >= lukRequirePoint)
            {
                lukTemp++;
                statusPointTemp -= lukRequirePoint;
                lukPointText.text = lukTemp.ToString();
                statusPointText.text = statusPointTemp.ToString();
            }
        }

    }

    void ClickMinus(Button btn)
    {
        if (btn == strMinusButton)
        {
            if (strTemp > strPoint)
            {
                strRequirePoint = CalculatorStatus(strTemp - 1);
                strTemp--;
                statusPointTemp += strRequirePoint;
                strPointText.text = strTemp.ToString();
                statusPointText.text = statusPointTemp.ToString();
            }
        }

        if (btn == dexMinusButton)
        {
            if (dexTemp > dexPoint)
            {
                dexRequirePoint = CalculatorStatus(dexTemp - 1);
                dexTemp--;
                statusPointTemp += dexRequirePoint;
                dexPointText.text = dexTemp.ToString();
                statusPointText.text = statusPointTemp.ToString();
            }
        }

        if (btn == agiMinusButton)
        {
            if (agiTemp > agiPoint)
            {
                agiRequirePoint = CalculatorStatus(agiTemp - 1);
                agiTemp--;
                statusPointTemp += agiRequirePoint;
                agiPointText.text = agiTemp.ToString();
                statusPointText.text = statusPointTemp.ToString();
            }
        }

        if (btn == vitMinusButton)
        {
            if (vitTemp > vitPoint)
            {
                vitRequirePoint = CalculatorStatus(vitTemp - 1);
                vitTemp--;
                statusPointTemp += vitRequirePoint;
                vitPointText.text = vitTemp.ToString();
                statusPointText.text = statusPointTemp.ToString();
            }
        }

        if (btn == intMinusButton)
        {
            if (intTemp > intPoint)
            {
                intRequirePoint = CalculatorStatus(intTemp - 1);
                intTemp--;
                statusPointTemp += intRequirePoint;
                intPointText.text = intTemp.ToString();
                statusPointText.text = statusPointTemp.ToString();
            }
        }

        if (btn == engMinusButton)
        {
            if (engTemp > engPoint)
            {
                engRequirePoint = CalculatorStatus(engTemp - 1);
                engTemp--;
                statusPointTemp += engRequirePoint;
                engPointText.text = engTemp.ToString();
                statusPointText.text = statusPointTemp.ToString();
            }
        }
        if (btn == lukMinusButton)
        {
            if (lukTemp > lukPoint)
            {
                lukRequirePoint = CalculatorStatus(lukTemp - 1);
                lukTemp--;
                statusPointTemp += lukRequirePoint;
                lukPointText.text = lukTemp.ToString();
                statusPointText.text = statusPointTemp.ToString();
            }
        }

    }

    void ConfirmStatus()
    {
        strPoint = strTemp;

        dexPoint = dexTemp;
        agiPoint = agiTemp;
        vitPoint = vitTemp;
        intPoint = intTemp;
        engPoint = engTemp;
        lukPoint = lukTemp;

        statusPoint = statusPointTemp;
    }


    int CalculatorStatus(int status)
    {
        return (1 + (status / 10));
    }

    void ColorChange(int status, int statusTemp, Text text)
    {
        if (statusTemp > status)
            text.color = new Color(255, 0, 0);
        else
            text.color = new Color(0, 0, 0);
    }
}
