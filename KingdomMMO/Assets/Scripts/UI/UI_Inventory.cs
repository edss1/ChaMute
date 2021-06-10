//UI_Inventory 스크립트
/*
 * 작성일자 : 2021-06-02
스크립트 설명 : 인벤토리 스크립트
스크립트 사용법 : 
                 
수정일자(1차) : 
수정내용(1차) : 

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Inventory : MonoBehaviour
{
    GameObject inventoryPanel;
    GameObject slotPanel;
    ItemDatabase database;

    [SerializeField]
    GameObject inventorySlot;
    [SerializeField]
    GameObject inventoryItem;

    int slotAmount;

    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    private void Start()
    {
        database = GetComponent<ItemDatabase>();

        slotAmount = 20;
        inventoryPanel = GameObject.Find("Inventory Panel");
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
    }

    public void AddItem(int id)
    {
        Item itemToAdd = database.AccessItemById(id);
        for (int i = 0; i < items.Count; i++)
        {
            if(items[i].itemID == -1)
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

}
