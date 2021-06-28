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
    GameObject inventoryPanel;
    GameObject slotPanel;
    [SerializeField]
    GameObject itemData;
    ItemDatabase database;

    [SerializeField]
    Button inventorySlot;

    [SerializeField]
    GameObject inventoryItem;

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

    enum Equip
    {
        HELMET,
        AMORE,
        WEAPON,
        SUBWEAPON,
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

            slots[i].GetComponent<MainUI_Slot>().id = i;
        }


        equipItems.Add((int)Equip.HELMET, new Item());
        equipItems.Add((int)Equip.AMORE, new Item());
        equipItems.Add((int)Equip.WEAPON, new Item());
        equipItems.Add((int)Equip.SUBWEAPON, new Item());
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
    }

    void Update()
    {
        for (int i = 0; i < slots.Count; i++)
        {

            //슬롯에 아이템이 있을때
            if (items[i].itemID != -1)
            {

                //클릭한 슬롯이 슬롯의 인덱스를 확인한다.
                if (EventSystem.current.currentSelectedGameObject == slots[i].gameObject)
                {
                    clickedItem = items[i];
                    slotNumber = i;

                    Debug.Log(slotNumber);
                    Debug.Log(items[i].itemID);

                    
                    
                    if(slots[i].gameObject.transform.childCount != 0)
                    slots[i].onClick.AddListener(InventoryTooltip);

                }
            }


        }

        for (int i = 0; i < equipSlots.Count; i++)
        {
            //슬롯에 아이템이 있을때
            if (equipItems[i].itemID != -1)
            {

                //클릭한 슬롯이 슬롯의 인덱스를 확인한다.
                if (EventSystem.current.currentSelectedGameObject == equipSlots[i].gameObject)
                {
                    clickedItem = equipItems[i];
                    slotNumber = i;


                    Debug.Log(equipItems[i].itemID);
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

        if (itemToAdd.itemStackable && CheckItemInInventory(itemToAdd))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].itemID == id)
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
                if (items[i].itemID == -1)
                {

                    items[i] = itemToAdd;

                    GameObject itemObj = Instantiate(inventoryItem);

                    itemObj.GetComponent<ItemData>().item = itemToAdd;
                    itemObj.GetComponent<ItemData>().slot = i;

                    itemObj.transform.SetParent(slots[i].transform);
                    itemObj.GetComponent<Image>().sprite = itemToAdd.itemIcon;
                    itemObj.transform.position = slots[i].transform.position;
                    itemObj.name = itemToAdd.itemName;
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
            if (items[i].itemID == item.itemID) return true;
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

        toolTipItemImg.sprite = items[slotNumber].itemIcon;
        string nameText = items[slotNumber].itemName;
        string materialText = "";
        if (items[slotNumber].itemMaterial != "")
            materialText = "재질 : " + items[slotNumber].itemMaterial;
        string weightText = "무게 : " + items[slotNumber].itemWeight.ToString();

        itemInfoText.text = items[slotNumber].itemInfo;

        string gradeText;
        //아이템 등급
        switch (items[slotNumber].itemGrade)
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


                    string attackText = "공격력 : " + items[slotNumber].itemAttack.ToString();
                    string mAttackText = "마법 공격력 : " + items[slotNumber].itemMAttack.ToString();
                    string atkSpeedText = "공격 속도 : " + items[slotNumber].itemAtkSpeed.ToString();
                    string hitText = "명중 +" + items[slotNumber].itemHit.ToString();
                    string criticalText = "크리티컬 +" + items[slotNumber].itemCritical.ToString() + "%";
                    string criticalDmgText = "크리티컬 데미지 +" + items[slotNumber].itemCriticalDamage.ToString() + "%";

                    if (items[slotNumber].itemAttack != 0)
                        optionTexts.Add(attackText);
                    if (items[slotNumber].itemMAttack != 0)
                        optionTexts.Add(mAttackText);
                    if (items[slotNumber].itemAtkSpeed != 0)
                        optionTexts.Add(atkSpeedText);
                    if (items[slotNumber].itemHit != 0)
                        optionTexts.Add(hitText);
                    if (items[slotNumber].itemCritical != 0)
                        optionTexts.Add(criticalText);
                    if (items[slotNumber].itemCriticalDamage != 0)
                        optionTexts.Add(criticalDmgText);


                    //버튼 활성화
                    if(equipItems[(int)Equip.WEAPON].itemID == -1)
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

                    string defText = "방어력 : " + items[slotNumber].itemDef.ToString();
                    string mDefText = "마법 방어력 : " + items[slotNumber].itemMDef.ToString();

                    string maxHpText = "최대 체력 +" + items[slotNumber].itemMaxHp.ToString();
                    string maxManaText = "최대 마나 +" + items[slotNumber].itemMaxMana.ToString();
                    string hpRegenText = "체력 재생 +" + items[slotNumber].itemHpRegen.ToString();
                    string mpRegenText = "마나 재생 +" + items[slotNumber].itemMpRegen.ToString();
                    string maxWeightText = " 무게 보너스 +" + items[slotNumber].itemMaxWeight.ToString();
                    string fleeText = "회피 +" + items[slotNumber].itemFlee.ToString();


                    if (items[slotNumber].itemMaxHp != 0)
                        optionTexts.Add(maxHpText);
                    if (items[slotNumber].itemMaxMana != 0)
                        optionTexts.Add(maxManaText);
                    if (items[slotNumber].itemHpRegen != 0)
                        optionTexts.Add(hpRegenText);
                    if (items[slotNumber].itemMpRegen != 0)
                        optionTexts.Add(mpRegenText);
                    if (items[slotNumber].itemMaxWeight != 0)
                        optionTexts.Add(maxWeightText);
                    if (items[slotNumber].itemFlee != 0)
                        optionTexts.Add(fleeText);

                    //버튼 활성화
                    equipButton.gameObject.SetActive(true);
                    equipButton.onClick.AddListener(() => SlotToEquipItem(amoreBtn, Equip.AMORE));
                    reinforceButton.gameObject.SetActive(true);

                }
                break;
            case Define.ItemType.Accessory:
                {
                    itemTypeText.text = "타입 : 악세서리";

                    string strText = "STR +" + items[slotNumber].itemStr;
                    string dexText = "DEX +" + items[slotNumber].itemDex;
                    string agiText = "AGI +" + items[slotNumber].itemAgi;
                    string vitText = "VIT +" + items[slotNumber].itemVit;
                    string intText = "INT +" + items[slotNumber].itemInt;
                    string engText = "ENG +" + items[slotNumber].itemEng;
                    string lukText = "LUK +" + items[slotNumber].itemLuk;
                    string accDefText = "방어력 +" + items[slotNumber].itemAccessoryDef;
                    string accMdefText = "마법 방어력 +" + items[slotNumber].itemAccessoryMDef;
                    string accAtkText = "공격력 +" + items[slotNumber].itemAccessoryAtk;
                    string accMatkText = "마법 공격력 +" + items[slotNumber].itemAccessoryMAtk;
                    string accMaxHp = "최대 체력 +" + items[slotNumber].itemAccessoryMaxHp;
                    string accMaxMana = "최대 마나 +" + items[slotNumber].itemAccessoryMaxMana;

                    if (items[slotNumber].itemStr != 0)
                        optionTexts.Add(strText);
                    if (items[slotNumber].itemDex != 0)
                        optionTexts.Add(dexText);
                    if (items[slotNumber].itemAgi != 0)
                        optionTexts.Add(agiText);
                    if (items[slotNumber].itemVit != 0)
                        optionTexts.Add(vitText);
                    if (items[slotNumber].itemInt != 0)
                        optionTexts.Add(intText);
                    if (items[slotNumber].itemEng != 0)
                        optionTexts.Add(engText);
                    if (items[slotNumber].itemLuk != 0)
                        optionTexts.Add(lukText);
                    if (items[slotNumber].itemAccessoryDef != 0)
                        optionTexts.Add(accDefText);
                    if (items[slotNumber].itemAccessoryMDef != 0)
                        optionTexts.Add(accMdefText);
                    if (items[slotNumber].itemAccessoryAtk != 0)
                        optionTexts.Add(accAtkText);
                    if (items[slotNumber].itemAccessoryMAtk != 0)
                        optionTexts.Add(accMatkText);
                    if (items[slotNumber].itemAccessoryMaxHp != 0)
                        optionTexts.Add(accMaxHp);
                    if (items[slotNumber].itemAccessoryMaxMana != 0)
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

                    string potionHpText = "체력 " + items[slotNumber].itemPotionHp.ToString() + "증가";
                    string potionManaRegenText = "마나 재생량 " + items[slotNumber].itemPotionManaRegen.ToString() + "증가";
                    string potionMoveSpeedText = "이동속도 " + items[slotNumber].itemPotionMoveSpeed.ToString() + "증가";
                    string potionAtkSpeedText = "공격속도 " + items[slotNumber].itemPotionAtkSpeed.ToString() + "증가";
                    string potionAtkText = "공격력 " + items[slotNumber].itemPotionAtk.ToString() + "증가";
                    string potionMAtkText = "마법 공격력 " + items[slotNumber].itemPotionMAtk.ToString() + "증가";

                    if (items[slotNumber].itemPotionHp != 0)
                        optionTexts.Add(potionHpText);
                    if (items[slotNumber].itemPotionManaRegen != 0)
                        optionTexts.Add(potionManaRegenText);
                    if (items[slotNumber].itemPotionMoveSpeed != 0)
                        optionTexts.Add(potionMoveSpeedText);
                    if (items[slotNumber].itemPotionAtkSpeed != 0)
                        optionTexts.Add(potionAtkSpeedText);
                    if (items[slotNumber].itemPotionAtk != 0)
                        optionTexts.Add(potionAtkText);
                    if (items[slotNumber].itemPotionMAtk != 0)
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

                    string gainExpText = "경험치 획득량 : " + items[slotNumber].itemGainExp.ToString() + "%";
                    string gainGoldText = "골드 획득량 : " + items[slotNumber].itemGainGold.ToString() + "%";
                    string gainCommonMaterialText = "일반재료 획득량 : " + items[slotNumber].itemGainCommonMaterial.ToString() + "%";
                    string gainRareMAterialText = "레어재료 획득량 : " + items[slotNumber].itemGainRareMaterial.ToString() + "%";

                    if (items[slotNumber].itemGainExp != 0) optionTexts.Add(gainExpText);
                    if (items[slotNumber].itemGainGold != 0) optionTexts.Add(gainGoldText);
                    if (items[slotNumber].itemGainCommonMaterial != 0) optionTexts.Add(gainCommonMaterialText);
                    if (items[slotNumber].itemGainRareMaterial != 0) optionTexts.Add(gainRareMAterialText);

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

        toolTipItemImg.sprite = equipItems[slotNumber].itemIcon;
        string nameText = equipItems[slotNumber].itemName;
        string materialText = "";
        if (equipItems[slotNumber].itemMaterial != "")
            materialText = "재질 : " + equipItems[slotNumber].itemMaterial;
        string weightText = "무게 : " + equipItems[slotNumber].itemWeight.ToString();

        itemInfoText.text = equipItems[slotNumber].itemInfo;

        string gradeText;
        //아이템 등급
        switch (equipItems[slotNumber].itemGrade)
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


                    string attackText = "공격력 : " + equipItems[slotNumber].itemAttack.ToString();
                    string mAttackText = "마법 공격력 : " + equipItems[slotNumber].itemMAttack.ToString();
                    string atkSpeedText = "공격 속도 : " + equipItems[slotNumber].itemAtkSpeed.ToString();
                    string hitText = "명중 +" + equipItems[slotNumber].itemHit.ToString();
                    string criticalText = "크리티컬 +" + equipItems[slotNumber].itemCritical.ToString() + "%";
                    string criticalDmgText = "크리티컬 데미지 +" + equipItems[slotNumber].itemCriticalDamage.ToString() + "%";

                    if (equipItems[slotNumber].itemAttack != 0)
                        optionTexts.Add(attackText);
                    if (equipItems[slotNumber].itemMAttack != 0)
                        optionTexts.Add(mAttackText);
                    if (equipItems[slotNumber].itemAtkSpeed != 0)
                        optionTexts.Add(atkSpeedText);
                    if (equipItems[slotNumber].itemHit != 0)
                        optionTexts.Add(hitText);
                    if (equipItems[slotNumber].itemCritical != 0)
                        optionTexts.Add(criticalText);
                    if (equipItems[slotNumber].itemCriticalDamage != 0)
                        optionTexts.Add(criticalDmgText);


                    //버튼 활성화
                    unlockButton.gameObject.SetActive(true);
                    
                    unlockButton.onClick.AddListener(() => UnlockEquipItem(Equip.WEAPON));

                }
                break;
            case Define.ItemType.Amore:
                {
                    itemTypeText.text = "타입 : 방어구";

                    string defText = "방어력 : " + equipItems[slotNumber].itemDef.ToString();
                    string mDefText = "마법 방어력 : " + equipItems[slotNumber].itemMDef.ToString();

                    string maxHpText = "최대 체력 +" + equipItems[slotNumber].itemMaxHp.ToString();
                    string maxManaText = "최대 마나 +" + equipItems[slotNumber].itemMaxMana.ToString();
                    string hpRegenText = "체력 재생 +" + equipItems[slotNumber].itemHpRegen.ToString();
                    string mpRegenText = "마나 재생 +" + equipItems[slotNumber].itemMpRegen.ToString();
                    string maxWeightText = " 무게 보너스 +" + equipItems[slotNumber].itemMaxWeight.ToString();
                    string fleeText = "회피 +" + equipItems[slotNumber].itemFlee.ToString();


                    if (equipItems[slotNumber].itemMaxHp != 0)
                        optionTexts.Add(maxHpText);
                    if (equipItems[slotNumber].itemMaxMana != 0)
                        optionTexts.Add(maxManaText);
                    if (equipItems[slotNumber].itemHpRegen != 0)
                        optionTexts.Add(hpRegenText);
                    if (equipItems[slotNumber].itemMpRegen != 0)
                        optionTexts.Add(mpRegenText);
                    if (equipItems[slotNumber].itemMaxWeight != 0)
                        optionTexts.Add(maxWeightText);
                    if (equipItems[slotNumber].itemFlee != 0)
                        optionTexts.Add(fleeText);

                    //버튼 활성화
                    unlockButton.gameObject.SetActive(true);
                    unlockButton.onClick.AddListener(() => UnlockEquipItem(Equip.AMORE));

                }
                break;
            case Define.ItemType.Accessory:
                {
                    itemTypeText.text = "타입 : 악세서리";

                    string strText = "STR +" + equipItems[slotNumber].itemStr;
                    string dexText = "DEX +" + equipItems[slotNumber].itemDex;
                    string agiText = "AGI +" + equipItems[slotNumber].itemAgi;
                    string vitText = "VIT +" + equipItems[slotNumber].itemVit;
                    string intText = "INT +" + equipItems[slotNumber].itemInt;
                    string engText = "ENG +" + equipItems[slotNumber].itemEng;
                    string lukText = "LUK +" + equipItems[slotNumber].itemLuk;
                    string accDefText = "방어력 +" + equipItems[slotNumber].itemAccessoryDef;
                    string accMdefText = "마법 방어력 +" + equipItems[slotNumber].itemAccessoryMDef;
                    string accAtkText = "공격력 +" + equipItems[slotNumber].itemAccessoryAtk;
                    string accMatkText = "마법 공격력 +" + equipItems[slotNumber].itemAccessoryMAtk;
                    string accMaxHp = "최대 체력 +" + equipItems[slotNumber].itemAccessoryMaxHp;
                    string accMaxMana = "최대 마나 +" + equipItems[slotNumber].itemAccessoryMaxMana;

                    if (equipItems[slotNumber].itemStr != 0)
                        optionTexts.Add(strText);
                    if (equipItems[slotNumber].itemDex != 0)
                        optionTexts.Add(dexText);
                    if (equipItems[slotNumber].itemAgi != 0)
                        optionTexts.Add(agiText);
                    if (equipItems[slotNumber].itemVit != 0)
                        optionTexts.Add(vitText);
                    if (equipItems[slotNumber].itemInt != 0)
                        optionTexts.Add(intText);
                    if (equipItems[slotNumber].itemEng != 0)
                        optionTexts.Add(engText);
                    if (equipItems[slotNumber].itemLuk != 0)
                        optionTexts.Add(lukText);
                    if (equipItems[slotNumber].itemAccessoryDef != 0)
                        optionTexts.Add(accDefText);
                    if (equipItems[slotNumber].itemAccessoryMDef != 0)
                        optionTexts.Add(accMdefText);
                    if (equipItems[slotNumber].itemAccessoryAtk != 0)
                        optionTexts.Add(accAtkText);
                    if (equipItems[slotNumber].itemAccessoryMAtk != 0)
                        optionTexts.Add(accMatkText);
                    if (equipItems[slotNumber].itemAccessoryMaxHp != 0)
                        optionTexts.Add(accMaxHp);
                    if (equipItems[slotNumber].itemAccessoryMaxMana != 0)
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

                    string potionHpText = "체력 " + equipItems[slotNumber].itemPotionHp.ToString() + "증가";
                    string potionManaRegenText = "마나 재생량 " + equipItems[slotNumber].itemPotionManaRegen.ToString() + "증가";
                    string potionMoveSpeedText = "이동속도 " + equipItems[slotNumber].itemPotionMoveSpeed.ToString() + "증가";
                    string potionAtkSpeedText = "공격속도 " + equipItems[slotNumber].itemPotionAtkSpeed.ToString() + "증가";
                    string potionAtkText = "공격력 " + equipItems[slotNumber].itemPotionAtk.ToString() + "증가";
                    string potionMAtkText = "마법 공격력 " + equipItems[slotNumber].itemPotionMAtk.ToString() + "증가";

                    if (equipItems[slotNumber].itemPotionHp != 0)
                        optionTexts.Add(potionHpText);
                    if (equipItems[slotNumber].itemPotionManaRegen != 0)
                        optionTexts.Add(potionManaRegenText);
                    if (equipItems[slotNumber].itemPotionMoveSpeed != 0)
                        optionTexts.Add(potionMoveSpeedText);
                    if (equipItems[slotNumber].itemPotionAtkSpeed != 0)
                        optionTexts.Add(potionAtkSpeedText);
                    if (equipItems[slotNumber].itemPotionAtk != 0)
                        optionTexts.Add(potionAtkText);
                    if (equipItems[slotNumber].itemPotionMAtk != 0)
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

                    string gainExpText = "경험치 획득량 : " + equipItems[slotNumber].itemGainExp.ToString() + "%";
                    string gainGoldText = "골드 획득량 : " + equipItems[slotNumber].itemGainGold.ToString() + "%";
                    string gainCommonMaterialText = "일반재료 획득량 : " + equipItems[slotNumber].itemGainCommonMaterial.ToString() + "%";
                    string gainRareMAterialText = "레어재료 획득량 : " + equipItems[slotNumber].itemGainRareMaterial.ToString() + "%";

                    if (equipItems[slotNumber].itemGainExp != 0) optionTexts.Add(gainExpText);
                    if (equipItems[slotNumber].itemGainGold != 0) optionTexts.Add(gainGoldText);
                    if (equipItems[slotNumber].itemGainCommonMaterial != 0) optionTexts.Add(gainCommonMaterialText);
                    if (equipItems[slotNumber].itemGainRareMaterial != 0) optionTexts.Add(gainRareMAterialText);

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
        if (equipItems[(int)type].itemID == -1)
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
            equipItemObj.GetComponent<Image>().sprite = clickedItem.itemIcon;

            //아이템의 위치를 무기슬롯 transform으로 배치
            equipItemObj.transform.position = btn.transform.position;

            //아이템의 이름을 장착한 아이템이름으로 변경
            equipItemObj.name = clickedItem.itemName;



            //장비창 아이템 딕셔너리에 클릭한 아이템 추가
            equipItems.Add((int)type, clickedItem);

            slots[slotNumber].onClick.RemoveListener(InventoryTooltip);

            btn.onClick.AddListener(EquipTooltip);

        }
        
        ToolTipImage.gameObject.SetActive(false);
        equipButton.onClick.RemoveAllListeners();


        return;
    }

    void UnlockEquipItem (Equip type)
    {
        GameObject itemObj = equipSlots[(int)type].gameObject.transform.GetChild(0).gameObject;

        Debug.Log(equipItems[(int)type].itemID);
        AddItem(equipItems[(int)type].itemID);
        equipItems.Remove((int)type);
        equipItems.Add((int)type,new Item());

        Destroy(itemObj);
    
        unlockButton.gameObject.SetActive(false);
        ToolTipImage.gameObject.SetActive(false);

        return;
    }

    void ExchangeItem(Button equipBtn, Equip type)
    {
        GameObject equipObj = equipSlots[(int)type].gameObject.transform.GetChild(0).gameObject;

        GameObject itemObj = slots[slotNumber].gameObject.transform.GetChild(0).gameObject;

        //아이템을 인벤토리에 생성하는거 만들어야함
        //AddItem(equipItems[(int)type].itemID);


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

        
        if (items[slotNumber].itemID == -1)
        {
               
            GameObject slotItemObj = Instantiate(inventoryItem);
      
            //아이템을 인벤토리 Child로 설정
            slotItemObj.transform.SetParent(slots[slotNumber].transform);
      
            //아이템의 이미지를 장착한 아이템 이미지로 설정
            slotItemObj.GetComponent<Image>().sprite = tempEquipItem.itemIcon;
      
            //아이템의 위치를 무기슬롯 transform으로 배치
            slotItemObj.transform.position = slots[slotNumber].transform.position;
      
            //아이템의 이름을 장착한 아이템이름으로 변경
            slotItemObj.name = tempEquipItem.itemName;

            items.RemoveAt(slotNumber);
            //장비창 아이템을 인벤토리 슬롯에 추가
            items.Insert(slotNumber, tempEquipItem);

        }
      
        if(equipItems[(int)type].itemID == -1)
        {
            GameObject equipItemObj = Instantiate(inventoryItem);

            //아이템을 무기슬롯 Child로 설정
            equipItemObj.transform.SetParent(equipBtn.transform);

            //아이템의 이미지를 장착한 아이템 이미지로 설정
            equipItemObj.GetComponent<Image>().sprite = clickedItem.itemIcon;

            //아이템의 위치를 무기슬롯 transform으로 배치
            equipItemObj.transform.position = equipBtn.transform.position;

            //아이템의 이름을 장착한 아이템이름으로 변경
            equipItemObj.name = clickedItem.itemName;

            equipItems.Remove((int)type);
            equipItems.Add((int)type, clickedItem);
        }


        ToolTipImage.gameObject.SetActive(false);
        equipButton.onClick.RemoveAllListeners();

    }

}

