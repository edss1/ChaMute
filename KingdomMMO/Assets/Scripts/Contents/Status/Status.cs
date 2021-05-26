//Status 스크립트
/*
 * 작성일자 : 2021-04-29                                 
스크립트 설명 : 공용 스테이터스 스크립트
스크립트 사용법 : 
                 
수정일자(1차) : 2021-04-30                                      
수정내용(1차) : ScanRange(인식범위)추가                                  
                                  
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    
    
    [Header("레벨")]
    [SerializeField]
    protected int level;

    [Header("체력, 마나")]
    [SerializeField]
    protected int hp;
    [SerializeField]
    protected int maxHp;
    [SerializeField]
    protected int mana;
    [SerializeField]
    protected int maxMana;

    //공격력
    [Header("공격 관련")]
    [SerializeField]
    protected int attack;
    [SerializeField]
    protected int mAttack;

    //사거리
    [SerializeField]
    protected int atkRange;

    //공격속도
    [SerializeField]
    protected int atkSpd;

    //명중률+회피율
    [SerializeField]
    protected int hit;
    [SerializeField]
    protected int flee;

    [SerializeField]
    protected int scanRange;
    
    //크리티컬
    [SerializeField]
    protected int critical;

    //방어관련
    [Header("방어 관련")]
    [SerializeField]
    protected int def;
    [SerializeField]
    protected int mDef;
    [SerializeField]
    protected int reduction;
    [SerializeField]
    protected int mReduction;


    //이동속도
    [Header("이동속도 관련")]
    [SerializeField]
    protected float moveSpeed;

    public int Level { get { return level; } set { level = value; } }
    public int Hp { get { return hp; } set { hp = value; } }
    public int MaxHp { get { return maxHp; } set { maxHp = value; } }
    public int Mana { get { return mana; } set { mana = value; } }
    public int MaxMana { get { return maxMana; } set { maxMana = value; } }
    public int Attack { get { return attack; } set { attack = value; } }
    public int MAttack { get { return mAttack; } set { mAttack = value; } }
    public int AtkRange { get { return atkRange; } set { atkRange = value; } }
    public int AtkSpd { get { return atkSpd; } set { atkSpd = value; } }
    public int Hit { get { return hit; } set { hit = value; } }
    public int Flee { get { return flee; } set { flee = value; } }
    public int ScanRange { get { return scanRange; } set { scanRange = value; } }
    public int Def { get { return def; } set { def = value; } }
    public int MDef { get { return mDef; } set { mDef = value; } }
    public int Reduction { get { return reduction; } set { reduction = value; } }
    public int MReduction { get { return mReduction; } set { mReduction = value; } }
    public int Critical { get { return critical; } set { critical = value; } }
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    
    

    void Start()
    {
    

    }


    public virtual void OnAttacked(Status attacker)
    {
        int damage = Mathf.Max(attacker.Attack - Def, 0);
        Hp -= damage;
        if (Hp <= 0)
        {
            Hp = 0;
            OnDead(attacker);
        }
    
    
    }
    
    protected virtual void OnDead(Status attacker)
    {
        PlayerStatus playerStatus = attacker as PlayerStatus;
        
        if (playerStatus != null)
        {
            EnemyStatus targetStat = gameObject.GetComponent<EnemyStatus>();
            playerStatus.Exp += targetStat.RewardExp;
        }
    
        Managers.Game.Despawn(gameObject);
    }
}
