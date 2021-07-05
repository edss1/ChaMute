using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.IO;

public class DataSaveLoad : MonoBehaviour
{
    PlayerStatus stat;
    public PlayerData playerData = new PlayerData();

    public PlayerDataInInventory playerDataInInventory = new PlayerDataInInventory();

    
    ItemDatabase database;

   
    [SerializeField]
    GameObject inventory;
    UI_Inventory inv;
    public EquipInventoryData equipInventoryData = new EquipInventoryData();

    private void Awake()
    {
        stat = GameObject.FindGameObjectWithTag("Status").GetComponent<PlayerStatus>();
        inv = inventory.GetComponent<UI_Inventory>();

        database = inv.itemData.GetComponent<ItemDatabase>();
    }

    public void SaveItemDataToJson()
    {
        equipInventoryData.weaponItemId = inv.equipItems[(int)UI_Inventory.Equip.WEAPON].ItemID;
        equipInventoryData.weaponReinforce = inv.equipItems[(int)UI_Inventory.Equip.WEAPON].ItemReinforce;

            string jsonData = JsonUtility.ToJson(equipInventoryData, true);
            string filePath = Path.Combine(Application.dataPath, "inventoryData.json");
            File.WriteAllText(filePath, jsonData);


    }

    public void LoadItemDataToJson()
    {

        string filePath = Path.Combine(Application.dataPath, "inventoryData.json");
        string jsonData = File.ReadAllText(filePath);
        equipInventoryData = JsonUtility.FromJson<EquipInventoryData>(jsonData);

        inv.equipItems[(int)UI_Inventory.Equip.WEAPON].ItemID = equipInventoryData.weaponItemId;

     
            GameObject equipItemObj = Instantiate(inv.inventoryItem);
            equipItemObj.transform.SetParent(inv.equipSlots[(int)UI_Inventory.Equip.WEAPON].transform);
            equipItemObj.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Materials/Images/{inv.equipItems[(int)UI_Inventory.Equip.WEAPON].ItemID}");
            equipItemObj.transform.position = inv.equipSlots[(int)UI_Inventory.Equip.WEAPON].transform.position;
            equipItemObj.name = inv.equipItems[(int)UI_Inventory.Equip.WEAPON].ItemName;

            Item itemToAdd = database.AccessItemById(inv.equipItems[(int)UI_Inventory.Equip.WEAPON].ItemID);


            inv.equipItems[(int)UI_Inventory.Equip.WEAPON] = itemToAdd;

            Debug.Log(inv.equipItems[(int)UI_Inventory.Equip.WEAPON].ItemID);


    }

    [ContextMenu("To Json Data")]
    public void SavePlayerDataToJson()
    {
        playerData.level = stat.Level;
        playerData.maxHp = stat.MaxHp;
        playerData.attack = stat.Attack;
        playerData.maxExp = stat.Exp;

        
        string jsonData = JsonUtility.ToJson(playerData, true);
        string filePath = Path.Combine(Application.dataPath, "playerData.json");
        File.WriteAllText(filePath, jsonData);
    }

    [ContextMenu("From Json Data")]
    public void LoadPlayerDataToJson()
    {

        string filePath = Path.Combine(Application.dataPath, "playerData.json");
        string jsonData = File.ReadAllText(filePath);
        playerData = JsonUtility.FromJson<PlayerData>(jsonData);

        stat.Level = playerData.level;
        stat.MaxHp = playerData.maxHp;
        stat.Attack = playerData.attack;
        stat.Exp = playerData.maxExp;
    }






    public void SavePlayerDataToJsonInInventory()
    {
        playerDataInInventory.itemAttack = inv.equipItems[(int)UI_Inventory.Equip.WEAPON].ItemAttack;


        string jsonData = JsonUtility.ToJson(playerDataInInventory, true);
        string filePath = Path.Combine(Application.dataPath, "PlayerDataInInventory.json");
        File.WriteAllText(filePath, jsonData);
    }

    public void LoadPlayerDataToJsonInInventory()
    {
        string filePath = Path.Combine(Application.dataPath, "PlayerDataInInventory.json");
        string jsonData = File.ReadAllText(filePath);
        playerDataInInventory = JsonUtility.FromJson<PlayerDataInInventory>(jsonData);


        stat.ItemAttack = playerDataInInventory.itemAttack;
    }

}


[System.Serializable]
public class PlayerData
{
    public int level;
    public int maxHp;
    public int attack;
    public int maxExp;

}

[Serializable]
public class PlayerDataInInventory
{
    public int itemAttack;
}



[Serializable]
public class EquipInventoryData
{
    public int weaponItemId;
    public int weaponReinforce;
}

[Serializable]
public class InventoryData
{
    public int slotId;
    public int slotAmount;
    public int reinforce;
}