using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainUI_Slot : MonoBehaviour, IDropHandler
{
    public int id;
    private UI_Inventory inv;

    

    public void OnDrop(PointerEventData eventData)
    {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();

        if(inv.items[id].itemID == -1)
        {
            droppedItem.slot = id;
            inv.items[droppedItem.slot] = new Item();
            inv.items[id] = droppedItem.item;
        }
       
        else if(droppedItem.slot != id)
        {
            Transform item = transform.GetChild(0);
            item.GetComponent<ItemData>().slot = droppedItem.slot;
            item.transform.SetParent(inv.slots[droppedItem.slot].transform);
            item.transform.position = inv.slots[droppedItem.slot].transform.position;

            droppedItem.slot = id;
            droppedItem.transform.SetParent(this.transform);
            droppedItem.transform.position = this.transform.position;

            inv.items[droppedItem.slot] = item.GetComponent<ItemData>().item;
            inv.items[id] = droppedItem.item;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<UI_Inventory>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
