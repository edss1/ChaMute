//PlayerStatus 스크립트
/*
 * 작성일자 : 2021-04-29                                 
스크립트 설명 : 플레이어 전용 스테이터스 스크립트
스크립트 사용법 : 
                 
수정일자(1차) :                                       
수정내용(1차) :                                   
                                  
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
    private int dextility;
    [SerializeField]
    private int agility;
    [SerializeField]
    private int vitality;
    [SerializeField]
    private int intelligence;
    [SerializeField]
    private int wisdom;
    [SerializeField]
    private int lucky;


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

    public int Str { get { return strength; } set { strength = value; } }
    public int Dex { get { return dextility; } set { dextility = value; } }
    public int Agi { get { return agility; } set { agility = value; } }
    public int Vit { get { return vitality; } set { vitality = value; } }
    public int Int { get { return intelligence; } set { intelligence = value; } }
    public int Wis { get { return wisdom; } set { wisdom = value; } }
    public int Luk { get { return lucky; } set { lucky = value; } }
    public int HpRegen { get { return hpRegen; } set { hpRegen = value; } }
    public int MpRegen { get { return mpRegen; } set { mpRegen = value; } }
    public int Weight { get { return weight; } set { weight = value; } }
    public int MaxWeight { get { return maxWeight; } set { maxWeight = value; } }
    public int StatusPoint { get { return statusPoint; } set { statusPoint = value; } }
    public int Exp { get { return exp; } set { exp = value; } }
    public int MaxExp { get { return maxExp; } set { maxExp = value; } }
    public int Gold { get { return gold; } set { gold = value; } }
    public int Diamond { get { return diamond; } set { diamond = value; } }

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
