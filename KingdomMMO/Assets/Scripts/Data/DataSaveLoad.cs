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
        equipInventoryData.weaponItemID = inv.equipItems[(int)UI_Inventory.Equip.WEAPON].ItemID;
        equipInventoryData.weaponReinforce = inv.equipItems[(int)UI_Inventory.Equip.WEAPON].ItemWeaponReinforce;

        equipInventoryData.amoreItemID = inv.equipItems[(int)UI_Inventory.Equip.AMORE].ItemID;



        string jsonData = JsonUtility.ToJson(equipInventoryData, true);
        string filePath = Path.Combine(Application.dataPath, "inventoryData.json");
        File.WriteAllText(filePath, jsonData);


    }

    public void LoadItemDataToJson()
    {

        string filePath = Path.Combine(Application.dataPath, "inventoryData.json");
        string jsonData = File.ReadAllText(filePath);
        equipInventoryData = JsonUtility.FromJson<EquipInventoryData>(jsonData);

        LoadItemData(UI_Inventory.Equip.WEAPON);
        LoadItemData(UI_Inventory.Equip.AMORE);

        //#region LoadItemData 함수를 빼내서 작성


        //inv.equipItems[(int)UI_Inventory.Equip.WEAPON].ItemID = equipInventoryData.weaponItemID;
        //
        //if (inv.equipItems[(int)UI_Inventory.Equip.WEAPON].ItemID != -1)
        //
        //{
        //    GameObject equipItemObj = Instantiate(inv.inventoryItem);
        //    equipItemObj.transform.SetParent(inv.equipSlots[(int)UI_Inventory.Equip.WEAPON].transform);
        //    equipItemObj.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Materials/Images/{inv.equipItems[(int)UI_Inventory.Equip.WEAPON].ItemID}");
        //    equipItemObj.transform.position = inv.equipSlots[(int)UI_Inventory.Equip.WEAPON].transform.position;
        //    equipItemObj.name = inv.equipItems[(int)UI_Inventory.Equip.WEAPON].ItemName;
        //
        //    Item itemToAdd = database.AccessItemById(inv.equipItems[(int)UI_Inventory.Equip.WEAPON].ItemID);
        //
        //
        //    inv.equipItems[(int)UI_Inventory.Equip.WEAPON] = itemToAdd;
        //
        //
        //    Debug.Log(inv.equipItems[(int)UI_Inventory.Equip.WEAPON].ItemID);
        //
        //}
        //else
        //{
        //    inv.equipItems[(int)UI_Inventory.Equip.WEAPON] = new Item();
        //
        //}
        //
        //
        //
        //
        //
        //////////////////갑옷/무기 구분선
        //
        //inv.equipItems[(int)UI_Inventory.Equip.AMORE].ItemID = equipInventoryData.amoreItemID;
        //
        //if (inv.equipItems[(int)UI_Inventory.Equip.AMORE].ItemID != -1)
        //
        //{
        //    GameObject equipiii = Instantiate(inv.inventoryItem);
        //    equipiii.transform.SetParent(inv.equipSlots[(int)UI_Inventory.Equip.AMORE].transform);
        //    equipiii.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Materials/Images/{inv.equipItems[(int)UI_Inventory.Equip.AMORE].ItemID}");
        //    equipiii.transform.position = inv.equipSlots[(int)UI_Inventory.Equip.AMORE].transform.position;
        //    equipiii.name = inv.equipItems[(int)UI_Inventory.Equip.AMORE].ItemName;
        //
        //    Item itemToAdda = database.AccessItemById(inv.equipItems[(int)UI_Inventory.Equip.AMORE].ItemID);
        //
        //
        //    inv.equipItems[(int)UI_Inventory.Equip.AMORE] = itemToAdda;
        //}
        //else
        //{
        //    inv.equipItems[(int)UI_Inventory.Equip.AMORE] = new Item();
        //
        //}
        //
        ////Debug.Log(inv.equipItems[(int)UI_Inventory.Equip.AMORE].ItemID);
        //#endregion
        //
    }//

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




    void LoadItemData(UI_Inventory.Equip type)
    {
        switch (type)
        {
            case UI_Inventory.Equip.HELMET:
                {
                    inv.equipItems[(int)type].ItemID = equipInventoryData.helmetItemID;
                    //inv.equipItems[(int)type].ItemHelmetReinforce = equipInventoryData.helmetReinforce;
                }
                break;
            case UI_Inventory.Equip.AMORE:
                {
                    inv.equipItems[(int)type].ItemID = equipInventoryData.amoreItemID;
                    inv.equipItems[(int)type].ItemHelmetReinforce = equipInventoryData.amoreReinforce;
                }
                break;
            case UI_Inventory.Equip.WEAPON:
                {
                    inv.equipItems[(int)type].ItemID = equipInventoryData.weaponItemID;
                    inv.equipItems[(int)type].ItemWeaponReinforce = equipInventoryData.weaponReinforce;
                }
                break;
            case UI_Inventory.Equip.SHIELD:
                {
                    inv.equipItems[(int)type].ItemID = equipInventoryData.shieldItemID;
                    inv.equipItems[(int)type].ItemShieldReinforce = equipInventoryData.shieldReinforce;
                }
                break;
            case UI_Inventory.Equip.CLOAK:
                {
                    inv.equipItems[(int)type].ItemID = equipInventoryData.cloakItemID;
                    inv.equipItems[(int)type].ItemCloakReinforce = equipInventoryData.cloakReinforce;
                }
                break;
            case UI_Inventory.Equip.SHOES:
                {
                    inv.equipItems[(int)type].ItemID = equipInventoryData.shoesItemID;
                    inv.equipItems[(int)type].ItemShoesReinforce = equipInventoryData.shoesReinforce;
                }
                break;
            case UI_Inventory.Equip.ACCESSORYONE:
                {
                    inv.equipItems[(int)type].ItemID = equipInventoryData.accessoryOneItemID;
                }
                break;
            case UI_Inventory.Equip.ACCESSORYTWO:
                {
                    inv.equipItems[(int)type].ItemID = equipInventoryData.accessoryTwoItemID;
                }
                break;
            case UI_Inventory.Equip.EXPCHARM:
                {
                    inv.equipItems[(int)type].ItemID = equipInventoryData.expCharmItemID;
                    inv.equipItems[(int)type].ItemExpCharmReinforce = equipInventoryData.expCharmReinforce;
                }
                break;
            case UI_Inventory.Equip.GOLDCHARM:
                {
                    inv.equipItems[(int)type].ItemID = equipInventoryData.goldCharmItemID;
                    inv.equipItems[(int)type].ItemGoldCharmReinforce = equipInventoryData.goldCharmReinforce;
                }
                break;
            case UI_Inventory.Equip.RAREMATERIALCHARM:
                {
                    inv.equipItems[(int)type].ItemID = equipInventoryData.rareMaterialCharmItemID;
                    inv.equipItems[(int)type].ItemRareMaterialCharmReinforce = equipInventoryData.rareMaterialCharmReinforce;
                }
                break;
            case UI_Inventory.Equip.NOMALMATERIALCHARM:
                {
                    inv.equipItems[(int)type].ItemID = equipInventoryData.nomalMaterialCharmItemID;
                    inv.equipItems[(int)type].ItemCommonMaterialCharmReinforce = equipInventoryData.nomalMaterialCharmReinforce;
                }
                break;
            case UI_Inventory.Equip.POTIONONE:
                {
                    inv.equipItems[(int)type].ItemID = equipInventoryData.potionOneItemID;
                }
                break;
            case UI_Inventory.Equip.POTIONTWO:
                {
                    inv.equipItems[(int)type].ItemID = equipInventoryData.potionTwoItemID;
                }
                break;
            case UI_Inventory.Equip.POTIONTHREE:
                {
                    inv.equipItems[(int)type].ItemID = equipInventoryData.potionThreeItemID;
                }
                break;
        }

        if (inv.equipItems[(int)type].ItemID != -1)
        {
            GameObject equipItemObj = Instantiate(inv.inventoryItem);
            equipItemObj.transform.SetParent(inv.equipSlots[(int)type].transform);
            equipItemObj.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Materials/Images/{inv.equipItems[(int)type].ItemID}");
            equipItemObj.transform.position = inv.equipSlots[(int)type].transform.position;
            equipItemObj.name = inv.equipItems[(int)type].ItemName;

            Item itemToAdd = database.AccessItemById(inv.equipItems[(int)type].ItemID);


            inv.equipItems[(int)type] = itemToAdd;
        }
        else
        {
            inv.equipItems[(int)type] = new Item();
        }
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
    public int weaponItemID;
    public int weaponReinforce;

    public int helmetItemID;
    public int helmetReinforce;

    public int amoreItemID;
    public int amoreReinforce;

    public int shieldItemID;
    public int shieldReinforce;

    public int cloakItemID;
    public int cloakReinforce;

    public int shoesItemID;
    public int shoesReinforce;

    public int accessoryOneItemID;
    public int accessoryTwoItemID;

    public int expCharmItemID;
    public int expCharmReinforce;

    public int goldCharmItemID;
    public int goldCharmReinforce;

    public int rareMaterialCharmItemID;
    public int rareMaterialCharmReinforce;

    public int nomalMaterialCharmItemID;
    public int nomalMaterialCharmReinforce;

    public int potionOneItemID;
    public int potionTwoItemID;
    public int potionThreeItemID;
}


[Serializable]
public class InventoryData
{
    public int slotId;
    public int slotAmount;
    public int reinforce;
}