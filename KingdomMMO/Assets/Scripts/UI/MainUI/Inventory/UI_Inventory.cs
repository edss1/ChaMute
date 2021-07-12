//UI_Inventory 스크립트
/*
 * 작성일자 : 2021-06-02
스크립트 설명 : 인벤토리 스크립트
스크립트 사용법 : 
                 
수정일자(1차) : 06-15
수정내용(1차) : 슬롯 버튼화, 툴팁 페이지 추가, 툴팁에 아이템아이콘 출력

수정일자(2차) : 06-16
수정내용(2차) : 무기 툴팁 옵션 추가(이름, 옵션 등등) List이용하여 텍스트

수정일자(3차) : 06-17
수정내용(3차) : 나머지 툴팁 텍스트 추가, Button 작업 시작
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class UI_Inventory : MonoBehaviour
{
    DataSaveLoad data;
    public GameObject dataSaveLoad;

    GameObject inventoryPanel;
    GameObject slotPanel;
    
    public GameObject itemData;
    ItemDatabase database;

    [SerializeField]
    Button inventorySlot;

    public GameObject inventoryItem;

    #region ToolTip 변수
    [Header("ToolTip관련")]
    [SerializeField]
    Image ToolTipImage;
    [SerializeField]
    Button ToolTipCloseButton;

    [Header("ToolTip세부내용")]
    [SerializeField]
    Image toolTipItemImg;       //아이템 이미지
    [SerializeField]
    Text itemNameText;          //아이템 이름
    [SerializeField]
    Text itemInfoText;              //아이템 정보
    [SerializeField]
    Text itemTypeText;              //아이템 타입
    [SerializeField]
    Text itemStandardOneText;       //첫번째 옵션
    [SerializeField]
    Text itemStandardTwoText;       //두번째 옵션       
    [SerializeField]
    Text itemStandardThreeText;     //세번째 옵션       
    [SerializeField]
    Text itemOneOptionText;         //첫번째 옵션
    [SerializeField]
    Text itemTwoOptionText;         //두번째 옵션
    [SerializeField]
    Text itemThreeOptionText;       //세번째 옵션
    [SerializeField]
    Text itemFourOptionText;        //네번째 옵션
    [SerializeField]
    Text itemFiveOptionText;        //다섯번째 옵션
    [SerializeField]
    Text itemSixOptionText;         //여섯번째 옵션

    [Header("ToolTip 버튼관련")]
    [SerializeField]
    Button equipButton;             //장착 버튼
    [SerializeField]
    Button piecesButton;            //분해 버튼
    [SerializeField]
    Button sellingButton;           //판매 버튼
    [SerializeField]
    Button reinforceButton;         //강화 버튼
    [SerializeField]
    Button makingButton;            //제작 버튼
    [SerializeField]
    Button unlockButton;            //해제 버튼
    [SerializeField]
    Button exchangeButton;          //교체 버튼

    #endregion
    int slotAmount;

    [SerializeField]
    int clickedID;
    [SerializeField]
    int slotNumber;

    Item clickedItem;

    int equipSlotAmount;


    [Header("장비슬롯")]
    [SerializeField] Button helmetBtn;
    [SerializeField] Button amoreBtn;
    [SerializeField] Button weaponBtn;
    [SerializeField] Button subWeaponBtn;
    [SerializeField] Button cloakBtn;
    [SerializeField] Button shoesBtn;
    [SerializeField] Button accessoryOneBtn;
    [SerializeField] Button accessoryTwoBtn;

    [Header("참 슬롯")]
    [SerializeField] Button expCharmBtn;
    [SerializeField] Button goldCharmBtn;
    [SerializeField] Button rareMaterialCharmBtn;
    [SerializeField] Button nomalMaterialCharmBtn;

    [Header("퀵슬롯")]
    [SerializeField] Button potionOneBtn;
    [SerializeField] Button potionTwoBtn;
    [SerializeField] Button potionThreeBtn;

    
    public enum Equip
    {
        HELMET,
        AMORE,
        WEAPON,
        SHIELD,
        CLOAK,
        SHOES,
        ACCESSORYONE,
        ACCESSORYTWO,
        EXPCHARM,
        GOLDCHARM,
        RAREMATERIALCHARM,
        NOMALMATERIALCHARM,
        POTIONONE,
        POTIONTWO,
        POTIONTHREE,
    }

    public List<Item> items = new List<Item>();
    public List<Button> slots = new List<Button>();
    public List<Button> equipSlots = new List<Button>();
    public Dictionary<int, Item> equipItems = new Dictionary<int, Item>();

    private void Start()
    {
        ToolTipImage.gameObject.SetActive(false);

        database = itemData.GetComponent<ItemDatabase>();

        slotAmount = 30;
        equipSlotAmount = 15;
        inventoryPanel = GameObject.Find("InventoryPanel");
        slotPanel = inventoryPanel.transform.Find("Slot Panel").gameObject;


        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[i].transform.SetParent(slotPanel.transform);
        }


        equipItems.Add((int)Equip.HELMET, new Item());
        equipItems.Add((int)Equip.AMORE, new Item());
        equipItems.Add((int)Equip.WEAPON, new Item());
        equipItems.Add((int)Equip.SHIELD, new Item());
        equipItems.Add((int)Equip.CLOAK, new Item());
        equipItems.Add((int)Equip.SHOES, new Item());
        equipItems.Add((int)Equip.ACCESSORYONE, new Item());
        equipItems.Add((int)Equip.ACCESSORYTWO, new Item());
        equipItems.Add((int)Equip.EXPCHARM, new Item());
        equipItems.Add((int)Equip.GOLDCHARM, new Item());
        equipItems.Add((int)Equip.RAREMATERIALCHARM, new Item());
        equipItems.Add((int)Equip.NOMALMATERIALCHARM, new Item());
        equipItems.Add((int)Equip.POTIONONE, new Item());
        equipItems.Add((int)Equip.POTIONTWO, new Item());
        equipItems.Add((int)Equip.POTIONTHREE, new Item());



        equipSlots.Add(helmetBtn);
        equipSlots.Add(amoreBtn);
        equipSlots.Add(weaponBtn);
        equipSlots.Add(subWeaponBtn);
        equipSlots.Add(cloakBtn);
        equipSlots.Add(shoesBtn);
        equipSlots.Add(accessoryOneBtn);
        equipSlots.Add(accessoryTwoBtn);
        equipSlots.Add(expCharmBtn);
        equipSlots.Add(goldCharmBtn);
        equipSlots.Add(rareMaterialCharmBtn);
        equipSlots.Add(nomalMaterialCharmBtn);
        equipSlots.Add(potionOneBtn);
        equipSlots.Add(potionTwoBtn);
        equipSlots.Add(potionThreeBtn);

        
        equipButton.gameObject.SetActive(false);
        piecesButton.gameObject.SetActive(false);
        sellingButton.gameObject.SetActive(false);
        reinforceButton.gameObject.SetActive(false);
        makingButton.gameObject.SetActive(false);
        unlockButton.gameObject.SetActive(false);
        exchangeButton.gameObject.SetActive(false);

        //****(중요)****AddItem 사용시, ItemDatabase.cs의 AddItemToList에서 database 추가해야 작동함
        AddItem(11001);
        AddItem(11002);
        AddItem(21001);
        AddItem(31001);
        AddItem(41001);
        AddItem(51001);
        AddItem(61001);
        AddItem(61001);
        AddItem(61001);
        AddItem(61001);
        AddItem(61001);
        AddItem(61001);
        AddItem(61001);
        AddItem(61001);
        AddItem(61001);
        AddItem(61001);
        AddItem(61001);
        AddItem(61001);
        AddItem(62001);
        AddItem(71001);
        AddItem(61001);
        AddItem(61001);


        data = dataSaveLoad.GetComponent<DataSaveLoad>();
        

        data.LoadItemDataToJson();
    }

    void Update()
    {
        for (int i = 0; i < slots.Count; i++)
        {

            //슬롯에 아이템이 있을때
            if (items[i].ItemID != -1)
            {

                //클릭한 슬롯이 슬롯의 인덱스를 확인한다.
                if (EventSystem.current.currentSelectedGameObject == slots[i].gameObject)
                {
                    clickedItem = items[i];
                    slotNumber = i;

                    Debug.Log(slotNumber);
                    Debug.Log(items[i].ItemID);

                    
                    
                    if(slots[i].gameObject.transform.childCount != 0)
                    slots[i].onClick.AddListener(InventoryTooltip);

                }
            }


        }

        for (int i = 0; i < equipSlots.Count; i++)
        {
            //슬롯에 아이템이 있을때
            if (equipItems[i].ItemID != -1)
            {

                //클릭한 슬롯이 슬롯의 인덱스를 확인한다.
                if (EventSystem.current.currentSelectedGameObject == equipSlots[i].gameObject)
                {
                    clickedItem = equipItems[i];
                    slotNumber = i;
                    if (equipSlots[i].gameObject.transform.childCount != 0)
                        equipSlots[i].onClick.AddListener(EquipTooltip);

                    
                    Debug.Log(slotNumber);
                    // if (slots[i].gameObject.transform.childCount != 0)
                    //     slots[i].onClick.AddListener(EquipTooltip);

                }
            }
        }
            ToolTipCloseButton.onClick.AddListener(TooltipClose);

    }


    public void AddItem(int id)
    {
      
        Item itemToAdd = database.AccessItemById(id);

        //Debug.Log(CheckItemInInventory(itemToAdd).ToString());

        if (itemToAdd.ItemStackable && CheckItemInInventory(itemToAdd))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ItemID == id)
                {
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    break;
                }
            }
        }
        else
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ItemID == -1)
                {

                    items[i] = itemToAdd;

                    GameObject itemObj = Instantiate(inventoryItem);

                    itemObj.GetComponent<ItemData>().item = itemToAdd;
                    itemObj.GetComponent<ItemData>().slot = i;

                    itemObj.transform.SetParent(slots[i].transform);
                    itemObj.GetComponent<Image>().sprite = itemToAdd.ItemIcon;
                    itemObj.transform.position = slots[i].transform.position;
                    itemObj.name = itemToAdd.ItemName;
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount = 1;

                    break;
                }
            }


        }
    }

    bool CheckItemInInventory(Item item)
    {
     
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ItemID == item.ItemID) return true;
        }

        return false;
    }


    void InventoryTooltip()
    {
        equipButton.gameObject.SetActive(false);
        piecesButton.gameObject.SetActive(false);
        sellingButton.gameObject.SetActive(false);
        reinforceButton.gameObject.SetActive(false);
        makingButton.gameObject.SetActive(false);
        unlockButton.gameObject.SetActive(false);
        exchangeButton.gameObject.SetActive(false);


        ToolTipImage.gameObject.SetActive(true);

        equipButton.onClick.RemoveAllListeners();
        exchangeButton.onClick.RemoveAllListeners();

        //옵션 공란으로 초기화
        itemStandardOneText.text = "";
        itemStandardTwoText.text = "";
        itemStandardThreeText.text = "";
        itemOneOptionText.text = "";
        itemTwoOptionText.text = "";
        itemThreeOptionText.text = "";
        itemFourOptionText.text = "";
        itemFiveOptionText.text = "";
        itemSixOptionText.text = "";

        toolTipItemImg.sprite = items[slotNumber].ItemIcon;
        string nameText = items[slotNumber].ItemName;
        string materialText = "";
        if (items[slotNumber].ItemMaterial != "")
            materialText = "재질 : " + items[slotNumber].ItemMaterial;
        string weightText = "무게 : " + items[slotNumber].ItemWeight.ToString();

        itemInfoText.text = items[slotNumber].ItemInfo;

        string gradeText;
        //아이템 등급
        switch (items[slotNumber].ItemGrade)
        {
            case "common":
                gradeText = "등급 : 일반";
                break;
            case "uncommon":
                gradeText = "등급 : 매직";
                break;
            case "rare":
                gradeText = "등급 : 레어";
                break;
            case "unique":
                gradeText = "등급 : 유니크";
                break;
            case "legendary":
                gradeText = "등급 : 레전더리";
                break;
            default:
                gradeText = "0";
                break;
        }


        List<string> standardOptionTexts = new List<string>();

        standardOptionTexts.Add(nameText);  //이름
        if (materialText != "")
            standardOptionTexts.Add(materialText);  //재질
        if (gradeText != "0")
            standardOptionTexts.Add(gradeText); //등급
        if (weightText != null)
            standardOptionTexts.Add(weightText); //무게

        //기본 옵션
        switch (standardOptionTexts.Count)
        {
            case 2:
                itemNameText.text = standardOptionTexts[0];
                itemStandardOneText.text = standardOptionTexts[1];
                break;
            case 3:
                itemNameText.text = standardOptionTexts[0];
                itemStandardOneText.text = standardOptionTexts[1];
                itemStandardTwoText.text = standardOptionTexts[2];
                break;
            case 4:
                itemNameText.text = standardOptionTexts[0];
                itemStandardOneText.text = standardOptionTexts[1];
                itemStandardTwoText.text = standardOptionTexts[2];
                itemStandardThreeText.text = standardOptionTexts[3];
                break;
        }


        List<string> optionTexts = new List<string>();


        switch (items[slotNumber].itemType)
        {
            case Define.ItemType.Weapon:
                {
                    itemTypeText.text = "타입 : 무기";


                    string attackText = "공격력 : " + items[slotNumber].ItemAttack.ToString();
                    string mAttackText = "마법 공격력 : " + items[slotNumber].ItemMAttack.ToString();
                    string atkSpeedText = "공격 속도 : " + items[slotNumber].ItemAtkSpeed.ToString();
                    string hitText = "명중 +" + items[slotNumber].ItemHit.ToString();
                    string criticalText = "크리티컬 +" + items[slotNumber].ItemCritical.ToString() + "%";
                    string criticalDmgText = "크리티컬 데미지 +" + items[slotNumber].ItemCriticalDamage.ToString() + "%";

                    if (items[slotNumber].ItemAttack != 0)
                        optionTexts.Add(attackText);
                    if (items[slotNumber].ItemMAttack != 0)
                        optionTexts.Add(mAttackText);
                    if (items[slotNumber].ItemAtkSpeed != 0)
                        optionTexts.Add(atkSpeedText);
                    if (items[slotNumber].ItemHit != 0)
                        optionTexts.Add(hitText);
                    if (items[slotNumber].ItemCritical != 0)
                        optionTexts.Add(criticalText);
                    if (items[slotNumber].ItemCriticalDamage != 0)
                        optionTexts.Add(criticalDmgText);


                    //버튼 활성화
                    if(equipItems[(int)Equip.WEAPON].ItemID == -1)
                    {
                    equipButton.gameObject.SetActive(true);
                    equipButton.onClick.AddListener(() =>SlotToEquipItem(weaponBtn,Equip.WEAPON));
                    }
                    else
                    {
                        exchangeButton.gameObject.SetActive(true);
                        exchangeButton.onClick.AddListener(() =>ExchangeItem(weaponBtn,Equip.WEAPON));
                    }

                    reinforceButton.gameObject.SetActive(true);
                    
                }
                break;
            case Define.ItemType.Amore:
                {
                    itemTypeText.text = "타입 : 방어구";

                    string defText = "방어력 : " + items[slotNumber].ItemDef.ToString();
                    string mDefText = "마법 방어력 : " + items[slotNumber].ItemMDef.ToString();

                    string maxHpText = "최대 체력 +" + items[slotNumber].ItemMaxHp.ToString();
                    string maxManaText = "최대 마나 +" + items[slotNumber].ItemMaxMana.ToString();
                    string hpRegenText = "체력 재생 +" + items[slotNumber].ItemHpRegen.ToString();
                    string mpRegenText = "마나 재생 +" + items[slotNumber].ItemMpRegen.ToString();
                    string maxWeightText = " 무게 보너스 +" + items[slotNumber].ItemMaxWeight.ToString();
                    string fleeText = "회피 +" + items[slotNumber].ItemFlee.ToString();


                    if (items[slotNumber].ItemMaxHp != 0)
                        optionTexts.Add(maxHpText);
                    if (items[slotNumber].ItemMaxMana != 0)
                        optionTexts.Add(maxManaText);
                    if (items[slotNumber].ItemHpRegen != 0)
                        optionTexts.Add(hpRegenText);
                    if (items[slotNumber].ItemMpRegen != 0)
                        optionTexts.Add(mpRegenText);
                    if (items[slotNumber].ItemMaxWeight != 0)
                        optionTexts.Add(maxWeightText);
                    if (items[slotNumber].ItemFlee != 0)
                        optionTexts.Add(fleeText);

                    //버튼 활성화
                    equipButton.gameObject.SetActive(true);
                    equipButton.onClick.AddListener(() => SlotToEquipItem(amoreBtn, Equip.AMORE));
                    reinforceButton.gameObject.SetActive(true);

                }
                break;
            case Define.ItemType.Helmet:
                {
                    itemTypeText.text = "타입 : 방어구";

                    string defText = "방어력 : " + items[slotNumber].ItemDef.ToString();
                    string mDefText = "마법 방어력 : " + items[slotNumber].ItemMDef.ToString();

                    string maxHpText = "최대 체력 +" + items[slotNumber].ItemMaxHp.ToString();
                    string maxManaText = "최대 마나 +" + items[slotNumber].ItemMaxMana.ToString();
                    string hpRegenText = "체력 재생 +" + items[slotNumber].ItemHpRegen.ToString();
                    string mpRegenText = "마나 재생 +" + items[slotNumber].ItemMpRegen.ToString();
                    string maxWeightText = " 무게 보너스 +" + items[slotNumber].ItemMaxWeight.ToString();
                    string fleeText = "회피 +" + items[slotNumber].ItemFlee.ToString();


                    if (items[slotNumber].ItemMaxHp != 0)
                        optionTexts.Add(maxHpText);
                    if (items[slotNumber].ItemMaxMana != 0)
                        optionTexts.Add(maxManaText);
                    if (items[slotNumber].ItemHpRegen != 0)
                        optionTexts.Add(hpRegenText);
                    if (items[slotNumber].ItemMpRegen != 0)
                        optionTexts.Add(mpRegenText);
                    if (items[slotNumber].ItemMaxWeight != 0)
                        optionTexts.Add(maxWeightText);
                    if (items[slotNumber].ItemFlee != 0)
                        optionTexts.Add(fleeText);

                    //버튼 활성화
                    equipButton.gameObject.SetActive(true);
                    equipButton.onClick.AddListener(() => SlotToEquipItem(helmetBtn, Equip.HELMET));
                    reinforceButton.gameObject.SetActive(true);

                }
                break;
            case Define.ItemType.Shoes:
                {
                    itemTypeText.text = "타입 : 방어구";

                    string defText = "방어력 : " + items[slotNumber].ItemDef.ToString();
                    string mDefText = "마법 방어력 : " + items[slotNumber].ItemMDef.ToString();

                    string maxHpText = "최대 체력 +" + items[slotNumber].ItemMaxHp.ToString();
                    string maxManaText = "최대 마나 +" + items[slotNumber].ItemMaxMana.ToString();
                    string hpRegenText = "체력 재생 +" + items[slotNumber].ItemHpRegen.ToString();
                    string mpRegenText = "마나 재생 +" + items[slotNumber].ItemMpRegen.ToString();
                    string maxWeightText = " 무게 보너스 +" + items[slotNumber].ItemMaxWeight.ToString();
                    string fleeText = "회피 +" + items[slotNumber].ItemFlee.ToString();


                    if (items[slotNumber].ItemMaxHp != 0)
                        optionTexts.Add(maxHpText);
                    if (items[slotNumber].ItemMaxMana != 0)
                        optionTexts.Add(maxManaText);
                    if (items[slotNumber].ItemHpRegen != 0)
                        optionTexts.Add(hpRegenText);
                    if (items[slotNumber].ItemMpRegen != 0)
                        optionTexts.Add(mpRegenText);
                    if (items[slotNumber].ItemMaxWeight != 0)
                        optionTexts.Add(maxWeightText);
                    if (items[slotNumber].ItemFlee != 0)
                        optionTexts.Add(fleeText);

                    //버튼 활성화
                    equipButton.gameObject.SetActive(true);
                    equipButton.onClick.AddListener(() => SlotToEquipItem(shoesBtn, Equip.SHOES));
                    reinforceButton.gameObject.SetActive(true);


                }
                break;
            case Define.ItemType.Cloak:
                {
                    itemTypeText.text = "타입 : 방어구";

                    string defText = "방어력 : " + items[slotNumber].ItemDef.ToString();
                    string mDefText = "마법 방어력 : " + items[slotNumber].ItemMDef.ToString();

                    string maxHpText = "최대 체력 +" + items[slotNumber].ItemMaxHp.ToString();
                    string maxManaText = "최대 마나 +" + items[slotNumber].ItemMaxMana.ToString();
                    string hpRegenText = "체력 재생 +" + items[slotNumber].ItemHpRegen.ToString();
                    string mpRegenText = "마나 재생 +" + items[slotNumber].ItemMpRegen.ToString();
                    string maxWeightText = " 무게 보너스 +" + items[slotNumber].ItemMaxWeight.ToString();
                    string fleeText = "회피 +" + items[slotNumber].ItemFlee.ToString();


                    if (items[slotNumber].ItemMaxHp != 0)
                        optionTexts.Add(maxHpText);
                    if (items[slotNumber].ItemMaxMana != 0)
                        optionTexts.Add(maxManaText);
                    if (items[slotNumber].ItemHpRegen != 0)
                        optionTexts.Add(hpRegenText);
                    if (items[slotNumber].ItemMpRegen != 0)
                        optionTexts.Add(mpRegenText);
                    if (items[slotNumber].ItemMaxWeight != 0)
                        optionTexts.Add(maxWeightText);
                    if (items[slotNumber].ItemFlee != 0)
                        optionTexts.Add(fleeText);

                    //버튼 활성화
                    equipButton.gameObject.SetActive(true);
                    equipButton.onClick.AddListener(() => SlotToEquipItem(cloakBtn, Equip.CLOAK));
                    reinforceButton.gameObject.SetActive(true);

                }
                break;
            case Define.ItemType.Shield:
                {
                    itemTypeText.text = "타입 : 방어구";

                    string defText = "방어력 : " + items[slotNumber].ItemDef.ToString();
                    string mDefText = "마법 방어력 : " + items[slotNumber].ItemMDef.ToString();

                    string maxHpText = "최대 체력 +" + items[slotNumber].ItemMaxHp.ToString();
                    string maxManaText = "최대 마나 +" + items[slotNumber].ItemMaxMana.ToString();
                    string hpRegenText = "체력 재생 +" + items[slotNumber].ItemHpRegen.ToString();
                    string mpRegenText = "마나 재생 +" + items[slotNumber].ItemMpRegen.ToString();
                    string maxWeightText = " 무게 보너스 +" + items[slotNumber].ItemMaxWeight.ToString();
                    string fleeText = "회피 +" + items[slotNumber].ItemFlee.ToString();


                    if (items[slotNumber].ItemMaxHp != 0)
                        optionTexts.Add(maxHpText);
                    if (items[slotNumber].ItemMaxMana != 0)
                        optionTexts.Add(maxManaText);
                    if (items[slotNumber].ItemHpRegen != 0)
                        optionTexts.Add(hpRegenText);
                    if (items[slotNumber].ItemMpRegen != 0)
                        optionTexts.Add(mpRegenText);
                    if (items[slotNumber].ItemMaxWeight != 0)
                        optionTexts.Add(maxWeightText);
                    if (items[slotNumber].ItemFlee != 0)
                        optionTexts.Add(fleeText);

                    //버튼 활성화
                    equipButton.gameObject.SetActive(true);
                    equipButton.onClick.AddListener(() => SlotToEquipItem(subWeaponBtn, Equip.SHIELD));
                    reinforceButton.gameObject.SetActive(true);


                }
                break;
            case Define.ItemType.Accessory:
                {
                    itemTypeText.text = "타입 : 악세서리";

                    string strText = "STR +" + items[slotNumber].ItemStr;
                    string dexText = "DEX +" + items[slotNumber].ItemDex;
                    string agiText = "AGI +" + items[slotNumber].ItemAgi;
                    string vitText = "VIT +" + items[slotNumber].ItemVit;
                    string intText = "INT +" + items[slotNumber].ItemInt;
                    string engText = "ENG +" + items[slotNumber].ItemEng;
                    string lukText = "LUK +" + items[slotNumber].ItemLuk;
                    string accDefText = "방어력 +" + items[slotNumber].ItemAccessoryDef;
                    string accMdefText = "마법 방어력 +" + items[slotNumber].ItemAccessoryMDef;
                    string accAtkText = "공격력 +" + items[slotNumber].ItemAccessoryAtk;
                    string accMatkText = "마법 공격력 +" + items[slotNumber].ItemAccessoryMAtk;
                    string accMaxHp = "최대 체력 +" + items[slotNumber].ItemAccessoryMaxHp;
                    string accMaxMana = "최대 마나 +" + items[slotNumber].ItemAccessoryMaxMana;

                    if (items[slotNumber].ItemStr != 0)
                        optionTexts.Add(strText);
                    if (items[slotNumber].ItemDex != 0)
                        optionTexts.Add(dexText);
                    if (items[slotNumber].ItemAgi != 0)
                        optionTexts.Add(agiText);
                    if (items[slotNumber].ItemVit != 0)
                        optionTexts.Add(vitText);
                    if (items[slotNumber].ItemInt != 0)
                        optionTexts.Add(intText);
                    if (items[slotNumber].ItemEng != 0)
                        optionTexts.Add(engText);
                    if (items[slotNumber].ItemLuk != 0)
                        optionTexts.Add(lukText);
                    if (items[slotNumber].ItemAccessoryDef != 0)
                        optionTexts.Add(accDefText);
                    if (items[slotNumber].ItemAccessoryMDef != 0)
                        optionTexts.Add(accMdefText);
                    if (items[slotNumber].ItemAccessoryAtk != 0)
                        optionTexts.Add(accAtkText);
                    if (items[slotNumber].ItemAccessoryMAtk != 0)
                        optionTexts.Add(accMatkText);
                    if (items[slotNumber].ItemAccessoryMaxHp != 0)
                        optionTexts.Add(accMaxHp);
                    if (items[slotNumber].ItemAccessoryMaxMana != 0)
                        optionTexts.Add(accMaxMana);

                    //버튼 활성화
                    equipButton.gameObject.SetActive(true);
                    equipButton.onClick.AddListener(() => SlotToEquipItem(accessoryOneBtn, Equip.ACCESSORYONE));
                }
                break;
            case Define.ItemType.Material:
                {
                    itemTypeText.text = "타입 : 재료";

                    sellingButton.gameObject.SetActive(true);
                }
                break;
            case Define.ItemType.Useable:
                {
                    itemTypeText.text = "타입 : 소모품";

                    string potionHpText = "체력 " + items[slotNumber].ItemPotionHp.ToString() + "증가";
                    string potionManaRegenText = "마나 재생량 " + items[slotNumber].ItemPotionManaRegen.ToString() + "증가";
                    string potionMoveSpeedText = "이동속도 " + items[slotNumber].ItemPotionMoveSpeed.ToString() + "증가";
                    string potionAtkSpeedText = "공격속도 " + items[slotNumber].ItemPotionAtkSpeed.ToString() + "증가";
                    string potionAtkText = "공격력 " + items[slotNumber].ItemPotionAtk.ToString() + "증가";
                    string potionMAtkText = "마법 공격력 " + items[slotNumber].ItemPotionMAtk.ToString() + "증가";

                    if (items[slotNumber].ItemPotionHp != 0)
                        optionTexts.Add(potionHpText);
                    if (items[slotNumber].ItemPotionManaRegen != 0)
                        optionTexts.Add(potionManaRegenText);
                    if (items[slotNumber].ItemPotionMoveSpeed != 0)
                        optionTexts.Add(potionMoveSpeedText);
                    if (items[slotNumber].ItemPotionAtkSpeed != 0)
                        optionTexts.Add(potionAtkSpeedText);
                    if (items[slotNumber].ItemPotionAtk != 0)
                        optionTexts.Add(potionAtkText);
                    if (items[slotNumber].ItemPotionMAtk != 0)
                        optionTexts.Add(potionMAtkText);

                    equipButton.gameObject.SetActive(true);
                    equipButton.onClick.AddListener(() => SlotToEquipItem(potionOneBtn, Equip.POTIONONE));
                }
                break;
            case Define.ItemType.Blueprint:
                {
                    itemTypeText.text = "타입 : 설계도";

                    makingButton.gameObject.SetActive(true);
                }
                break;
            case Define.ItemType.Charm:
                {
                    itemTypeText.text = "타입 : 부적";

                    string gainExpText = "경험치 획득량 : " + items[slotNumber].ItemGainExp.ToString() + "%";
                    string gainGoldText = "골드 획득량 : " + items[slotNumber].ItemGainGold.ToString() + "%";
                    string gainCommonMaterialText = "일반재료 획득량 : " + items[slotNumber].ItemGainCommonMaterial.ToString() + "%";
                    string gainRareMAterialText = "레어재료 획득량 : " + items[slotNumber].ItemGainRareMaterial.ToString() + "%";

                    if (items[slotNumber].ItemGainExp != 0) optionTexts.Add(gainExpText);
                    if (items[slotNumber].ItemGainGold != 0) optionTexts.Add(gainGoldText);
                    if (items[slotNumber].ItemGainCommonMaterial != 0) optionTexts.Add(gainCommonMaterialText);
                    if (items[slotNumber].ItemGainRareMaterial != 0) optionTexts.Add(gainRareMAterialText);

                    equipButton.gameObject.SetActive(true);
                    equipButton.onClick.AddListener(() => SlotToEquipItem(expCharmBtn, Equip.EXPCHARM));
                    reinforceButton.gameObject.SetActive(true);

                }
                break;
            case Define.ItemType.QuestItem:
                break;
            default:
                break;
        }

        //아이템 추가옵션을 텍스트로 변환
        switch (optionTexts.Count)
        {
            case 0:
                break;
            case 1:
                itemOneOptionText.text = optionTexts[0];
                break;
            case 2:
                itemOneOptionText.text = optionTexts[0];
                itemTwoOptionText.text = optionTexts[1];
                break;
            case 3:
                itemOneOptionText.text = optionTexts[0];
                itemTwoOptionText.text = optionTexts[1];
                itemThreeOptionText.text = optionTexts[2];
                break;
            case 4:
                itemOneOptionText.text = optionTexts[0];
                itemTwoOptionText.text = optionTexts[1];
                itemThreeOptionText.text = optionTexts[2];
                itemFourOptionText.text = optionTexts[3];
                break;
            case 5:
                itemOneOptionText.text = optionTexts[0];
                itemTwoOptionText.text = optionTexts[1];
                itemThreeOptionText.text = optionTexts[2];
                itemFourOptionText.text = optionTexts[3];
                itemFiveOptionText.text = optionTexts[4];
                break;
            case 6:
                itemOneOptionText.text = optionTexts[0];
                itemTwoOptionText.text = optionTexts[1];
                itemThreeOptionText.text = optionTexts[2];
                itemFourOptionText.text = optionTexts[3];
                itemFiveOptionText.text = optionTexts[4];
                itemSixOptionText.text = optionTexts[5];
                break;
        }










    }

    void EquipTooltip()
    {

        ToolTipImage.gameObject.SetActive(true);

        equipButton.gameObject.SetActive(false);
        piecesButton.gameObject.SetActive(false);
        sellingButton.gameObject.SetActive(false);
        reinforceButton.gameObject.SetActive(false);
        makingButton.gameObject.SetActive(false);
        unlockButton.gameObject.SetActive(false);
        exchangeButton.gameObject.SetActive(false);

        unlockButton.onClick.RemoveAllListeners();

        //옵션 공란으로 초기화
        itemStandardOneText.text = "";
        itemStandardTwoText.text = "";
        itemStandardThreeText.text = "";
        itemOneOptionText.text = "";
        itemTwoOptionText.text = "";
        itemThreeOptionText.text = "";
        itemFourOptionText.text = "";
        itemFiveOptionText.text = "";
        itemSixOptionText.text = "";

        toolTipItemImg.sprite = equipItems[slotNumber].ItemIcon;
        string nameText = equipItems[slotNumber].ItemName;
        string materialText = "";
        if (equipItems[slotNumber].ItemMaterial != "")
            materialText = "재질 : " + equipItems[slotNumber].ItemMaterial;
        string weightText = "무게 : " + equipItems[slotNumber].ItemWeight.ToString();

        itemInfoText.text = equipItems[slotNumber].ItemInfo;

        string gradeText;
        //아이템 등급
        switch (equipItems[slotNumber].ItemGrade)
        {
            case "common":
                gradeText = "등급 : 일반";
                break;
            case "uncommon":
                gradeText = "등급 : 매직";
                break;
            case "rare":
                gradeText = "등급 : 레어";
                break;
            case "unique":
                gradeText = "등급 : 유니크";
                break;
            case "legendary":
                gradeText = "등급 : 레전더리";
                break;
            default:
                gradeText = "0";
                break;
        }


        List<string> standardOptionTexts = new List<string>();

        standardOptionTexts.Add(nameText);  //이름
        if (materialText != "")
            standardOptionTexts.Add(materialText);  //재질
        if (gradeText != "0")
            standardOptionTexts.Add(gradeText); //등급
        if (weightText != null)
            standardOptionTexts.Add(weightText); //무게

        //기본 옵션
        switch (standardOptionTexts.Count)
        {
            case 2:
                itemNameText.text = standardOptionTexts[0];
                itemStandardOneText.text = standardOptionTexts[1];
                break;
            case 3:
                itemNameText.text = standardOptionTexts[0];
                itemStandardOneText.text = standardOptionTexts[1];
                itemStandardTwoText.text = standardOptionTexts[2];
                break;
            case 4:
                itemNameText.text = standardOptionTexts[0];
                itemStandardOneText.text = standardOptionTexts[1];
                itemStandardTwoText.text = standardOptionTexts[2];
                itemStandardThreeText.text = standardOptionTexts[3];
                break;
        }


        List<string> optionTexts = new List<string>();


        switch (equipItems[slotNumber].itemType)
        {
            case Define.ItemType.Weapon:
                {
                    itemTypeText.text = "타입 : 무기";


                    string attackText = "공격력 : " + equipItems[slotNumber].ItemAttack.ToString();
                    string mAttackText = "마법 공격력 : " + equipItems[slotNumber].ItemMAttack.ToString();
                    string atkSpeedText = "공격 속도 : " + equipItems[slotNumber].ItemAtkSpeed.ToString();
                    string hitText = "명중 +" + equipItems[slotNumber].ItemHit.ToString();
                    string criticalText = "크리티컬 +" + equipItems[slotNumber].ItemCritical.ToString() + "%";
                    string criticalDmgText = "크리티컬 데미지 +" + equipItems[slotNumber].ItemCriticalDamage.ToString() + "%";

                    if (equipItems[slotNumber].ItemAttack != 0)
                        optionTexts.Add(attackText);
                    if (equipItems[slotNumber].ItemMAttack != 0)
                        optionTexts.Add(mAttackText);
                    if (equipItems[slotNumber].ItemAtkSpeed != 0)
                        optionTexts.Add(atkSpeedText);
                    if (equipItems[slotNumber].ItemHit != 0)
                        optionTexts.Add(hitText);
                    if (equipItems[slotNumber].ItemCritical != 0)
                        optionTexts.Add(criticalText);
                    if (equipItems[slotNumber].ItemCriticalDamage != 0)
                        optionTexts.Add(criticalDmgText);


                    //버튼 활성화
                    unlockButton.gameObject.SetActive(true);
                    
                    unlockButton.onClick.AddListener(() => UnlockEquipItem(Equip.WEAPON));

                }
                break;
            case Define.ItemType.Amore:
                {
                    itemTypeText.text = "타입 : 방어구";

                    string defText = "방어력 : " + equipItems[slotNumber].ItemDef.ToString();
                    string mDefText = "마법 방어력 : " + equipItems[slotNumber].ItemMDef.ToString();

                    string maxHpText = "최대 체력 +" + equipItems[slotNumber].ItemMaxHp.ToString();
                    string maxManaText = "최대 마나 +" + equipItems[slotNumber].ItemMaxMana.ToString();
                    string hpRegenText = "체력 재생 +" + equipItems[slotNumber].ItemHpRegen.ToString();
                    string mpRegenText = "마나 재생 +" + equipItems[slotNumber].ItemMpRegen.ToString();
                    string maxWeightText = " 무게 보너스 +" + equipItems[slotNumber].ItemMaxWeight.ToString();
                    string fleeText = "회피 +" + equipItems[slotNumber].ItemFlee.ToString();


                    if (equipItems[slotNumber].ItemMaxHp != 0)
                        optionTexts.Add(maxHpText);
                    if (equipItems[slotNumber].ItemMaxMana != 0)
                        optionTexts.Add(maxManaText);
                    if (equipItems[slotNumber].ItemHpRegen != 0)
                        optionTexts.Add(hpRegenText);
                    if (equipItems[slotNumber].ItemMpRegen != 0)
                        optionTexts.Add(mpRegenText);
                    if (equipItems[slotNumber].ItemMaxWeight != 0)
                        optionTexts.Add(maxWeightText);
                    if (equipItems[slotNumber].ItemFlee != 0)
                        optionTexts.Add(fleeText);

                    //버튼 활성화
                    unlockButton.gameObject.SetActive(true);
                    unlockButton.onClick.AddListener(() => UnlockEquipItem(Equip.AMORE));

                }
                break;
            case Define.ItemType.Helmet:
                {
                    itemTypeText.text = "타입 : 방어구";

                    string defText = "방어력 : " + equipItems[slotNumber].ItemDef.ToString();
                    string mDefText = "마법 방어력 : " + equipItems[slotNumber].ItemMDef.ToString();

                    string maxHpText = "최대 체력 +" + equipItems[slotNumber].ItemMaxHp.ToString();
                    string maxManaText = "최대 마나 +" + equipItems[slotNumber].ItemMaxMana.ToString();
                    string hpRegenText = "체력 재생 +" + equipItems[slotNumber].ItemHpRegen.ToString();
                    string mpRegenText = "마나 재생 +" + equipItems[slotNumber].ItemMpRegen.ToString();
                    string maxWeightText = " 무게 보너스 +" + equipItems[slotNumber].ItemMaxWeight.ToString();
                    string fleeText = "회피 +" + equipItems[slotNumber].ItemFlee.ToString();


                    if (equipItems[slotNumber].ItemMaxHp != 0)
                        optionTexts.Add(maxHpText);
                    if (equipItems[slotNumber].ItemMaxMana != 0)
                        optionTexts.Add(maxManaText);
                    if (equipItems[slotNumber].ItemHpRegen != 0)
                        optionTexts.Add(hpRegenText);
                    if (equipItems[slotNumber].ItemMpRegen != 0)
                        optionTexts.Add(mpRegenText);
                    if (equipItems[slotNumber].ItemMaxWeight != 0)
                        optionTexts.Add(maxWeightText);
                    if (equipItems[slotNumber].ItemFlee != 0)
                        optionTexts.Add(fleeText);

                    //버튼 활성화
                    unlockButton.gameObject.SetActive(true);
                    unlockButton.onClick.AddListener(() => UnlockEquipItem(Equip.HELMET));

                }
                break;
            case Define.ItemType.Shoes:
                {
                    itemTypeText.text = "타입 : 방어구";

                    string defText = "방어력 : " + equipItems[slotNumber].ItemDef.ToString();
                    string mDefText = "마법 방어력 : " + equipItems[slotNumber].ItemMDef.ToString();

                    string maxHpText = "최대 체력 +" + equipItems[slotNumber].ItemMaxHp.ToString();
                    string maxManaText = "최대 마나 +" + equipItems[slotNumber].ItemMaxMana.ToString();
                    string hpRegenText = "체력 재생 +" + equipItems[slotNumber].ItemHpRegen.ToString();
                    string mpRegenText = "마나 재생 +" + equipItems[slotNumber].ItemMpRegen.ToString();
                    string maxWeightText = " 무게 보너스 +" + equipItems[slotNumber].ItemMaxWeight.ToString();
                    string fleeText = "회피 +" + equipItems[slotNumber].ItemFlee.ToString();


                    if (equipItems[slotNumber].ItemMaxHp != 0)
                        optionTexts.Add(maxHpText);
                    if (equipItems[slotNumber].ItemMaxMana != 0)
                        optionTexts.Add(maxManaText);
                    if (equipItems[slotNumber].ItemHpRegen != 0)
                        optionTexts.Add(hpRegenText);
                    if (equipItems[slotNumber].ItemMpRegen != 0)
                        optionTexts.Add(mpRegenText);
                    if (equipItems[slotNumber].ItemMaxWeight != 0)
                        optionTexts.Add(maxWeightText);
                    if (equipItems[slotNumber].ItemFlee != 0)
                        optionTexts.Add(fleeText);

                    //버튼 활성화
                    unlockButton.gameObject.SetActive(true);
                    unlockButton.onClick.AddListener(() => UnlockEquipItem(Equip.SHOES));

                }
                break;
            case Define.ItemType.Cloak:
                {
                    itemTypeText.text = "타입 : 방어구";

                    string defText = "방어력 : " + equipItems[slotNumber].ItemDef.ToString();
                    string mDefText = "마법 방어력 : " + equipItems[slotNumber].ItemMDef.ToString();

                    string maxHpText = "최대 체력 +" + equipItems[slotNumber].ItemMaxHp.ToString();
                    string maxManaText = "최대 마나 +" + equipItems[slotNumber].ItemMaxMana.ToString();
                    string hpRegenText = "체력 재생 +" + equipItems[slotNumber].ItemHpRegen.ToString();
                    string mpRegenText = "마나 재생 +" + equipItems[slotNumber].ItemMpRegen.ToString();
                    string maxWeightText = " 무게 보너스 +" + equipItems[slotNumber].ItemMaxWeight.ToString();
                    string fleeText = "회피 +" + equipItems[slotNumber].ItemFlee.ToString();


                    if (equipItems[slotNumber].ItemMaxHp != 0)
                        optionTexts.Add(maxHpText);
                    if (equipItems[slotNumber].ItemMaxMana != 0)
                        optionTexts.Add(maxManaText);
                    if (equipItems[slotNumber].ItemHpRegen != 0)
                        optionTexts.Add(hpRegenText);
                    if (equipItems[slotNumber].ItemMpRegen != 0)
                        optionTexts.Add(mpRegenText);
                    if (equipItems[slotNumber].ItemMaxWeight != 0)
                        optionTexts.Add(maxWeightText);
                    if (equipItems[slotNumber].ItemFlee != 0)
                        optionTexts.Add(fleeText);

                    //버튼 활성화
                    unlockButton.gameObject.SetActive(true);
                    unlockButton.onClick.AddListener(() => UnlockEquipItem(Equip.CLOAK));

                }
                break;
            case Define.ItemType.Shield:
                {
                    itemTypeText.text = "타입 : 방어구";

                    string defText = "방어력 : " + equipItems[slotNumber].ItemDef.ToString();
                    string mDefText = "마법 방어력 : " + equipItems[slotNumber].ItemMDef.ToString();

                    string maxHpText = "최대 체력 +" + equipItems[slotNumber].ItemMaxHp.ToString();
                    string maxManaText = "최대 마나 +" + equipItems[slotNumber].ItemMaxMana.ToString();
                    string hpRegenText = "체력 재생 +" + equipItems[slotNumber].ItemHpRegen.ToString();
                    string mpRegenText = "마나 재생 +" + equipItems[slotNumber].ItemMpRegen.ToString();
                    string maxWeightText = " 무게 보너스 +" + equipItems[slotNumber].ItemMaxWeight.ToString();
                    string fleeText = "회피 +" + equipItems[slotNumber].ItemFlee.ToString();


                    if (equipItems[slotNumber].ItemMaxHp != 0)
                        optionTexts.Add(maxHpText);
                    if (equipItems[slotNumber].ItemMaxMana != 0)
                        optionTexts.Add(maxManaText);
                    if (equipItems[slotNumber].ItemHpRegen != 0)
                        optionTexts.Add(hpRegenText);
                    if (equipItems[slotNumber].ItemMpRegen != 0)
                        optionTexts.Add(mpRegenText);
                    if (equipItems[slotNumber].ItemMaxWeight != 0)
                        optionTexts.Add(maxWeightText);
                    if (equipItems[slotNumber].ItemFlee != 0)
                        optionTexts.Add(fleeText);

                    //버튼 활성화
                    unlockButton.gameObject.SetActive(true);
                    unlockButton.onClick.AddListener(() => UnlockEquipItem(Equip.SHIELD));

                }
                break;
            case Define.ItemType.Accessory:
                {
                    itemTypeText.text = "타입 : 악세서리";

                    string strText = "STR +" + equipItems[slotNumber].ItemStr;
                    string dexText = "DEX +" + equipItems[slotNumber].ItemDex;
                    string agiText = "AGI +" + equipItems[slotNumber].ItemAgi;
                    string vitText = "VIT +" + equipItems[slotNumber].ItemVit;
                    string intText = "INT +" + equipItems[slotNumber].ItemInt;
                    string engText = "ENG +" + equipItems[slotNumber].ItemEng;
                    string lukText = "LUK +" + equipItems[slotNumber].ItemLuk;
                    string accDefText = "방어력 +" + equipItems[slotNumber].ItemAccessoryDef;
                    string accMdefText = "마법 방어력 +" + equipItems[slotNumber].ItemAccessoryMDef;
                    string accAtkText = "공격력 +" + equipItems[slotNumber].ItemAccessoryAtk;
                    string accMatkText = "마법 공격력 +" + equipItems[slotNumber].ItemAccessoryMAtk;
                    string accMaxHp = "최대 체력 +" + equipItems[slotNumber].ItemAccessoryMaxHp;
                    string accMaxMana = "최대 마나 +" + equipItems[slotNumber].ItemAccessoryMaxMana;

                    if (equipItems[slotNumber].ItemStr != 0)
                        optionTexts.Add(strText);
                    if (equipItems[slotNumber].ItemDex != 0)
                        optionTexts.Add(dexText);
                    if (equipItems[slotNumber].ItemAgi != 0)
                        optionTexts.Add(agiText);
                    if (equipItems[slotNumber].ItemVit != 0)
                        optionTexts.Add(vitText);
                    if (equipItems[slotNumber].ItemInt != 0)
                        optionTexts.Add(intText);
                    if (equipItems[slotNumber].ItemEng != 0)
                        optionTexts.Add(engText);
                    if (equipItems[slotNumber].ItemLuk != 0)
                        optionTexts.Add(lukText);
                    if (equipItems[slotNumber].ItemAccessoryDef != 0)
                        optionTexts.Add(accDefText);
                    if (equipItems[slotNumber].ItemAccessoryMDef != 0)
                        optionTexts.Add(accMdefText);
                    if (equipItems[slotNumber].ItemAccessoryAtk != 0)
                        optionTexts.Add(accAtkText);
                    if (equipItems[slotNumber].ItemAccessoryMAtk != 0)
                        optionTexts.Add(accMatkText);
                    if (equipItems[slotNumber].ItemAccessoryMaxHp != 0)
                        optionTexts.Add(accMaxHp);
                    if (equipItems[slotNumber].ItemAccessoryMaxMana != 0)
                        optionTexts.Add(accMaxMana);

                    //버튼 활성화
                    unlockButton.gameObject.SetActive(true);
                    unlockButton.onClick.AddListener(() => UnlockEquipItem(Equip.ACCESSORYONE));
                }
                break;
            case Define.ItemType.Material:
                {
                    itemTypeText.text = "타입 : 재료";

                    sellingButton.gameObject.SetActive(true);
                }
                break;
            case Define.ItemType.Useable:
                {
                    itemTypeText.text = "타입 : 소모품";

                    string potionHpText = "체력 " + equipItems[slotNumber].ItemPotionHp.ToString() + "증가";
                    string potionManaRegenText = "마나 재생량 " + equipItems[slotNumber].ItemPotionManaRegen.ToString() + "증가";
                    string potionMoveSpeedText = "이동속도 " + equipItems[slotNumber].ItemPotionMoveSpeed.ToString() + "증가";
                    string potionAtkSpeedText = "공격속도 " + equipItems[slotNumber].ItemPotionAtkSpeed.ToString() + "증가";
                    string potionAtkText = "공격력 " + equipItems[slotNumber].ItemPotionAtk.ToString() + "증가";
                    string potionMAtkText = "마법 공격력 " + equipItems[slotNumber].ItemPotionMAtk.ToString() + "증가";

                    if (equipItems[slotNumber].ItemPotionHp != 0)
                        optionTexts.Add(potionHpText);
                    if (equipItems[slotNumber].ItemPotionManaRegen != 0)
                        optionTexts.Add(potionManaRegenText);
                    if (equipItems[slotNumber].ItemPotionMoveSpeed != 0)
                        optionTexts.Add(potionMoveSpeedText);
                    if (equipItems[slotNumber].ItemPotionAtkSpeed != 0)
                        optionTexts.Add(potionAtkSpeedText);
                    if (equipItems[slotNumber].ItemPotionAtk != 0)
                        optionTexts.Add(potionAtkText);
                    if (equipItems[slotNumber].ItemPotionMAtk != 0)
                        optionTexts.Add(potionMAtkText);

                    unlockButton.gameObject.SetActive(true);
                    unlockButton.onClick.AddListener(() => UnlockEquipItem(Equip.POTIONONE));
                }
                break;
            case Define.ItemType.Blueprint:
                {
                    itemTypeText.text = "타입 : 설계도";

                    makingButton.gameObject.SetActive(true);
                }
                break;
            case Define.ItemType.Charm:
                {
                    itemTypeText.text = "타입 : 부적";

                    string gainExpText = "경험치 획득량 : " + equipItems[slotNumber].ItemGainExp.ToString() + "%";
                    string gainGoldText = "골드 획득량 : " + equipItems[slotNumber].ItemGainGold.ToString() + "%";
                    string gainCommonMaterialText = "일반재료 획득량 : " + equipItems[slotNumber].ItemGainCommonMaterial.ToString() + "%";
                    string gainRareMAterialText = "레어재료 획득량 : " + equipItems[slotNumber].ItemGainRareMaterial.ToString() + "%";

                    if (equipItems[slotNumber].ItemGainExp != 0) optionTexts.Add(gainExpText);
                    if (equipItems[slotNumber].ItemGainGold != 0) optionTexts.Add(gainGoldText);
                    if (equipItems[slotNumber].ItemGainCommonMaterial != 0) optionTexts.Add(gainCommonMaterialText);
                    if (equipItems[slotNumber].ItemGainRareMaterial != 0) optionTexts.Add(gainRareMAterialText);

                    unlockButton.gameObject.SetActive(true);
                    unlockButton.onClick.AddListener(() => UnlockEquipItem(Equip.EXPCHARM));

                }
                break;
            case Define.ItemType.QuestItem:
                break;
            default:
                break;
        }

        //아이템 추가옵션을 텍스트로 변환
        switch (optionTexts.Count)
        {
            case 0:
                break;
            case 1:
                itemOneOptionText.text = optionTexts[0];
                break;
            case 2:
                itemOneOptionText.text = optionTexts[0];
                itemTwoOptionText.text = optionTexts[1];
                break;
            case 3:
                itemOneOptionText.text = optionTexts[0];
                itemTwoOptionText.text = optionTexts[1];
                itemThreeOptionText.text = optionTexts[2];
                break;
            case 4:
                itemOneOptionText.text = optionTexts[0];
                itemTwoOptionText.text = optionTexts[1];
                itemThreeOptionText.text = optionTexts[2];
                itemFourOptionText.text = optionTexts[3];
                break;
            case 5:
                itemOneOptionText.text = optionTexts[0];
                itemTwoOptionText.text = optionTexts[1];
                itemThreeOptionText.text = optionTexts[2];
                itemFourOptionText.text = optionTexts[3];
                itemFiveOptionText.text = optionTexts[4];
                break;
            case 6:
                itemOneOptionText.text = optionTexts[0];
                itemTwoOptionText.text = optionTexts[1];
                itemThreeOptionText.text = optionTexts[2];
                itemFourOptionText.text = optionTexts[3];
                itemFiveOptionText.text = optionTexts[4];
                itemSixOptionText.text = optionTexts[5];
                break;
        }


        

    }

    void TooltipClose()
    {
        
        ToolTipImage.gameObject.SetActive(false);

        equipButton.gameObject.SetActive(false);
        piecesButton.gameObject.SetActive(false);
        sellingButton.gameObject.SetActive(false);
        reinforceButton.gameObject.SetActive(false);
        makingButton.gameObject.SetActive(false);

    }

    
    void SlotToEquipItem(Button btn, Equip type)
    {
        GameObject slotObj = slots[slotNumber].gameObject;



        //itemObj에 slot의 child를 저장
        //GameObject itemObj = slots[slotNumber].gameObject.transform.GetChild(0).gameObject;

        //무기에 아이템이 장착되어 있지 않을경우
        if (equipItems[(int)type].ItemID == -1)
        {
            Destroy(slotObj);

            //인벤토리에 있는 아이템을 파괴
            slots.Remove(slots[slotNumber]);


            items.RemoveAt(slotNumber);
            items.Add(new Item());

            slots.Add(Instantiate(inventorySlot));
            slots[slotAmount - 1].transform.SetParent(slotPanel.transform);

            //장비창 아이템 딕셔너리의 무기슬롯에 배치된 빈 아이템 삭제
            equipItems.Remove((int)type);

            //아이템을 생성

            GameObject equipItemObj = Instantiate(inventoryItem);

            //아이템을 무기슬롯 Child로 설정
            equipItemObj.transform.SetParent(btn.transform);

            //아이템의 이미지를 장착한 아이템 이미지로 설정
            equipItemObj.GetComponent<Image>().sprite = clickedItem.ItemIcon;

            //아이템의 위치를 무기슬롯 transform으로 배치
            equipItemObj.transform.position = btn.transform.position;

            //아이템의 이름을 장착한 아이템이름으로 변경
            equipItemObj.name = clickedItem.ItemName;



            //장비창 아이템 딕셔너리에 클릭한 아이템 추가
            equipItems.Add((int)type, clickedItem);

            slots[slotNumber].onClick.RemoveListener(InventoryTooltip);

            btn.onClick.AddListener(EquipTooltip);

        }

        data.SavePlayerDataToJsonInInventory();
        data.LoadPlayerDataToJsonInInventory();
        data.SaveItemDataToJson();

        ToolTipImage.gameObject.SetActive(false);
        equipButton.onClick.RemoveAllListeners();

        return;
    }

    void UnlockEquipItem (Equip type)
    {
        GameObject itemObj = equipSlots[(int)type].gameObject.transform.GetChild(0).gameObject;

        Debug.Log(equipItems[(int)type].ItemID);
        AddItem(equipItems[(int)type].ItemID);
        equipItems.Remove((int)type);
        equipItems.Add((int)type,new Item());

        Destroy(itemObj);
    
        unlockButton.gameObject.SetActive(false);
        ToolTipImage.gameObject.SetActive(false);

        data.SavePlayerDataToJsonInInventory();
        data.LoadPlayerDataToJsonInInventory();
        data.SaveItemDataToJson();

        return;
    }

    void ExchangeItem(Button equipBtn, Equip type)
    {
        GameObject equipObj = equipSlots[(int)type].gameObject.transform.GetChild(0).gameObject;

        GameObject itemObj = slots[slotNumber].gameObject.transform.GetChild(0).gameObject;

        //아이템을 인벤토리에 생성하는거 만들어야함
        //AddItem(equipItems[(int)type].ItemID);


        Item tempEquipItem = equipItems[(int)type];
        
        //장비 아이템 제거

        equipItems.Remove((int)type);
        equipItems.Add((int)type, new Item());
        Destroy(equipObj);


        //인벤토리 아이템 제거
        items.RemoveAt(slotNumber);
        items.Insert(slotNumber, new Item());
        Destroy(itemObj);

        //itemObj에 slot의 child를 저장
        //GameObject itemObj = slots[slotNumber].gameObject.transform.GetChild(0).gameObject;

        
        if (items[slotNumber].ItemID == -1)
        {
               
            GameObject slotItemObj = Instantiate(inventoryItem);
      
            //아이템을 인벤토리 Child로 설정
            slotItemObj.transform.SetParent(slots[slotNumber].transform);
      
            //아이템의 이미지를 장착한 아이템 이미지로 설정
            slotItemObj.GetComponent<Image>().sprite = tempEquipItem.ItemIcon;
      
            //아이템의 위치를 무기슬롯 transform으로 배치
            slotItemObj.transform.position = slots[slotNumber].transform.position;
      
            //아이템의 이름을 장착한 아이템이름으로 변경
            slotItemObj.name = tempEquipItem.ItemName;

            items.RemoveAt(slotNumber);
            //장비창 아이템을 인벤토리 슬롯에 추가
            items.Insert(slotNumber, tempEquipItem);

        }
      
        if(equipItems[(int)type].ItemID == -1)
        {
            GameObject equipItemObj = Instantiate(inventoryItem);

            //아이템을 무기슬롯 Child로 설정
            equipItemObj.transform.SetParent(equipBtn.transform);

            //아이템의 이미지를 장착한 아이템 이미지로 설정
            equipItemObj.GetComponent<Image>().sprite = clickedItem.ItemIcon;

            //아이템의 위치를 무기슬롯 transform으로 배치
            equipItemObj.transform.position = equipBtn.transform.position;

            //아이템의 이름을 장착한 아이템이름으로 변경
            equipItemObj.name = clickedItem.ItemName;

            equipItems.Remove((int)type);
            equipItems.Add((int)type, clickedItem);
        }

        data.SavePlayerDataToJsonInInventory();
        data.LoadPlayerDataToJsonInInventory();
        data.SaveItemDataToJson();

        ToolTipImage.gameObject.SetActive(false);
        equipButton.onClick.RemoveAllListeners();

    }

}

