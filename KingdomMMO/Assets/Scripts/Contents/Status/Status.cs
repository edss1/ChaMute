//Status 스크립트
/*
 * 작성일자 : 2021-04-29                                 
스크립트 설명 : 공용 스테이터스 스크립트
스크립트 사용법 : 
                 
수정일자(1차) : 2021-04-30                                      
수정내용(1차) : ScanRange(인식범위)추가                                  
  
수정일자(2차) : 05-31
수정내용(2차) : OnAttacked함수 안의 damage공식 수정, 명중률, 크리티컬 추가
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
    protected float atkSpd;

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

    [Header("스테이터스")]
    [SerializeField]
    protected int strength;
    [SerializeField]
    protected int dexterity;
    [SerializeField]
    protected int agility;
    [SerializeField]
    protected int vitality;
    [SerializeField]
    protected int intelligence;
    [SerializeField]
    protected int energe;
    [SerializeField]
    protected int lucky;

    GameObject missText;
    GameObject criticalText;


    public int Level { get { return level; } set { level = value; } }
    public int Hp { get { return hp; } set { hp = value; } }
    public int MaxHp { get { return maxHp; } set { maxHp = value; } }
    public int Mana { get { return mana; } set { mana = value; } }
    public int MaxMana { get { return maxMana; } set { maxMana = value; } }
    public int Attack { get { return attack; } set { attack = value; } }
    public int MAttack { get { return mAttack; } set { mAttack = value; } }
    public int AtkRange { get { return atkRange; } set { atkRange = value; } }
    public float AtkSpd { get { return atkSpd; } set { atkSpd = value; } }
    public int Hit { get { return hit; } set { hit = value; } }
    public int Flee { get { return flee; } set { flee = value; } }
    public int ScanRange { get { return scanRange; } set { scanRange = value; } }
    public int Def { get { return def; } set { def = value; } }
    public int MDef { get { return mDef; } set { mDef = value; } }
    public int Reduction { get { return reduction; } set { reduction = value; } }
    public int MReduction { get { return mReduction; } set { mReduction = value; } }
    public int Critical { get { return critical; } set { critical = value; } }
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    public int Str { get { return strength; } set { strength = value; } }
    public int Dex { get { return dexterity; } set { dexterity = value; } }
    public int Agi { get { return agility; } set { agility = value; } }
    public int Vit { get { return vitality; } set { vitality = value; } }
    public int Int { get { return intelligence; } set { intelligence = value; } }
    public int Eng { get { return energe; } set { energe = value; } }
    public int Luk { get { return lucky; } set { lucky = value; } }



    void Start()
    {
        

    }


    public virtual void OnAttacked(Status attacker)
    {
        int hitOrFleeRand = Random.Range(1, 100);

        //난수가 [명중률 - 회피율]보다 작거나 같을경우(명중했을경우)
        if (hitOrFleeRand <= (attacker.Hit - Flee))
        {
            int damage;
            int criticalRand = Random.Range(1, 10000);

            //난수가 크리티컬보다 작거나 같을경우 (크리티컬이 터졌을 경우) 데미지 계산
            if (criticalRand <= attacker.Critical * 100)
            {
                damage = (int)Mathf.Max(attacker.Attack * (1000 - Def) / 1000 * 1.8f - (Vit / 10) - Reduction, 0);
                criticalText = Managers.Resource.Instantiate("UI/GameUI/CriticalText", gameObject.transform);
                Debug.Log("Critical!");
            }
            //난수가 크리티컬보다 클경우 (크리티컬이 안터졌을 경우) 데미지 계산
            else
                damage = Mathf.Max(attacker.Attack * (1000 - Def) / 1000 - (Vit / 10) - Reduction, 0);

            //실제 데미지를 입는 부분
            Hp -= damage;
            if (Hp <= 0)
            {
                Hp = 0;

                //사망
                OnDead(attacker);
            }
        }

        //난수가 [명중률 - 회피율]보다 클경우(명중하지 않았을 경우)
        else
        {
            //TODO : MISS 띄우기
            missText = Managers.Resource.Instantiate("UI/GameUI/MissText", gameObject.transform); 
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
