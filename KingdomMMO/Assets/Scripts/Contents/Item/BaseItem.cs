//Item 스크립트
/*
 * 작성일자 : 2021-06-02
스크립트 설명 : 공용 아이템 스크립트
스크립트 사용법 : 
                 
수정일자(1차) : 
수정내용(1차) :  
  
수정일자(2차) : 
수정내용(2차) : 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    [Header("아이템 공통옵션")]
    public string itemName;         //  이름
    public string itemGrage;        //  등급
    public int itemID;              //  고유번호
    public string itemInfo;          //  설명
    public Texture2D itemIcon;      //  아이콘(2D)
    public int itemReinforce;       //  강화
    public int itemWeight;          //  아이템의 무게

    [Header("무기 주 옵션")]
    public int itemAttack;          //  공격력
    public int itemMAttack;         //  마법공격력 
    public float itemAtkSpeed;      //  공격속도
    public float itemAtkRange;      //  공격 사거리

    [Header("무기 추가(보너스) 옵션")]
    public int itemHit;             //  추가 명중률
    public int itemCritical;        //  추가 크리티컬

    [Header("방어구 옵션")]
    public int itemDef;             //  방어력
    public int itemMDef;            //  마법방어력

    [Header("방어구 추가(보너스) 옵션")]
    public int itemMaxHp;           // 추가체력
    public int itemMaxMana;         // 추가마나
    public int itemHpRegen;         // 추가 체력회복력    
    public int itemMpRegen;         // 추가 마나회복력
    public int itemMaxWeight;       // 추가 소지량
    public int itemFlee;            // 추가 회피력


    [Header("악세서리 옵션")]
    public int itemStr;             // 추가 힘
    public int itemDex;             // 추가 덱스
    public int itemAgi;             // 추가 어질
    public int itemVit;             // 추가 바탈
    public int itemInt;             // 추가 인트
    public int itemEng;             // 추가 에너지
    public int itemLuk;             // 추가 럭
    public int itemAccessoryDef;    // 추가 악세방어
    public int itemAccessoryMDef;   // 추가 악세마방
    public int itemAccessoryAtk;    // 추가 공격력
    public int itemAccessoryMAtk;   // 추가 마법공격력
    public int itemAccessoryMaxHp;  // 추가 체력
    public int itemAccessoryMaxMana;// 추가 마나

    [Header("소모품 옵션")]
    public int itemPotionHp;        // 체력포션
    public int itemPotionManaRegen; // 마나리젠포션
    public int itemPotionMoveSpeed; // 이동속도 포션
    public int itemPotionAtkSpeed;  // 공격속도 포션
    public int itemPotionAtk;       // 공격력 포션
    public int itemPotionMAtk;      // 마법공격력 포션

    [Header("부적 옵션")]
    public int itemGainExp;             // 경험치 획득 부적
    public int itemGainGold;            // 골드 획득 부적
    public int itemGainRareMaterial;    // 레어자원 획득 부적
    public int itemGainCommonMaterial;  // 일반자원 획득 부적

    public Item(int itemId, Define.ItemType type)
    {

        switch (type)
        {
            case Define.ItemType.Weapon:
                {
                    Dictionary<int, Data.Weapon> dict = Managers.Data.WeaponDict;
                    Data.Weapon weapon = dict[itemId];

                    itemName = weapon.name;
                    itemGrage = weapon.grade;
                    itemIcon = Resources.Load<Texture2D>($"Materials/Images/{itemId}");
                    itemInfo = weapon.info;
                    itemIcon = weapon.Icon;
                    itemReinforce = weapon.reinforce;
                    itemWeight = weapon.weight;

                    itemAttack = weapon.attack;
                    itemMAttack = weapon.mAttack;
                    itemAtkSpeed = weapon.atkSpeed;
                    itemAtkRange = weapon.atkRange;
                }
                break;
            case Define.ItemType.Amore:
                break;
            case Define.ItemType.Accessory:
                break;
            case Define.ItemType.Material:
                break;
            case Define.ItemType.Useable:
                break;
            case Define.ItemType.Blueprint:
                break;
            case Define.ItemType.Goods:
                break;
            case Define.ItemType.Charm:
                break;
            case Define.ItemType.QuestItem:
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

public class BaseItem : MonoBehaviour
{


    List<Item> database = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        AddItem();

        Debug.Log(FetchItemById(0).itemName);




    }

    public Item FetchItemById(int id)
    {
        for (int i = 0; i < database.Count; i++)
        {
            if (database[i].itemID == id)
                return database[i];
        }
        return null;
    }


    void AddItem()
    {
        database.Add(new Item(11001, Define.ItemType.Weapon));
    }


}
