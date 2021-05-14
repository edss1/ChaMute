//EnemyStatus 스크립트
/*
 * 작성일자 : 2021-04-29                                 
스크립트 설명 : 몬스터 전용 스테이터스 스크립트
스크립트 사용법 : 
                 
수정일자(1차) :                                       
수정내용(1차) :                                   
                                  
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : Status
{
    [Header("몬스터 사망시 보상")]
    [SerializeField]
    private int rewardGold;
    [SerializeField]
    private int rewardExp;

    public int RewardGold { get { return rewardGold; } set { rewardGold = value; } }
    public int RewardExp { get { return rewardExp; } set { rewardExp = value; } }


    void Start()
    {
        
        scanRange = 10;
        moveSpeed = 6.0f;
        atkRange = 2;
    }
}
