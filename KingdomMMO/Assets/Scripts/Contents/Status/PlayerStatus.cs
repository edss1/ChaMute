//PlayerStatus 스크립트
/*
 * 작성일자 : 2021-04-29                                 
스크립트 설명 : 플레이어 전용 스테이터스 스크립트
스크립트 사용법 : GetComponent로 불러와서 사용함
                 
수정일자(1차) : 2021-05-07
수정내용(1차) : 획득률 증가 헤더 및 세부 변수 추가, 공격력을 원거리공격력, 근거리공격력으로 세분화
                    
수정일자(2차) : 05-25
수정내용(2차) : 경험치 획득부분 수정
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : Status
{
    [SerializeField]
    private int itemAttack;
    [SerializeField]
    private int itemMAttack;
    [SerializeField]
    private int itemDef;
    [SerializeField]
    private int itemMDef;
    [SerializeField]
    private float itemAtkSpeed;
    [SerializeField]
    private int itemHit;
    [SerializeField]
    private int itemCritical;
    [SerializeField]
    private int itemCriticalDmg;
    [SerializeField]
    private int itemMaxHp;
    [SerializeField]
    private int itemMaxMp;





    //회복량
    [Header("플레이어 자연회복량")]
    [SerializeField]
    private int hpRegen;
    [SerializeField]
    private int mpRegen;

    //무게
    [Header("플레이어 무게")]
    [SerializeField]
    private int weight;
    [SerializeField]
    private int maxWeight;

    //스테이터스 포인트
    [Header("플레이어 스테이터스 포인트")]
    [SerializeField]
    private int statusPoint;

    //경험치
    [Header("플레이어 경험치")]
    [SerializeField]
    private int exp;
    [SerializeField]
    private int maxExp;

    //재화
    [Header("플레이어 보유 재화")]
    [SerializeField]
    private int gold;
    [SerializeField]
    private int diamond;

    //획득량 및 획득률 증가
    [Header("획득률 증가")]
    [SerializeField]
    private float gainingRateExp;
    [SerializeField]
    private float gainingGold;
    [SerializeField]
    private float gainingNomalMeterial;
    [SerializeField]
    private float gainingEquipmentAndRarityMeterial;

    //장비관련




    public int ItemAttack { get { return itemAttack; } set { itemAttack = value; } }
    public int ItemMAttack { get { return itemMAttack; } set { itemMAttack = value; } }
    public float ItemAttackSpeed { get { return itemAtkSpeed; } set { itemAtkSpeed = value; } }
    public int ItemHit { get { return itemHit; }set { itemHit = value; } }
    public int ItemCritical { get { return itemCritical; }set { itemCritical = value; } }
    public int ItemCriticalDmg { get { return itemCriticalDmg; }set { itemCriticalDmg = value; } }
    public int ItemDef { get { return itemDef; } set { itemDef = value; } }
    public int ItemMDef { get { return itemMDef; } set { itemMDef = value; } }
    public int HpRegen { get { return hpRegen; } set { hpRegen = value; } }
    public int MpRegen { get { return mpRegen; } set { mpRegen = value; } }
    public int Weight { get { return weight; } set { weight = value; } }
    public int MaxWeight { get { return maxWeight; } set { maxWeight = value; } }
    public int StatusPoint { get { return statusPoint; } set { statusPoint = value; } }
    public int ItemMaxHp { get { return itemMaxHp; }set { itemMaxHp = value; } }
    public int ItemMaxMp { get { return itemMaxMp; }set { itemMaxMp = value; } }



    public int Exp
    {
        get { return exp; }
        set
        {
            exp = value;

            //레벨업을 해야할 곳에 추가
            //int level = Level;
            //while (true)
            //{
            //    Data.Stat stat;
            //    if (Managers.Data.StatDict.TryGetValue(level + 1, out stat) == false)
            //        break;
            //    if (exp < stat.maxExp)
            //        break;
            //    level++;
            //}
            //
            //if (level != Level)
            //{
            //    Debug.Log("Level UP!");
            //    Level = level;
            //    SetStat(Level);
            //}
        }
    }
  
    public int MaxExp { get { return maxExp; } set { maxExp = value; } }
    public int Gold { get { return gold; } set { gold = value; } }
    public int Diamond { get { return diamond; } set { diamond = value; } }
    public float GainingRateExp { get { return gainingRateExp; } set { gainingRateExp = value; } }
    public float GainingGold { get { return gainingGold; } set { gainingGold = value; } }
    public float GainingNomalMeterial { get { return gainingNomalMeterial; } set { gainingNomalMeterial = value; } }
    public float GainingEquipmentAndRarityMeterial { get { return gainingEquipmentAndRarityMeterial; } set { gainingEquipmentAndRarityMeterial = value; } }



    // Start is called before the first frame update
    void Start()
    {
        level = 1;

        Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;
        Data.Stat stat = dict[1];

        SetStat(level);
        moveSpeed = 10.0f;
        scanRange = 10;
        atkRange = 3;
        atkSpd = 1.0f;


        def = 500;
        Vit = 1;
        reduction = 1;
        hit = 60;
        flee = 10;
    }

    public void SetStat(int _level)
    {
        Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;

        Data.Stat stat = dict[_level];

        hp = stat.maxHp;
        maxHp = stat.maxHp;
        attack = stat.attack;
        maxExp = stat.maxExp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
