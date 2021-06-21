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
    

    int slotAmount;

    [SerializeField]
    int clickedID;
    [SerializeField]
    int slotNumber;


    public List<Item> items = new List<Item>();
    public List<Button> slots = new List<Button>();

    private void Start()
    {

        ToolTipImage.gameObject.SetActive(false);

        database = itemData.GetComponent<ItemDatabase>();

        slotAmount = 30;
        inventoryPanel = GameObject.Find("InventoryPanel");
        slotPanel = inventoryPanel.transform.Find("Slot Panel").gameObject;


        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[i].transform.SetParent(slotPanel.transform);
        }

        equipButton.gameObject.SetActive(false);
        piecesButton.gameObject.SetActive(false);
        sellingButton.gameObject.SetActive(false);
        reinforceButton.gameObject.SetActive(false);
        makingButton.gameObject.SetActive(false);


        //****(중요)****AddItem 사용시, ItemDatabase.cs의 AddItemToList에서 database 추가해야 작동함
        AddItem(11001);
        AddItem(11002);
        AddItem(21001);
        AddItem(31001);
        AddItem(41001);
        AddItem(51001);
        AddItem(61001);
        AddItem(62001);
        AddItem(71001);
        RemoveItem(2);
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
                    clickedID = items[i].itemID;
                    slotNumber = i;

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

                    slots[i].onClick.AddListener(Tooltip);
                    toolTipItemImg.sprite = items[i].itemIcon;
                    string nameText = items[i].itemName;
                    string materialText = "";
                    if (items[i].itemMaterial != "")
                        materialText = "재질 : " + items[i].itemMaterial;
                    string weightText = "무게 : " + items[i].itemWeight.ToString();

                    itemInfoText.text = items[i].itemInfo;

                    string gradeText;
                    //아이템 등급
                    switch (items[i].itemGrade)
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

                    //아이템 타입 및 타입에 따른 추가옵션 및 버튼 활성화
                    switch (items[i].itemType)
                    {
                        case Define.ItemType.Weapon:
                            {
                                itemTypeText.text = "타입 : 무기";


                                string attackText = "공격력 : " + items[i].itemAttack.ToString();
                                string mAttackText = "마법 공격력 : " + items[i].itemMAttack.ToString();
                                string atkSpeedText = "공격 속도 : " + items[i].itemAtkSpeed.ToString();
                                string hitText = "명중 +" + items[i].itemHit.ToString();
                                string criticalText = "크리티컬 +" + items[i].itemCritical.ToString() + "%";
                                string criticalDmgText = "크리티컬 데미지 +" + items[i].itemCriticalDamage.ToString() + "%";

                                if (items[i].itemAttack != 0)
                                    optionTexts.Add(attackText);
                                if (items[i].itemMAttack != 0)
                                    optionTexts.Add(mAttackText);
                                if (items[i].itemAtkSpeed != 0)
                                    optionTexts.Add(atkSpeedText);
                                if (items[i].itemHit != 0)
                                    optionTexts.Add(hitText);
                                if (items[i].itemCritical != 0)
                                    optionTexts.Add(criticalText);
                                if (items[i].itemCriticalDamage != 0)
                                    optionTexts.Add(criticalDmgText);


                                //버튼 활성화
                                equipButton.gameObject.SetActive(true);
                                equipButton.onClick.AddListener(EquipWeapon);
                                reinforceButton.gameObject.SetActive(true);

                            }
                            break;
                        case Define.ItemType.Amore:
                            {
                                itemTypeText.text = "타입 : 방어구";

                                string defText = "방어력 : " + items[i].itemDef.ToString();
                                string mDefText = "마법 방어력 : " + items[i].itemMDef.ToString();

                                string maxHpText = "최대 체력 +" + items[i].itemMaxHp.ToString();
                                string maxManaText = "최대 마나 +" + items[i].itemMaxMana.ToString();
                                string hpRegenText = "체력 재생 +" + items[i].itemHpRegen.ToString();
                                string mpRegenText = "마나 재생 +" + items[i].itemMpRegen.ToString();
                                string maxWeightText = " 무게 보너스 +" + items[i].itemMaxWeight.ToString();
                                string fleeText = "회피 +" + items[i].itemFlee.ToString();


                                if (items[i].itemMaxHp != 0)
                                    optionTexts.Add(maxHpText);
                                if (items[i].itemMaxMana != 0)
                                    optionTexts.Add(maxManaText);
                                if (items[i].itemHpRegen != 0)
                                    optionTexts.Add(hpRegenText);
                                if (items[i].itemMpRegen != 0)
                                    optionTexts.Add(mpRegenText);
                                if (items[i].itemMaxWeight != 0)
                                    optionTexts.Add(maxWeightText);
                                if (items[i].itemFlee != 0)
                                    optionTexts.Add(fleeText);

                                //버튼 활성화
                                equipButton.gameObject.SetActive(true);
                                equipButton.onClick.AddListener(EquipAmore);
                                reinforceButton.gameObject.SetActive(true);

                            }
                            break;
                        case Define.ItemType.Accessory:
                            {
                                itemTypeText.text = "타입 : 악세서리";

                                string strText = "STR +" + items[i].itemStr;
                                string dexText = "DEX +" + items[i].itemDex;
                                string agiText = "AGI +" + items[i].itemAgi;
                                string vitText = "VIT +" + items[i].itemVit;
                                string intText = "INT +" + items[i].itemInt;
                                string engText = "ENG +" + items[i].itemEng;
                                string lukText = "LUK +" + items[i].itemLuk;
                                string accDefText = "방어력 +" + items[i].itemAccessoryDef;
                                string accMdefText = "마법 방어력 +" + items[i].itemAccessoryMDef;
                                string accAtkText = "공격력 +" + items[i].itemAccessoryAtk;
                                string accMatkText = "마법 공격력 +" + items[i].itemAccessoryMAtk;
                                string accMaxHp = "최대 체력 +" + items[i].itemAccessoryMaxHp;
                                string accMaxMana = "최대 마나 +" + items[i].itemAccessoryMaxMana;

                                if (items[i].itemStr != 0)
                                    optionTexts.Add(strText);
                                if (items[i].itemDex != 0)
                                    optionTexts.Add(dexText);
                                if (items[i].itemAgi != 0)
                                    optionTexts.Add(agiText);
                                if (items[i].itemVit != 0)
                                    optionTexts.Add(vitText);
                                if (items[i].itemInt != 0)
                                    optionTexts.Add(intText);
                                if (items[i].itemEng != 0)
                                    optionTexts.Add(engText);
                                if (items[i].itemLuk != 0)
                                    optionTexts.Add(lukText);
                                if (items[i].itemAccessoryDef != 0)
                                    optionTexts.Add(accDefText);
                                if (items[i].itemAccessoryMDef != 0)
                                    optionTexts.Add(accMdefText);
                                if (items[i].itemAccessoryAtk != 0)
                                    optionTexts.Add(accAtkText);
                                if (items[i].itemAccessoryMAtk != 0)
                                    optionTexts.Add(accMatkText);
                                if (items[i].itemAccessoryMaxHp != 0)
                                    optionTexts.Add(accMaxHp);
                                if (items[i].itemAccessoryMaxMana != 0)
                                    optionTexts.Add(accMaxMana);

                                //버튼 활성화
                                equipButton.gameObject.SetActive(true);
                                equipButton.onClick.AddListener(EquipAccessory);
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

                                string potionHpText = "체력 " + items[i].itemPotionHp.ToString() + "증가";
                                string potionManaRegenText = "마나 재생량 " + items[i].itemPotionManaRegen.ToString() + "증가";
                                string potionMoveSpeedText = "이동속도 " + items[i].itemPotionMoveSpeed.ToString() + "증가";
                                string potionAtkSpeedText = "공격속도 " + items[i].itemPotionAtkSpeed.ToString() + "증가";
                                string potionAtkText = "공격력 " + items[i].itemPotionAtk.ToString() + "증가";
                                string potionMAtkText = "마법 공격력 " + items[i].itemPotionMAtk.ToString() + "증가";

                                if(items[i].itemPotionHp !=0)
                                    optionTexts.Add(potionHpText);
                                if(items[i].itemPotionManaRegen !=0)
                                    optionTexts.Add(potionManaRegenText);
                                if(items[i].itemPotionMoveSpeed !=0)
                                    optionTexts.Add(potionMoveSpeedText);
                                if(items[i].itemPotionAtkSpeed !=0)
                                    optionTexts.Add(potionAtkSpeedText);
                                if(items[i].itemPotionAtk !=0)
                                    optionTexts.Add(potionAtkText);
                                if (items[i].itemPotionMAtk != 0)
                                    optionTexts.Add(potionMAtkText);

                                equipButton.gameObject.SetActive(true);
                                equipButton.onClick.AddListener(EquipUseable);
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

                                string gainExpText = "경험치 획득량 : " + items[i].itemGainExp.ToString() + "%";
                                string gainGoldText = "골드 획득량 : " + items[i].itemGainGold.ToString() + "%";
                                string gainCommonMaterialText = "일반재료 획득량 : " + items[i].itemGainCommonMaterial.ToString() + "%";
                                string gainRareMAterialText = "레어재료 획득량 : " + items[i].itemGainRareMaterial.ToString() + "%";

                                if(items[i].itemGainExp != 0) optionTexts.Add(gainExpText);
                                if(items[i].itemGainGold != 0) optionTexts.Add(gainGoldText);
                                if(items[i].itemGainCommonMaterial != 0) optionTexts.Add(gainCommonMaterialText);
                                if (items[i].itemGainRareMaterial != 0) optionTexts.Add(gainRareMAterialText);

                                equipButton.gameObject.SetActive(true);
                                equipButton.onClick.AddListener(EquipCharm);
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

                

            }
        }


        ToolTipCloseButton.onClick.AddListener(TooltipClose);
    }

    
    public void AddItem(int id)
    {
        Item itemToAdd = database.AccessItemById(id);
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemID == -1)
            {
                items[i] = itemToAdd;


                //TODO : 이미지
                GameObject itemObj = Instantiate(inventoryItem);
                itemObj.transform.SetParent(slots[i].transform);
                itemObj.GetComponent<Image>().sprite = itemToAdd.itemIcon;
                itemObj.transform.position = Vector2.zero;
                itemObj.name = itemToAdd.itemName;

                
                break;
            }
        }
    }

    public void RemoveItem(int slotNumber)
    {
        Item itemToRemove = database.AccessItemById(99999);
        if (items[slotNumber].itemID != -1)
        {
            
            
        }
    }

    void Tooltip()
    {

        ToolTipImage.gameObject.SetActive(true);

        

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

    void EquipWeapon()
    {
        
    }

    void EquipAmore()
    {

    }

    void EquipAccessory()
    {

    }

    void EquipCharm()
    {

    }
    
    void EquipUseable()
    {

    }


}
