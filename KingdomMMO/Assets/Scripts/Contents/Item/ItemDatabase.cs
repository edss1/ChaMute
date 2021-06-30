//ItemDatabase 스크립트
/*
 * 작성일자 : 2021-06-02
스크립트 설명 : 공용 아이템 스크립트
스크립트 사용법 : 
                 
수정일자(1차) : 06-03
수정내용(1차) : Item Class와 ItemData Class구분, Item을 List화 해서 AccessItemById함수를 이용해 itemID로 itemdata 접근
  
수정일자(2차) : 06-10
수정내용(2차) : 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    [Header("아이템 공통옵션")]
    [SerializeField] private string itemName;                 //  이름
    [SerializeField] private string itemGrade;                //  등급
    [SerializeField] private int itemID;                      //  고유번호
    [SerializeField] private string itemInfo;                  //  설명
    [SerializeField] private Sprite itemIcon;                 //  아이콘(2D)
    [SerializeField] private int itemReinforce;               //  강화
    [SerializeField] private float itemWeight;                  //  아이템의 무게
    [SerializeField] private bool itemStackable = false;       //중첩 가능or 불가능

    [Header("무기 주 옵션")]
    [SerializeField] private int itemAttack;                  //  공격력
    [SerializeField] private int itemMAttack;                 //  마법공격력 
    [SerializeField] private float itemAtkSpeed;              //  공격속도
    [SerializeField] private float itemAtkRange;              //  공격 사거리

    [Header("무기 추가(보너스) 옵션")]
    [SerializeField] private int itemHit;                     //  추가 명중률
    [SerializeField] private int itemCritical;                //  추가 크리티컬
    [SerializeField] private int itemCriticalDamage;          //  추가 크리티컬 데미지

    [Header("방어구 옵션")]
    [SerializeField] private int itemDef;                     //  방어력
    [SerializeField] private int itemMDef;                    //  마법방어력
    [SerializeField] private string itemMaterial = "";        //  방어구재질

    [Header("방어구 추가(보너스) 옵션")]
    [SerializeField] private int itemMaxHp;                   // 추가체력
    [SerializeField] private int itemMaxMana;                 // 추가마나
    [SerializeField] private int itemHpRegen;                 // 추가 체력회복력    
    [SerializeField] private int itemMpRegen;                 // 추가 마나회복력
    [SerializeField] private int itemMaxWeight;               // 추가 소지량
    [SerializeField] private int itemFlee;                    // 추가 회피력


    [Header("악세서리 옵션")]
    [SerializeField] private int itemStr;                     // 추가 힘
    [SerializeField] private int itemDex;                     // 추가 덱스
    [SerializeField] private int itemAgi;                     // 추가 어질
    [SerializeField] private int itemVit;                     // 추가 바탈
    [SerializeField] private int itemInt;                     // 추가 인트
    [SerializeField] private int itemEng;                     // 추가 에너지
    [SerializeField] private int itemLuk;                     // 추가 럭
    [SerializeField] private int itemAccessoryDef;            // 추가 악세방어
    [SerializeField] private int itemAccessoryMDef;           // 추가 악세마방
    [SerializeField] private int itemAccessoryAtk;            // 추가 공격력
    [SerializeField] private int itemAccessoryMAtk;           // 추가 마법공격력
    [SerializeField] private int itemAccessoryMaxHp;          // 추가 체력
    [SerializeField] private int itemAccessoryMaxMana;        // 추가 마나

    
    [Header("소모품 옵션")]
    [SerializeField] private int itemPotionHp;                // 체력포션
    [SerializeField] private int itemPotionManaRegen;         // 마나리젠포션
    [SerializeField] private int itemPotionMoveSpeed;         // 이동속도 포션
    [SerializeField] private int itemPotionAtkSpeed;          // 공격속도 포션
    [SerializeField] private int itemPotionAtk;               // 공격력 포션
    [SerializeField] private int itemPotionMAtk;              // 마법공격력 포션

    
    [Header("부적 옵션")]
    [SerializeField] private float itemGainExp;             // 경험치 획득 부적
    [SerializeField] private float itemGainGold;            // 골드 획득 부적
    [SerializeField] private float itemGainRareMaterial;    // 레어자원 획득 부적
    [SerializeField] private float itemGainCommonMaterial;  // 일반자원 획득 부적

    [SerializeField] private int itemSellingPrice;                //판매가격
    [SerializeField] private int itemBuyPrice;                    //구매가격


    public string ItemName { get { return itemName; } set { itemName = value; } }
    public string ItemGrade { get { return itemGrade; } set { itemGrade = value; } }
    public int ItemID { get { return itemID; } set { itemID = value; } }
    public string ItemInfo { get { return itemInfo; } set { itemInfo = value; } }
    public Sprite ItemIcon { get { return itemIcon; } set { itemIcon = value; } }
    public int ItemReinforce { get { return itemReinforce; } set { itemReinforce = value; } }
    public float ItemWeight { get { return itemWeight; } set { itemWeight = value; } }
    public bool ItemStackable { get { return itemStackable; } set { itemStackable = value; } }
    public int ItemAttack { get { return itemAttack; } set { itemAttack = value; } }
    public int ItemMAttack { get { return itemMAttack; } set { itemMAttack = value; } }
    public float ItemAtkSpeed { get { return itemAtkSpeed; } set { itemAtkSpeed = value; } }
    public float ItemAtkRange { get { return itemAtkRange; } set { itemAtkRange = value; } }
    public int ItemHit { get { return itemHit; } set { itemHit = value; } }
    public int ItemCritical { get { return itemCritical; } set { itemCritical = value; } }
    public int ItemCriticalDamage { get { return itemCriticalDamage; } set { itemCriticalDamage = value; } }
    public int ItemDef { get { return itemDef; } set { itemDef = value; } }
    public int ItemMDef { get { return itemMDef; } set { itemMDef = value; } }
    public string ItemMaterial { get { return itemMaterial; } set { itemMaterial = value; } }
    public int ItemMaxHp { get { return itemMaxHp; } set { itemMaxHp = value; } }
    public int ItemMaxMana { get { return itemMaxMana; } set { itemMaxMana = value; } }
    public int ItemHpRegen { get { return itemHpRegen; } set { itemHpRegen = value; } }
    public int ItemMpRegen { get { return itemMpRegen; } set { itemMpRegen = value; } }
    public int ItemMaxWeight { get { return itemMaxWeight; } set { itemMaxWeight = value; } }
    public int ItemFlee { get { return itemFlee; } set { itemFlee = value; } }
    public int ItemStr { get { return itemStr; } set { itemStr = value; } }
    public int ItemDex { get { return itemDex; } set { itemDex = value; } }
    public int ItemAgi { get { return itemAgi; } set { itemAgi = value; } }
    public int ItemVit { get { return itemVit; } set { itemVit = value; } }
    public int ItemInt { get { return itemInt; } set { itemInt = value; } }
    public int ItemEng { get { return itemEng; } set { itemEng = value; } }
    public int ItemLuk { get { return itemLuk; } set { itemLuk = value; } }
    public int ItemAccessoryDef { get { return itemAccessoryDef; } set { itemAccessoryDef = value; } }
    public int ItemAccessoryMDef { get { return itemAccessoryMDef; } set { itemAccessoryMDef = value; } }
    public int ItemAccessoryAtk { get { return itemAccessoryAtk; } set { itemAccessoryAtk = value; } }
    public int ItemAccessoryMAtk { get { return itemAccessoryMAtk; } set { itemAccessoryMAtk = value; } }
    public int ItemAccessoryMaxHp { get { return itemAccessoryMaxHp; } set { itemAccessoryMaxHp = value; } }
    public int ItemAccessoryMaxMana { get { return itemAccessoryMaxMana; } set { itemAccessoryMaxMana = value; } }
    public int ItemPotionHp { get { return itemPotionHp; } set { itemPotionHp = value; } }
    public int ItemPotionManaRegen { get { return itemPotionManaRegen; } set { itemPotionManaRegen = value; } }
    public int ItemPotionMoveSpeed { get { return itemPotionMoveSpeed; } set { itemPotionMoveSpeed = value; } }
    public int ItemPotionAtkSpeed { get { return itemPotionAtkSpeed; } set { itemPotionAtkSpeed = value; } }
    public int ItemPotionAtk { get { return itemPotionAtk; } set { itemPotionAtk = value; } }
    public int ItemPotionMAtk { get { return itemPotionMAtk; } set { itemPotionMAtk = value; } }
    public float ItemGainExp { get { return itemGainExp; } set { itemGainExp = value; } }
    public float ItemGainGold { get { return itemGainGold; } set { itemGainGold = value; } }
    public float ItemGainRareMaterial { get { return itemGainRareMaterial; } set { itemGainRareMaterial = value; } }
    public float ItemGainCommonMaterial { get { return itemGainCommonMaterial; } set { itemGainCommonMaterial = value; } }
    public int ItemSellingPrice { get { return itemSellingPrice; } set { itemSellingPrice = value; } }
    public int ItemBuyPrice { get { return itemBuyPrice; } set { itemBuyPrice = value; } }









    public Define.ItemType itemType;

    public Item(int _itemID, Define.ItemType type)
    {
        switch (type)
        {
            case Define.ItemType.Weapon:
                {
                    //공통옵션
                    Dictionary<int, Data.Weapon> dict = Managers.Data.WeaponDict;

                    Data.Weapon weapon = dict[_itemID];

                    itemType = Define.ItemType.Weapon;
                    itemID = _itemID;
                    itemName = weapon.name;

                    switch (weapon.grade)
                    {
                        case 1:
                            itemGrade = "common";
                            break;
                        case 2:
                            itemGrade = "uncommon";
                            break;
                        case 3:
                            itemGrade = "rare";
                            break;
                        case 4:
                            itemGrade = "unique";
                            break;
                        case 5:
                            itemGrade = "legendary";
                            break;
                        default:
                            itemGrade = "Error";
                            break;
                    }
                    itemIcon = Resources.Load<Sprite>($"Materials/Images/{_itemID}");

                    itemInfo = weapon.info;
                    itemReinforce = weapon.reinforce;
                    itemWeight = weapon.weight;

                    //무기옵션
                    itemAttack = weapon.attack;
                    itemMAttack = weapon.mAttack;
                    itemAtkSpeed = weapon.atkSpeed;
                    itemAtkRange = weapon.atkRange;
                    itemHit = weapon.hit;
                    itemCritical = weapon.critical;
                    itemCriticalDamage = weapon.criticalDmg;
                }
                break;

            case Define.ItemType.Amore:
                {
                    //공통옵션
                    Dictionary<int, Data.Amore> dict = Managers.Data.AmoreDict;
                    Data.Amore amore = dict[_itemID];

                    itemType = Define.ItemType.Amore;
                    itemID = _itemID;
                    itemName = amore.name;
                    switch (amore.grade)
                    {
                        case 1:
                            itemGrade = "common";
                            break;
                        case 2:
                            itemGrade = "uncommon";
                            break;
                        case 3:
                            itemGrade = "rare";
                            break;
                        case 4:
                            itemGrade = "unique";
                            break;
                        case 5:
                            itemGrade = "legendary";
                            break;
                        default:
                            itemGrade = "Error";
                            break;
                    }
                    itemIcon = Resources.Load<Sprite>($"Materials/Images/{_itemID}");
                    itemInfo = amore.info;
                    itemReinforce = amore.reinforce;
                    itemWeight = amore.weight;

                    //방어구 옵션
                    itemDef = amore.def;
                    itemMDef = amore.mDef;

                    switch (amore.material)
                    {
                        case 1:
                            itemMaterial = "천";
                            break;
                        case 2:
                            itemMaterial = "가죽";
                            break;
                        case 3:
                            itemMaterial = "판금";
                            break;
                    }

                    itemMaxHp = amore.maxHp;
                    itemMaxMana = amore.maxMana;
                    itemHpRegen = amore.hpRegen;
                    itemMpRegen = amore.mpRegen;
                    itemMaxWeight = amore.maxWeight;
                    itemFlee = amore.flee;
                }
                break;

            case Define.ItemType.Accessory:
                {
                    //공통옵션
                    Dictionary<int, Data.Accessory> dict = Managers.Data.AccessoryDict;
                    Data.Accessory accessory = dict[_itemID];

                    itemType = Define.ItemType.Accessory;
                    itemID = _itemID;
                    itemName = accessory.name;
                    switch (accessory.grade)
                    {
                        case 1:
                            itemGrade = "common";
                            break;
                        case 2:
                            itemGrade = "uncommon";
                            break;
                        case 3:
                            itemGrade = "rare";
                            break;
                        case 4:
                            itemGrade = "unique";
                            break;
                        case 5:
                            itemGrade = "legendary";
                            break;
                        default:
                            itemGrade = "Error";
                            break;
                    }
                    itemIcon = Resources.Load<Sprite>($"Materials/Images/{_itemID}");
                    itemInfo = accessory.info;
                    itemReinforce = accessory.reinforce;
                    itemWeight = accessory.weight;

                    itemStr = accessory.Str;
                    itemDex = accessory.Dex;
                    itemAgi = accessory.Agi;
                    itemVit = accessory.Vit;
                    itemInt = accessory.Int;
                    itemEng = accessory.Eng;
                    itemLuk = accessory.Luk;
                    itemAccessoryDef = accessory.def;
                    itemAccessoryMDef = accessory.mDef;
                    itemAccessoryAtk = accessory.atk;
                    itemAccessoryMAtk = accessory.mAtk;
                    itemAccessoryMaxHp = accessory.maxHp;
                    itemAccessoryMaxMana = accessory.maxMana;
                }
                break;
            case Define.ItemType.Material:
                {
                    //공통옵션
                    Dictionary<int, Data.Material> dict = Managers.Data.MaterialDict;
                    Data.Material material = dict[_itemID];

                    itemType = Define.ItemType.Material;
                    itemID = _itemID;
                    itemName = material.name;
                    switch (material.grade)
                    {
                        case 1:
                            itemGrade = "common";
                            break;
                        case 2:
                            itemGrade = "uncommon";
                            break;
                        case 3:
                            itemGrade = "rare";
                            break;
                        case 4:
                            itemGrade = "unique";
                            break;
                        case 5:
                            itemGrade = "legendary";
                            break;
                        default:
                            itemGrade = "Error";
                            break;
                    }
                    itemIcon = Resources.Load<Sprite>($"Materials/Images/{_itemID}");
                    itemInfo = material.info;
                    itemWeight = material.weight;
                    itemSellingPrice = material.sellingPrice;
                    itemStackable = material.stackable;
                }
                break;
            case Define.ItemType.Useable:
                {
                    //공통옵션
                    Dictionary<int, Data.Useable> dict = Managers.Data.UseableDict;
                    Data.Useable useable = dict[_itemID];

                    itemType = Define.ItemType.Useable;
                    itemID = _itemID;
                    itemName = useable.name;
                    itemIcon = Resources.Load<Sprite>($"Materials/Images/{_itemID}");
                    itemInfo = useable.info;
                    itemWeight = useable.weight;
                    itemSellingPrice = useable.sellingPrice;
                    itemBuyPrice = useable.buyPrice;

                    itemPotionHp = useable.potionHp;
                    itemPotionManaRegen = useable.potionManaRegen;
                    itemPotionMoveSpeed = useable.potionMoveSpeed;
                    itemPotionAtkSpeed = useable.potionAtkSpeed;
                    itemPotionAtk = useable.potionAtk;
                    itemPotionMAtk = useable.potionMAtk;
                    itemStackable = useable.stackable;
                }
                break;

            case Define.ItemType.Blueprint:
                {
                    Dictionary<int, Data.Blueprint> dict = Managers.Data.BlueprintDict;
                    Data.Blueprint blueprint = dict[_itemID];

                    itemType = Define.ItemType.Blueprint;
                    itemID = _itemID;
                    itemName = blueprint.name;
                    switch (blueprint.grade)
                    {
                        case 1:
                            itemGrade = "common";
                            break;
                        case 2:
                            itemGrade = "uncommon";
                            break;
                        case 3:
                            itemGrade = "rare";
                            break;
                        case 4:
                            itemGrade = "unique";
                            break;
                        case 5:
                            itemGrade = "legendary";
                            break;
                        default:
                            itemGrade = "Error";
                            break;
                    }
                    itemIcon = Resources.Load<Sprite>($"Materials/Images/{_itemID}");
                    itemInfo = blueprint.info;
                    itemWeight = blueprint.weight;
                    itemSellingPrice = blueprint.sellingPrice;
                    itemStackable = blueprint.stackable;

                }
                break;

            case Define.ItemType.Charm:
                {
                    //공통옵션
                    Dictionary<int, Data.Charm> dict = Managers.Data.CharmDict;
                    Data.Charm charm = dict[_itemID];

                    itemType = Define.ItemType.Charm;
                    itemID = _itemID;
                    itemName = charm.name;
                    itemIcon = Resources.Load<Sprite>($"Materials/Images/{_itemID}");
                    itemInfo = charm.info;
                    itemWeight = charm.weight;

                    itemGainExp = charm.gainExp;
                    itemGainGold = charm.gainGold;
                    itemGainCommonMaterial = charm.gainCommonMaterial;
                    itemGainRareMaterial = charm.gainRareMaterial;

                }
                break;
            case Define.ItemType.QuestItem:
                break;

            case Define.ItemType.None:
                {
                    itemType = Define.ItemType.None;
                    itemID = _itemID;
                    itemIcon = Resources.Load<Sprite>($"Materials/Images/{_itemID}");
                    itemName = "";
                }
                break;
            default:
                break;
        }

    }

    public Item()
    {
        itemID = -1;
    }
}


public class ItemDatabase : MonoBehaviour
{
    List<Item> database = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        AddItemToList();
    }

    //itemId로 database 접근
    public Item AccessItemById(int id)
    {
        for (int i = 0; i < database.Count; i++)
        {
            if (database[i].ItemID == id)
                return database[i];
        }
        return null;
    }


    //database List에 Item 추가 (itemId, Item타입)
    void AddItemToList()
    {

        database.Add(new Item(11001, Define.ItemType.Weapon));
        database.Add(new Item(11002, Define.ItemType.Weapon));
        database.Add(new Item(21001, Define.ItemType.Amore));
        database.Add(new Item(31001, Define.ItemType.Accessory));
        database.Add(new Item(41001, Define.ItemType.Material));
        database.Add(new Item(51001, Define.ItemType.Useable));
        database.Add(new Item(61001, Define.ItemType.Blueprint));
        database.Add(new Item(62001, Define.ItemType.Blueprint));
        database.Add(new Item(71001, Define.ItemType.Charm));
        database.Add(new Item(99999, Define.ItemType.None));
    }
}
