//UI_Inventory 스크립트
/*
 * 작성일자 : 2021-06-02
스크립트 설명 : 인벤토리 스크립트
스크립트 사용법 : 
                 
수정일자(1차) : 06-15
수정내용(1차) : 슬롯 버튼화, 툴팁 페이지 추가, 툴팁에 아이템아이콘 출력

수정일자(2차) : 06-16
수정내용(2차) : 무기 툴팁 옵션 추가(이름, 옵션 등등)
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



    int slotAmount;

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
                    if(materialText != "")
                        standardOptionTexts.Add(materialText);  //재질
                    if (gradeText != "0")
                        standardOptionTexts.Add(gradeText); //등급
                    if(weightText != null)
                        standardOptionTexts.Add(weightText); //무게

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

                    //아이템 타입 및 타입에 따른 옵션
                    switch (items[i].itemType)
                    {
                        case Define.ItemType.Weapon:
                            {
                                itemTypeText.text = "타입 : 무기";

                                
                                string attackText = "공격력 : " + items[i].itemAttack.ToString();
                                string mAttackText = "마법 공격력 : " + items[i].itemMAttack.ToString();
                                string atkSpeedText = "공격 속도 : " + items[i].itemAtkSpeed.ToString();
                                string hitText = "명중 : +" + items[i].itemHit.ToString();
                                string criticalText = "크리티컬 : +" + items[i].itemCritical.ToString() + "%";
                                string criticalDmgText = "크리티컬 데미지 : +" + items[i].itemCriticalDamage.ToString()+"%";

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

                            }
                            break;
                        case Define.ItemType.Amore:
                            {
                                itemTypeText.text = "타입 : 방어구";


                            }
                            break;
                        case Define.ItemType.Accessory:
                            {
                                itemTypeText.text = "타입 : 악세서리";
                            }
                            break;
                        case Define.ItemType.Material:
                            {
                                itemTypeText.text = "타입 : 재료";
                            }
                            break;
                        case Define.ItemType.Useable:
                            {
                                itemTypeText.text = "타입 : 소모품";
                            }
                            break;
                        case Define.ItemType.Blueprint:
                            {
                                itemTypeText.text = "타입 : 설계도";
                            }
                            break;
                        case Define.ItemType.Charm:
                            {
                                itemTypeText.text = "타입 : 부적";
                            }
                            break;
                        case Define.ItemType.QuestItem:
                            break;
                        default:
                            break;
                    }

                    //아이템 옵션
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
                GameObject itemObj = Instantiate(inventoryItem);
                itemObj.transform.SetParent(slots[i].transform);
                itemObj.GetComponent<Image>().sprite = itemToAdd.itemIcon;
                itemObj.transform.position = Vector2.zero;
                itemObj.name = itemToAdd.itemName;
                break;
            }
        }
    }

    void Tooltip()
    {

        ToolTipImage.gameObject.SetActive(true);

    }

    void TooltipClose()
    {
        ToolTipImage.gameObject.SetActive(false);
    }

}
