using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Item1
{
    public enum ItemType            // 아이템의 속성 설정에 대한 갯수
    {
        None,
        Weapon,                     // 무기류 (검, 방패, 창 등 해당)
        Amore,                      // 옷류   (상의, 하의, 모자 등 해당)
        Accessory,                  // 악세서리 (목걸이, 반지)
        Material,                   // 재료
        Useable,                    // 소모품
        Blueprint,                  // 설계도
        Goods,                      // 재화
        Charm,                      // 부적
        QuestItem,                  // 퀘스트 아이템류
        // 아이템 속성을 필요한 것만큼 여기에 추가하면 추후 유니티 3D에서 직접 선택할 수 있습니다.
        // 근데 보통 옷, 무기, 퀘스트아이템 정도아닌가?
    }

    public enum ItemGrade           // 아이템의 등급
    {
        Common,
        UnCommon,
        Rare,
        Unique,
        Legendary,
    }

    public ItemType itemType = ItemType.None;       // 아이템의 속성 설정
    public ItemGrade itemGrade;     // 아이템의 등급 설정

   

    [Header("아이템 공통옵션")]
    public string itemName;         //  이름
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

    //[Header("추가옵션")]
    //[Header("추가옵션")]
    //[Header("추가옵션")]


    public Item1()
    {

    }

    public Item1(string img, string name, int id, string desc, int power, int speed, int defense, int evasion, ItemType type)
    // 아이템의 필요한 속성을 모두 위에 적어줍니다.(다른곳에서 받아올 예정)
    {
        itemName = name;
        // 윗 줄과 같이 모두 연결해줍니다.
        itemID = id;
        itemInfo = desc;
        itemAttack = power;
        // itemIcon 속성은 별도의 방법을 이용합니다.
        itemIcon = Resources.Load<Texture2D>("Materials/Images/34x34icons180709_" + img);
        // itemIcon 속성은 별도의 방법을 이용합니다.

        itemAtkSpeed = speed;
        itemDef = defense;
        itemFlee = evasion;
        itemType = type;
        // 으하하하하
    }

}


