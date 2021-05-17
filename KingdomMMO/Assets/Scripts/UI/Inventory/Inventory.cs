using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();
    // 인벤토리를 리스트로 만듭니다.
    private ItemDatabase db;
    // 아이템 데이터베이스는 db로 축약해서 사용합니다.

    public int slotX = 4;
    public int slotY;    // 인벤토리 가로 세로 속성 설정 위한 변수
    public List<Item> slots = new List<Item>(); // 인벤토리 속성 변수

    private bool showInventory = false;
    // I버튼을 누르면 활성화/비활성화 되는 부울 변수
    public GUISkin skin;

    private bool showTooltip = false;
    private string tooltip;

    float time;
    // 툴팁 추가를 위한 부울 변수와 스트링 변수

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < slotX * slotY; i++)
        {
            slots.Add(new Item());
            // 아이템 슬롯칸에 빈 오브젝트 추가하기
            inventory.Add(new Item());
            // 인벤토리에 추가
        }
        db = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
        // 디비 변수에 "Item Database" 태그를 가진 오브젝트를 연결합니다.
        // 그리고 그 중 가져오는 컴포넌트는 "itemDatabse"라는 속성입니다.

        AddItem(1001);
    }

    void Update()
    {

    }

    public void InventoryClicked()
    {
        showInventory = !showInventory;
    }
    void OnGUI()
    {
        tooltip = "";
        GUI.skin = skin;
        // Skin 을 skin 답게 ' ㅅ'
        if (showInventory)
        {
            DrawInventory();
        }
        if (showTooltip)
        {
            GUI.Box(new Rect(Event.current.mousePosition.x + 5, Event.current.mousePosition.y + 2, 200, 200), tooltip, skin.GetStyle("tooltip"));
            // 아이템 설명창을 마우스의 좌표에 컨트롤 되게 설정하였으며, GUI skin을 응용하여 설정하였음
        }

    }

    void DrawInventory()
    {
        int k = 0;
        for (int j = 0; j < slotY; j++)
        {

            for (int i = 0; i < slotX; i++)
            {
                Rect slotRect = new Rect(i * 52 + 100, j * 52 + 30, 50, 50);
                // 박스 분할하기
                GUI.Box(slotRect, "", skin.GetStyle("slot background"));
                // 각 박스의 생성 위치를 설정해주는 곳입니다. skin.GetStyle은 이전에 만들었던 skin을 불러오는 것임


                // 기능 추가하기
                slots[k] = inventory[k];
                if (slots[k].itemName != null)
                {
                    GUI.DrawTexture(slotRect, slots[k].itemIcon);
                    if (slotRect.Contains(Event.current.mousePosition))
                    // 만약 마우스가 해당 인벤토리 창-버튼-위로 올라온다면,
                    {

                        time += Time.deltaTime;
                        Debug.Log(time);
                        tooltip = CreateTooltip(slots[i]);
                        if (time > 2.0f)
                        {
                            // 툴팁 만드는 함수를 실행하며,
                            // 보내는 속성은 i번째 슬롯입니다.
                            showTooltip = true;
                            // 툴팁을 만들고, showTooltip을 true로 만들어서 활성화 시켜줍니다.


                        }
                    }
                    else
                        time = 0;
                }

                if (tooltip == "")
                {
                    showTooltip = false;
                    if (time > 2.0f)
                        time = 0;

                }


                k++;
                // 갯수 증가
            }
        }
    }

    string CreateTooltip(Item item)
    {


        tooltip = "Item name: <color=#a10000><b>" + item.itemName + "</b></color>\nItem Damage: <color=#ffffff>" + item.itemAttack + "</color>\nItem Speed: <color=#ffffff>" + item.itemAtkSpeed + "</color>";
        /* html 태그가 어느정도 먹힘
         * <color=#000000> 말 </color>
         * <b> 두껍게 </b>
         * ... emdemdemd
         */

        return tooltip;
    }

    void AddItem(int id)
    // 본 함수에서 id를 받아서
    {
        for (int i = 0; i < inventory.Count; i++)
        // 전체 인벤토리를 모두 찾습니다
        {

            if (inventory[i].itemName == null)
            // 인벤토리가 빈자리면 
            {
                for (int j = 0; j < db.items.Count; j++)
                // 추가한 값까지 모두 찾은 다음에
                {
                    if (db.items[j].itemID == id)
                    {
                        // 디비의 아이템의 ID와 입력한 ID가 같다면,
                        inventory[i] = db.items[j];
                        // 빈 인벤토리에 db에 저장된 아이템을 적용하고
                        return;
                        // 함수를 마무리합니다.
                    }
                }
            }
        }
    }

    bool inventoryContains(int id)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            return (inventory[i].itemID == id);
        }
        return false;
    }

    void RemoveItem(int id)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemID == id)
            {
                inventory[i] = new Item();
                break;
            }
        }
    }
}
