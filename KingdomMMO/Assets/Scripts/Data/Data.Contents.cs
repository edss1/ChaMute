//Data.Contents 스크립트
/*
 * 작성일자 : 2021-06-02
스크립트 설명 : 데이터를 관리해주는 스크립트
스크립트 사용법 : 
                 
수정일자(1차) : 06-10
수정내용(1차) : Amore, Accessory, Material, Useable 클래스 및 각각의 Data클래스 추가

*/


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    #region Stat

    [Serializable]
    public class Stat
    {
        public int level;
        public int maxHp;
        public int attack;
        public int maxExp;
    }

    [Serializable]
    public class StatData : ILoader<int, Stat>
    {
        public List<Stat> stats = new List<Stat>();
       

        public Dictionary<int, Stat> MakeDict()
        {
            Dictionary<int, Stat> dict = new Dictionary<int, Stat>();
            foreach (Stat stat in stats)
                dict.Add(stat.level, stat);
            return dict;
        }

    }

    #endregion

    #region Item
    [Serializable]
    public class Item
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
            Charm,                      // 부적
            QuestItem,                  // 퀘스트 아이템류
                                        // 아이템 속성을 필요한 것만큼 여기에 추가하면 추후 유니티 3D에서 직접 선택할 수 있습니다.
                                        // 근데 보통 옷, 무기, 퀘스트아이템 정도아닌가?
        }

        public enum ItemGrade           // 아이템의 등급
        {                               
            Common,                     // 일반
            UnCommon,                   // 희귀
            Rare,                       // 레어
            Unique,                     // 유니크
            Legendary,                  // 레전더리
        }

        public ItemType itemType = ItemType.None;       // 아이템의 속성 설정
        public ItemGrade itemGrade;     // 아이템의 등급 설정

        [Header("아이템 공통옵션")]
        public string   itemName;         //  이름
        public int      itemID;              //  고유번호
        public string   itemInfo;          //  설명
        public Texture2D itemIcon;      //  아이콘(2D)
        public int      itemReinforce;       //  강화
        public int      itemWeight;          //  아이템의 무게

        [Header("부적 옵션")]
        public int itemGainExp;             // 경험치 획득 부적
        public int itemGainGold;            // 골드 획득 부적
        public int itemGainRareMaterial;    // 레어자원 획득 부적
        public int itemGainCommonMaterial;  // 일반자원 획득 부적

    }

    [Serializable]
    public class ItemData : ILoader<int, Item>
    {
        public List<Item> items = new List<Item>();

        public Dictionary<int, Item> MakeDict()
        {
            Dictionary<int, Item> dict = new Dictionary<int, Item>();
            foreach (Item item in items)
                dict.Add(item.itemID, item);
            return dict;
        }
    }

    #endregion


    #region Weapon
    [Serializable]
    public class Weapon
    {
        [Header("아이템 공통옵션")]
        public string   name;         //  이름
        public int   grade;          //등급
        public int      id;              //  고유번호
        public string   info;          //  설명
        public int      reinforce;       //  강화
        public int      weight;          //  아이템의 무게
        


        [Header("무기 주 옵션")]
        public int      attack;          //  공격력
        public int      mAttack;         //  마법공격력 
        public float    atkSpeed;      //  공격속도
        public float    atkRange;      //  공격 사거리

        [Header("무기 추가(보너스) 옵션")]
        public int hit;             //  추가 명중률
        public int critical;        //  추가 크리티컬
        public int criticalDmg;     //  추가 크리티컬 데미지

    }

    [Serializable]
    public class WeaponData : ILoader<int, Weapon>
    {
        public List<Weapon> weapons = new List<Weapon>();

        public Dictionary<int, Weapon> MakeDict()
        {
            Dictionary<int, Weapon> dict = new Dictionary<int, Weapon>();
            foreach (Weapon weapon in weapons)
                dict.Add(weapon.id, weapon);
            return dict;
        }
    }

    #endregion

    #region Amore
    [Serializable]
    public class Amore
    {
        [Header("아이템 공통옵션")]
        public string name;         //  이름
        public int grade;          //등급
        public int id;              //  고유번호
        public string info;          //  설명
        public int reinforce;       //  강화
        public int weight;          //  아이템의 무게


        [Header("방어구 옵션")]
        public int def;             //  방어력
        public int mDef;            //  마법방어력
        public int material;        //  재질

        [Header("방어구 추가(보너스) 옵션")]
        public int maxHp;           // 추가체력
        public int maxMana;         // 추가마나
        public int hpRegen;         // 추가 체력회복력    
        public int mpRegen;         // 추가 마나회복력
        public int maxWeight;       // 추가 소지량
        public int flee;            // 추가 회피력

    }

    [Serializable]
    public class AmoreData : ILoader<int, Amore>
    {
        public List<Amore> amores = new List<Amore>();

        public Dictionary<int, Amore> MakeDict()
        {
            Dictionary<int, Amore> dict = new Dictionary<int, Amore>();
            foreach (Amore amore in amores)
                dict.Add(amore.id, amore);
            return dict;
        }
    }

    #endregion

    #region Accessory
    [Serializable]
    public class Accessory
    {
        [Header("아이템 공통옵션")]
        public string name;         //  이름
        public int grade;          //등급
        public int id;              //  고유번호
        public string info;          //  설명
        public int reinforce;       //  강화
        public int weight;          //  아이템의 무게


        [Header("악세서리 옵션")]
        public int Str;             // 추가 힘
        public int Dex;             // 추가 덱스
        public int Agi;             // 추가 어질
        public int Vit;             // 추가 바탈
        public int Int;             // 추가 인트
        public int Eng;             // 추가 에너지
        public int Luk;             // 추가 럭
        public int def;             // 추가 악세방어
        public int mDef;            // 추가 악세마방
        public int atk;             // 추가 공격력
        public int mAtk;            // 추가 마법공격력
        public int maxHp;           // 추가 체력
        public int maxMana;         // 추가 마나

    }

    [Serializable]
    public class AccessoryData : ILoader<int, Accessory>
    {
        public List<Accessory> accessories = new List<Accessory>();

        public Dictionary<int, Accessory> MakeDict()
        {
            Dictionary<int, Accessory> dict = new Dictionary<int, Accessory>();
            foreach (Accessory accessoriy in accessories)
                dict.Add(accessoriy.id, accessoriy);
            return dict;
        }
    }

    #endregion

    #region Material
    [Serializable]
    public class Material
    {
        [Header("아이템 공통옵션")]
        public string name;         //  이름
        public int grade;          //등급
        public int id;              //  고유번호
        public string info;          //  설명
        public float weight;          //  아이템의 무게
        public int sellingPrice;    // 판매가격
        public bool stackable;       // 중첩 가능
    }

    [Serializable]
    public class MaterialData : ILoader<int, Material>
    {
        public List<Material> materials = new List<Material>();

        public Dictionary<int, Material> MakeDict()
        {
            Dictionary<int, Material> dict = new Dictionary<int, Material>();
            foreach (Material material in materials)
                dict.Add(material.id, material);
            return dict;
        }
    }

    #endregion

    #region Useable
    [Serializable]
    public class Useable
    {
        [Header("아이템 공통옵션")]
        public string name;         //  이름
        public int id;              //  고유번호
        public string info;          //  설명
        public float weight;          //  아이템의 무게
        public int sellingPrice;    // 판매가격
        public int buyPrice;        // 구매가격
        public bool stackable;       // 중첩 가능

        [Header("소모품 옵션")]
        public int potionHp;        // 체력포션
        public int potionManaRegen; // 마나리젠포션
        public int potionMoveSpeed; // 이동속도 포션
        public int potionAtkSpeed;  // 공격속도 포션
        public int potionAtk;       // 공격력 포션
        public int potionMAtk;      // 마법공격력 포션
    }

    [Serializable]
    public class UseableData : ILoader<int, Useable>
    {
        public List<Useable> useables = new List<Useable>();

        public Dictionary<int, Useable> MakeDict()
        {
            Dictionary<int, Useable> dict = new Dictionary<int, Useable>();
            foreach (Useable useable in useables)
                dict.Add(useable.id, useable);
            return dict;
        }
    }


    #endregion

    #region Blueprint

    [Serializable]
    public class Blueprint
    {
        [Header("아이템 공통옵션")]
        public string name;         //  이름
        public int grade;          //등급
        public int id;              //  고유번호
        public string info;          //  설명
        public float weight;          //  아이템의 무게
        public int sellingPrice;    // 판매가격
        public bool stackable;       // 중첩 가능

    }

    [Serializable]
    public class BlueprintData : ILoader<int, Blueprint>
    {
        public List<Blueprint> blueprints = new List<Blueprint>();

        public Dictionary<int, Blueprint> MakeDict()
        {
            Dictionary<int, Blueprint> dict = new Dictionary<int, Blueprint>();
            foreach (Blueprint blueprint in blueprints)
                dict.Add(blueprint.id, blueprint);
            return dict;
        }
    }

    #endregion

    #region Charm

    [Serializable]
    public class Charm
    {
        [Header("아이템 공통옵션")]
        public string name;         //  이름
        public int id;              //  고유번호
        public string info;          //  설명
        public float weight;          //  아이템의 무게

        [Header("부적 옵션")]
        public float gainExp;             // 경험치 획득 부적
        public float gainGold;            // 골드 획득 부적
        public float gainRareMaterial;    // 레어자원 획득 부적
        public float gainCommonMaterial;  // 일반자원 획득 부적

    }

    [Serializable]
    public class CharmData : ILoader<int, Charm>
    {
        public List<Charm> charms = new List<Charm>();

        public Dictionary<int, Charm> MakeDict()
        {
            Dictionary<int, Charm> dict = new Dictionary<int, Charm>();
            foreach (Charm charm in charms)
                dict.Add(charm.id, charm);
            return dict;
        }
    }


    #endregion
}
