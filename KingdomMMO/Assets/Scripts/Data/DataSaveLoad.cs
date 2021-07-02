using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataSaveLoad : MonoBehaviour
{
    PlayerStatus stat;
    public PlayerData playerData = new PlayerData();

    [SerializeField]
    GameObject inventory;
    UI_Inventory inv;
    public InventoryData inventoryData = new InventoryData();

    private void Start()
    {
        stat = GameObject.FindGameObjectWithTag("Status").GetComponent<PlayerStatus>();
        inv = inventory.GetComponent<UI_Inventory>();
    }

    public void SaveItemDataToJson()
    {
        inventoryData.weaponItemId = inv.equipItems[(int)UI_Inventory.Equip.WEAPON].ItemID;

        string jsonData = JsonUtility.ToJson(inventoryData, true);
        string filePath = Path.Combine(Application.dataPath, "inventoryData.json");
        File.WriteAllText(filePath, jsonData);
    }

    public void LoadItemDataToJson()
    {

        string filePath = Path.Combine(Application.dataPath, "inventoryData.json");
        string jsonData = File.ReadAllText(filePath);
        inventoryData = JsonUtility.FromJson<InventoryData>(jsonData);

        inv.equipItems[(int)UI_Inventory.Equip.WEAPON].ItemID = inventoryData.weaponItemId;
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
public class InventoryData
{
    public int weaponItemId;
    public int weaponReinforce;
}
