//UI_Inventory 스크립트
/*
 * 작성일자 : 2021-06-02
스크립트 설명 : 인벤토리 스크립트
스크립트 사용법 : 
                 
수정일자(1차) : 06-15
수정내용(1차) : 슬롯 버튼화, 툴팁 페이지 추가, 툴팁에 이미지 출력

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
    Text itemWeightText;              //아이템 타입




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
                    slots[i].onClick.AddListener(Tooltip);
                    toolTipItemImg.sprite = items[i].itemIcon;
                    itemNameText.text = items[i].itemName;
                    itemWeightText.text = "무게 : " + items[i].itemWeight.ToString();

                    switch (items[i].itemType)
                    {
                        case Define.ItemType.Weapon:
                            {
                                itemTypeText.text = "타입 : 무기";
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
