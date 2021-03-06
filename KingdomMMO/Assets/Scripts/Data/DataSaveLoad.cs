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
        string filePath = Path.Combine(Application.persistentDataPath, "inventoryData.json");
        File.WriteAllText(filePath, jsonData);


    }

    public void LoadItemDataToJson()
    {

        string filePath = Path.Combine(Application.persistentDataPath, "inventoryData.json");
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
        string filePath = Path.Combine(Application.persistentDataPath, "playerData.json");
        File.WriteAllText(filePath, jsonData);
    }

    [ContextMenu("From Json Data")]
    public void LoadPlayerDataToJson()
    {

        string filePath = Path.Combine(Application.persistentDataPath, "playerData.json");
        string jsonData = File.ReadAllText(filePath);
        playerData = JsonUtility.FromJson<PlayerData>(jsonData);

        stat.Level = playerData.level;
        stat.MaxHp = playerData.maxHp;
        stat.Attack = playerData.attack;
        stat.Exp = playerData.maxExp;
    }





    //인벤토리 스탯 추가시 PlayDataInInventory에서 변수 추가
    public void SavePlayerDataToJsonInInventory()
    {
        for (int i = 0; i < System.Enum.GetValues(typeof(UI_Inventory.Equip)).Length; i++)
        {
            if (inv.equipItems[i].ItemAttack != 0) playerDataInInventory.itemAttack = inv.equipItems[i].ItemAttack;
            if (inv.equipItems[i].ItemAtkSpeed != 0) playerDataInInventory.itemAttackSpeed = inv.equipItems[i].ItemAtkSpeed;
            if (inv.equipItems[i].ItemHit != 0) playerDataInInventory.itemHit = inv.equipItems[i].ItemHit;
            if (inv.equipItems[i].ItemCritical != 0) playerDataInInventory.itemCritical = inv.equipItems[i].ItemCritical;
            if (inv.equipItems[i].ItemCriticalDamage != 0) playerDataInInventory.itemCriticalDmg = inv.equipItems[i].ItemCriticalDamage;
            if (inv.equipItems[i].ItemMAttack != 0) playerDataInInventory.itemMagicAttack = inv.equipItems[i].ItemMAttack;
            if (inv.equipItems[i].ItemMaxHp != 0) playerDataInInventory.itemMaxHp = inv.equipItems[i].ItemMaxHp;
            if (inv.equipItems[i].ItemMaxMana != 0) playerDataInInventory.itemMaxMp = inv.equipItems[i].ItemMaxMana;
            if (inv.equipItems[i].ItemAmoreDef != 0) playerDataInInventory.itemAmoreDef = inv.equipItems[i].ItemAmoreDef;
            if (inv.equipItems[i].ItemCloakDef != 0) playerDataInInventory.itemCloakDef = inv.equipItems[i].ItemCloakDef;
            if (inv.equipItems[i].ItemHelmetDef != 0) playerDataInInventory.itemHelmetDef = inv.equipItems[i].ItemHelmetDef;
            if (inv.equipItems[i].ItemShoesDef != 0) playerDataInInventory.itemShoesDef = inv.equipItems[i].ItemShoesDef;
            if (inv.equipItems[i].ItemShieldDef != 0) playerDataInInventory.itemShieldDef = inv.equipItems[i].ItemShieldDef;
            if (inv.equipItems[i].ItemAmoreMDef != 0) playerDataInInventory.itemAmoreMDef = inv.equipItems[i].ItemAmoreMDef;
            if (inv.equipItems[i].ItemCloakMDef != 0) playerDataInInventory.itemCloakMDef = inv.equipItems[i].ItemCloakMDef;
            if (inv.equipItems[i].ItemHelmetMDef != 0) playerDataInInventory.itemHelmetMDef = inv.equipItems[i].ItemHelmetMDef;
            if (inv.equipItems[i].ItemShoesMDef != 0) playerDataInInventory.itemShoesMDef = inv.equipItems[i].ItemShoesMDef;
            if (inv.equipItems[i].ItemShieldMDef != 0) playerDataInInventory.itemShieldMDef = inv.equipItems[i].ItemShieldMDef;
            if (inv.equipItems[i].ItemFlee != 0) playerDataInInventory.itemFlee = inv.equipItems[i].ItemFlee;
            if (inv.equipItems[i].ItemGainExp != 0) playerDataInInventory.itemGainExp = inv.equipItems[i].ItemGainExp;
            if (inv.equipItems[i].ItemGainGold != 0) playerDataInInventory.itemGainGold = inv.equipItems[i].ItemGainGold;
            if (inv.equipItems[i].ItemGainCommonMaterial != 0) playerDataInInventory.itemGainCommonMaterial = inv.equipItems[i].ItemGainCommonMaterial;
            if (inv.equipItems[i].ItemGainRareMaterial != 0) playerDataInInventory.itemGainRareMaterial = inv.equipItems[i].ItemGainRareMaterial;
            if (inv.equipItems[i].ItemHpRegen != 0) playerDataInInventory.itemHpRegen = inv.equipItems[i].ItemHpRegen;
            if (inv.equipItems[i].ItemMpRegen != 0) playerDataInInventory.itemMpRegen = inv.equipItems[i].ItemMpRegen;
            
        }
        Debug.Log("Save");
        //playerDataInInventory.item = inv.equipItems[(int)UI_Inventory.Equip.].Item;
        //playerDataInInventory.item = inv.equipItems[(int)UI_Inventory.Equip.].Item;
        //playerDataInInventory.item = inv.equipItems[(int)UI_Inventory.Equip.].Item;
        //playerDataInInventory.item = inv.equipItems[(int)UI_Inventory.Equip.].Item;
        //playerDataInInventory.item = inv.equipItems[(int)UI_Inventory.Equip.].Item;
        //playerDataInInventory.item = inv.equipItems[(int)UI_Inventory.Equip.].Item;


        string jsonData = JsonUtility.ToJson(playerDataInInventory, true);
        string filePath = Path.Combine(Application.persistentDataPath, "PlayerDataInInventory.json");
        File.WriteAllText(filePath, jsonData);
    }

    public void LoadPlayerDataToJsonInInventory()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "PlayerDataInInventory.json");
        string jsonData = File.ReadAllText(filePath);
        playerDataInInventory = JsonUtility.FromJson<PlayerDataInInventory>(jsonData);


        stat.ItemAttack = playerDataInInventory.itemAttack;
        stat.ItemAttackSpeed = playerDataInInventory.itemAttackSpeed;
        stat.ItemHit = playerDataInInventory.itemHit;
        stat.ItemCritical = playerDataInInventory.itemHit;
        stat.ItemCriticalDmg = playerDataInInventory.itemHit;
        
    }




    void LoadItemData(UI_Inventory.Equip type)
    {
        switch (type)
        {
            case UI_Inventory.Equip.HELMET:
                {
                    inv.equipItems[(int)type].ItemID = equipInventoryData.helmetItemID;
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
    public float itemAttackSpeed;
    public int itemHit;
    public int itemCritical;
    public int itemCriticalDmg;
    public int itemMagicAttack;
    public int itemMaxHp;
    public int itemMaxMp;
    public int itemDef;
    public int itemMagicDef;

    public int itemAmoreDef;
    public int itemCloakDef;
    public int itemHelmetDef;
    public int itemShoesDef;
    public int itemShieldDef;

    public int itemAmoreMDef;
    public int itemCloakMDef;
    public int itemHelmetMDef;
    public int itemShoesMDef;
    public int itemShieldMDef;

    public int itemFlee;

    public float itemGainExp;
    public float itemGainGold;
    public float itemGainCommonMaterial;
    public float itemGainRareMaterial;

    public int itemHpRegen;
    public int itemMpRegen;






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