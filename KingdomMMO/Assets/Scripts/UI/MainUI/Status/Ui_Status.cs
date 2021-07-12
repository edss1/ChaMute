using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_Status : MonoBehaviour
{
    PlayerStatus status;
    UI_Inventory inventory;

    DataSaveLoad data;
    [SerializeField]
    GameObject dataObj;

    enum SubStatus
    {
        LEVEL,
        EXP,
        ATK,
        ATKSPEED,
        HIT,
        CRITICAL,
        CRITICALDAMAGE,
        MAGICATTACK,
        MAXHP,
        MAXMP,
        DEF,
        MAGICDEF,
        FLEE,
        MOVESPEED,
        GAINEXP,
        GAINGOLD,
        GAINCOMMONMATERIAL,
        GAINRAREMATERIAL,
        HPREGEN,
        MPREGEN
    }

    #region MainStatus & Text

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

    #endregion

    #region SubStatus & SubStatus Property
    int level;
    int     exp;
    int     maxExp;
    float   expPer;
    int     statAttack;
    int     levelAttack;
    int     itemAtttack;
    float   statAttackSpeed;
    float   itemAttackSpeed;
    int     statHit;
    int     levelHit;
    int     itemHit;
    int     statCritical;
    int     itemCritical;
    int     statCriticalDamage;
    int     itemCriticalDamage;
    int     statMagicAttack;
    int     levelMagicAttack;
    int     itemMagicAttack;
    int     levelHp;
    int     statHp;
    int     itemHp;
    int     levelMp;
    int     statMp;
    int     itemMp;
    int     statDef;
    int     itemDef;
    int     statMagicDef;
    int     itemMagicDef;
    int     statFlee;
    int     itemFlee;
    float   moveSpeed;
    float   gainExp;
    float   gainGold;
    float   gainCommonMaterial;
    float   gainRareMaterial;
    int     statHpRegen;
    int     itemHpRegen;
    int     statMpRegen;
    int     itemMpRegen;


    public int Level { get { return level; } set { level = value; } }
    public int Exp { get { return exp; } set { exp = value; } }
    public int MaxExp { get { return maxExp; } set { maxExp = value; } }
    public float ExpPer { get { return expPer; } set { expPer = value; } }
    public int StatAttack { get { return statAttack; } set { statAttack = value; } }
    public int LevelAttack { get { return levelAttack; } set { levelAttack = value; } }
    public int ItemAtttack { get { return itemAtttack; } set { itemAtttack = value; } }
    public float StatAttackSpeed { get { return statAttackSpeed; } set { statAttackSpeed = value; } }
    public float ItemAttackSpeed { get { return itemAttackSpeed; } set { itemAttackSpeed = value; } }
    public int StatHit { get { return statHit; } set { statHit = value; } }
    public int LevelHit { get { return levelHit; } set { levelHit = value; } }
    public int ItemHit { get { return itemHit; } set { itemHit = value; } }
    public int StatCritical { get { return statCritical; } set { statCritical = value; } }
    public int ItemCritical { get { return itemCritical; } set { itemCritical = value; } }
    public int StatCriticalDamage { get { return statCriticalDamage; } set { statCriticalDamage = value; } }
    public int ItemCriticalDamage { get { return itemCriticalDamage; } set { itemCriticalDamage = value; } }
    public int StatMagicAttack { get { return statMagicAttack; } set { statMagicAttack = value; } }
    public int LevelMagicAttack { get { return levelMagicAttack; } set { levelMagicAttack = value; } }
    public int ItemMagicAttack { get { return itemMagicAttack; } set { itemMagicAttack = value; } }
    public int LevelHp { get { return levelHp; } set { levelHp = value; } }
    public int StatHp { get { return statHp; } set { statHp = value; } }
    public int ItemHp { get { return itemHp; } set { itemHp = value; } }
    public int LevelMp { get { return levelMp; } set { levelMp = value; } }
    public int StatMp { get { return statMp; } set { statMp = value; } }
    public int ItemMp { get { return itemMp; } set { itemMp = value; } }
    public int StatDef { get { return statDef; } set { statDef = value; } }
    public int ItemDef { get { return itemDef; } set { itemDef = value; } }
    public int StatMagicDef { get { return statMagicDef; } set { statMagicDef = value; } }
    public int ItemMagicDef { get { return itemMagicDef; } set { itemMagicDef = value; } }
    public int StatFlee { get { return statFlee; } set { statFlee = value; } }
    public int ItemFlee { get { return itemFlee; } set { itemFlee = value; } }
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    public float GainExp { get { return gainExp; } set { gainExp = value; } }
    public float GainGold { get { return gainGold; } set { gainGold = value; } }
    public float GainCommonMaterial { get { return gainCommonMaterial; } set { gainCommonMaterial = value; } }
    public float GainRareMaterial { get { return gainRareMaterial; } set { gainRareMaterial = value; } }
    public int StatHpRegen { get { return statHpRegen; } set { statHpRegen = value; } }
    public int ItemHpRegen { get { return itemHpRegen; } set { itemHpRegen = value; } }
    public int StatMpRegen { get { return statMpRegen; } set { statMpRegen = value; } }
    public int ItemMpRegen { get { return itemMpRegen; } set { itemMpRegen = value; } }

    #endregion

    [Header("UI 텍스트")]
    [SerializeField] Text levelText;
    [SerializeField] Text expText;
    [SerializeField] Text atkText;
    [SerializeField] Text atkSpeedText;
    [SerializeField] Text hitText;
    [SerializeField] Text criticalText;
    [SerializeField] Text criticalDamageText;
    [SerializeField] Text magicAttackText;
    [SerializeField] Text maxHpText;
    [SerializeField] Text maxMpText;
    [SerializeField] Text defText;
    [SerializeField] Text magicDefText;
    [SerializeField] Text fleeText;
    [SerializeField] Text moveSpeedText;
    [SerializeField] Text gainExpText;
    [SerializeField] Text gainGoldText;
    [SerializeField] Text gainCommonMaterialText;
    [SerializeField] Text gainRareMaterialText;
    [SerializeField] Text hpRegenText;
    [SerializeField] Text mpRegenText;


    List<Text> statusTexts = new List<Text>();




    // Start is called before the first frame update
    void Start()
    {
        data = dataObj.GetComponent<DataSaveLoad>();
        data.LoadPlayerDataToJsonInInventory();

        //초기화
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

        #region OnClickListener 연결

        strPlusButton.onClick.AddListener(() => ClickPlus(strPlusButton));
        dexPlusButton.onClick.AddListener(() => ClickPlus(dexPlusButton));
        agiPlusButton.onClick.AddListener(() => ClickPlus(agiPlusButton));
        vitPlusButton.onClick.AddListener(() => ClickPlus(vitPlusButton));
        intPlusButton.onClick.AddListener(() => ClickPlus(intPlusButton));
        engPlusButton.onClick.AddListener(() => ClickPlus(engPlusButton));
        lukPlusButton.onClick.AddListener(() => ClickPlus(lukPlusButton));
        strMinusButton.onClick.AddListener(() => ClickMinus(strMinusButton));
        dexMinusButton.onClick.AddListener(() => ClickMinus(dexMinusButton));
        agiMinusButton.onClick.AddListener(() => ClickMinus(agiMinusButton));
        vitMinusButton.onClick.AddListener(() => ClickMinus(vitMinusButton));
        intMinusButton.onClick.AddListener(() => ClickMinus(intMinusButton));
        engMinusButton.onClick.AddListener(() => ClickMinus(engMinusButton));
        lukMinusButton.onClick.AddListener(() => ClickMinus(lukMinusButton));
       
        #endregion

        //확인버튼
        Confirm.onClick.AddListener(ConfirmStatus);


        //levelText 
        //expText 
        //atkText 
        //atkSpeedText 
        //hitText 
        //criticalText 
        //criticalDamageText 
        //magicAttackText 
        //maxHpText 
        //maxMpText 
        //defText 
        //magicDefText 
        //fleeText 
        //moveSpeedText 
        //gainExpText 
        //gainGoldText 
        //gainCommonMaterialText 
        //gainRareMaterialText 
        //hpRegenText 
        //mpRegenText 
        statusTexts.Add(levelText );
        statusTexts.Add(expText );
        statusTexts.Add(atkText );
        statusTexts.Add(atkSpeedText );
        statusTexts.Add(hitText );
        statusTexts.Add(criticalText );
        statusTexts.Add(criticalDamageText );
        statusTexts.Add(magicAttackText );
        statusTexts.Add(maxHpText );
        statusTexts.Add(maxMpText );
        statusTexts.Add(defText );
        statusTexts.Add(magicDefText );
        statusTexts.Add(fleeText );
        statusTexts.Add(moveSpeedText );
        statusTexts.Add(gainExpText );
        statusTexts.Add(gainGoldText );
        statusTexts.Add(gainCommonMaterialText );
        statusTexts.Add(gainRareMaterialText );
        statusTexts.Add(hpRegenText );
        statusTexts.Add(mpRegenText );

        for (int i = 0; i < statusTexts.Count; i++)
        {
            statusTexts[i].text = "";
        }

        status = GetComponent<PlayerStatus>();
        inventory = GetComponent<UI_Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        #region MainStatusColorChange
        Util.ColorChange(strPoint, strTemp, strPointText);
        Util.ColorChange(dexPoint, dexTemp, dexPointText);
        Util.ColorChange(agiPoint, agiTemp, agiPointText);
        Util.ColorChange(vitPoint, vitTemp, vitPointText);
        Util.ColorChange(intPoint, intTemp, intPointText);
        Util.ColorChange(engPoint, engTemp, engPointText);
        Util.ColorChange(lukPoint, lukTemp, lukPointText);
        #endregion

        #region MainStatusToText
        strRequirePointText.text = strRequirePoint.ToString();
        dexRequirePointText.text = dexRequirePoint.ToString();
        agiRequirePointText.text = agiRequirePoint.ToString();
        vitRequirePointText.text = vitRequirePoint.ToString();
        intRequirePointText.text = intRequirePoint.ToString();
        engRequirePointText.text = engRequirePoint.ToString();
        lukRequirePointText.text = lukRequirePoint.ToString();
        #endregion

        #region MainStatusCalculatorIncresed
        strRequirePoint = CalculatorStatus(strTemp);
        dexRequirePoint = CalculatorStatus(dexTemp);
        agiRequirePoint = CalculatorStatus(agiTemp);
        vitRequirePoint = CalculatorStatus(vitTemp);
        intRequirePoint = CalculatorStatus(intTemp);
        engRequirePoint = CalculatorStatus(engTemp);
        lukRequirePoint = CalculatorStatus(lukTemp);
        #endregion

        #region SetStatus
        SetStatus(levelText);
        SetStatus(expText);
        SetStatus(atkText);
        SetStatus(atkSpeedText);
        SetStatus(hitText);
        SetStatus(criticalText);
        SetStatus(criticalDamageText);
        SetStatus(magicAttackText);
        SetStatus(maxHpText);
        SetStatus(maxMpText);
        SetStatus(defText);
        SetStatus(magicDefText);
        SetStatus(fleeText);
        SetStatus(moveSpeedText);
        SetStatus(gainExpText);
        SetStatus(gainGoldText);
        SetStatus(gainCommonMaterialText);
        SetStatus(gainRareMaterialText);
        SetStatus(hpRegenText);
        SetStatus(mpRegenText);
        #endregion

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

    

    void SetStatus(Text text)
    {
        if (text == statusTexts[(int)SubStatus.LEVEL])
        {
            text.text = "레벨 : " + status.Level;
        }
        else if (text == statusTexts[(int)SubStatus.EXP])
        {
            text.text = "경험치 : " + status.Exp + " / " + status.MaxExp + $"({status.Exp/status.MaxExp}%)";
        }
        else if (text == statusTexts[(int)SubStatus.ATK])
        {
            text.text = "공격력 : " + (status.Attack+(strTemp + (strTemp/10)*(strTemp / 10))) + " + " + status.ItemAttack;
        }
        else if (text == statusTexts[(int)SubStatus.ATKSPEED])
        {   
                text.text = "공격속도 : " + (status.ItemAttackSpeed * (1+(0.01*agiTemp))).ToString("F1");
        }
        else if (text == statusTexts[(int)SubStatus.HIT])
        {
            text.text = "명중 : " + (status.ItemHit + status.Level + dexTemp);
        }
        else if (text == statusTexts[(int)SubStatus.CRITICAL])
        {
            text.text = "크리티컬 : " + (status.ItemCritical+lukTemp)+"%";
        }
        else if (text == statusTexts[(int)SubStatus.CRITICALDAMAGE])
        {
            text.text = "크리티컬 데미지 : " + (status.ItemCriticalDmg + lukTemp);
        }
        else if (text == statusTexts[(int)SubStatus.MAGICATTACK])
        {
            if (status.ItemMAttack == 0)
                text.text = "마법 공격력 : " + (status.MAttack + (intTemp + (intTemp / 8) * (intTemp / 8)));
            else
                text.text = "마법 공격력 : " + (status.MAttack + (intTemp + (intTemp / 8) * (intTemp / 8))) + " + " + status.ItemMAttack; 
        }
        else if (text == statusTexts[(int)SubStatus.MAXHP])
        {
            text.text = "최대 체력 : " + (status.MaxHp + status.ItemMaxHp + (vitTemp*10) + (vitTemp/10)*(vitTemp/10));
        }
        else if (text == statusTexts[(int)SubStatus.MAXMP])
        {
             text.text = "최대 마나 : " + (status.MaxMana + status.ItemMaxMp + (engTemp * 3) + (engTemp / 20) * (engTemp / 20));
        }
        else if (text == statusTexts[(int)SubStatus.DEF ]) { }
        else if (text == statusTexts[(int)SubStatus.MAGICDEF ]) { }
        else if (text == statusTexts[(int)SubStatus.FLEE ]) { }
        else if (text == statusTexts[(int)SubStatus.MOVESPEED ]) { }
        else if (text == statusTexts[(int)SubStatus.GAINEXP ]) { }
        else if (text == statusTexts[(int)SubStatus.GAINGOLD ]) { }
        else if (text == statusTexts[(int)SubStatus.GAINCOMMONMATERIAL ]) { }
        else if (text == statusTexts[(int)SubStatus.GAINRAREMATERIAL ]) { }
        else if (text == statusTexts[(int)SubStatus.HPREGEN ]) { }
        else if (text == statusTexts[(int)SubStatus.MPREGEN]) { }

    }
}
