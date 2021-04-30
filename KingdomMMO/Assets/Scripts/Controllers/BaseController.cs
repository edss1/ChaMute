//BaseController 스크립트
/*
 * 작성일자 : 2021-04-30                                 
스크립트 설명 : 메인 Controller 스크립트
스크립트 사용법 : PlayerController 스크립트와 EnemyController 스크립트에 공통으로 들어가는 정보를 모아둔다.
                 
수정일자(1차) :                          
수정내용(1차) :                                  
                                  
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    [SerializeField]
    protected Vector3 destPos;

    [SerializeField]
    protected Define.State _state = Define.State.Idle;

    [SerializeField]
    protected GameObject _lockTarget;

    public Define.WorldObject WorldObjectType { get; protected set; } = Define.WorldObject.Unknown;


    public virtual Define.State State
    {
        get { return _state; }
        set
        {
            _state = value;
            //Animator anim = GetComponent<Animator>();
            //switch (_state)
            //{
            //    case Define.State.Die:
            //        break;
            //    case Define.State.Idle:
            //        anim.CrossFade("WAIT", 0.1f);
            //        break;
            //    case Define.State.Move:
            //        anim.CrossFade("RUN", 0.1f);
            //        break;
            //    case Define.State.Skill:
            //        anim.CrossFade("ATTACK", 0.1f, -1, 0);
            //        break;
            //}
        }
    }

    private void Start()
    {
        Init();
    }


    private void Update()
    {

        switch (State)
        {
            case Define.State.Die:
                UpdateDie();
                break;
            case Define.State.Idle:
                UpdateIdle();
                break;
            case Define.State.Move:
                UpdateMove();
                break;
            case Define.State.Skill:
                UpdateSkill();
                break;
            case Define.State.Patrol:
                UpdateSkill();
                break;
            case Define.State.Attack:
                UpdateSkill();
                break;

        }
    }

    public abstract void Init();
    protected virtual void UpdateDie() { }
    protected virtual void UpdateIdle() { }
    protected virtual void UpdateMove() { }
    protected virtual void UpdateSkill() { }
    protected virtual void UpdatePatrol() { }
    protected virtual void UpdateAttack() { }
}

