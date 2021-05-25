//PlayerStatus 스크립트
/*
 * 작성일자 : 2021-04-29                                 
스크립트 설명 : 플레이어 전용 스테이터스 스크립트
스크립트 사용법 : 
                 
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
    //투자해야하는 status
    [Header("플레이어 스테이터스")]
    [SerializeField]
    private int strength;
    [SerializeField]
    private int dexterity;
    [SerializeField]
    private int agility;
    [SerializeField]
    private int vitality;
    [SerializeField]
    private int intelligence;
    [SerializeField]
    private int energe;
    [SerializeField]
    private int lucky;

    //근거리, 원거리 공격력
    [Header("플레이어 스테이터스")]
    [SerializeField]
    private int swordAtk;
    [SerializeField]
    private int rangeAtk;

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

    public int Str { get { return strength; } set { strength = value; } }
    public int Dex { get { return dexterity; } set { dexterity = value; } }
    public int Agi { get { return agility; } set { agility = value; } }
    public int Vit { get { return vitality; } set { vitality = value; } }
    public int Int { get { return intelligence; } set { intelligence = value; } }
    public int Eng { get { return energe; } set { energe = value; } }
    public int Luk { get { return lucky; } set { lucky = value; } }
    public int SwordAtk { get { return swordAtk; } set { swordAtk = value; } }
    public int RangeAtk { get { return rangeAtk; } set { rangeAtk = value; } }
    public int HpRegen { get { return hpRegen; } set { hpRegen = value; } }
    public int MpRegen { get { return mpRegen; } set { mpRegen = value; } }
    public int Weight { get { return weight; } set { weight = value; } }
    public int MaxWeight { get { return maxWeight; } set { maxWeight = value; } }
    public int StatusPoint { get { return statusPoint; } set { statusPoint = value; } }
   
    public int Exp
    {
        get { return exp; }
        set
        {
            exp = value;

            int level = Level;
            while (true)
            {
                Data.Stat stat;
                if (Managers.Data.StatDict.TryGetValue(level + 1, out stat) == false)
                    break;
                if (exp < stat.totalExp)
                    break;
                level++;
            }

            if (level != Level)
            {
                Debug.Log("Level UP!");
                Level = level;
                SetStat(Level);
            }
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
        maxHp = 200;
        hp = 200;
        attack = 20;
        level = 1;
    }

    public void SetStat(int _level)
    {
        Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;
        Data.Stat stat = dict[_level];

        hp = stat.maxHp;
        maxHp = stat.maxHp;
        attack = stat.attack;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
