//EnemyController 스크립트
/*
 * 작성일자 : 2021-04-30                                 
스크립트 설명 : Enemy 제어하는 스크립트
스크립트 사용법 : 
                 
수정일자(1차) : 2021-05-03
수정내용(1차) : NavMeshAgent (플레이어 추적) 추가
                                  
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : BaseController
{
    private EnemyStatus stat;
    private Transform player;
    private NavMeshAgent nma;

    public override void Init()
    {
        stat = Util.GetOrAddComponent<EnemyStatus>(gameObject);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        nma = Util.GetOrAddComponent<NavMeshAgent>(gameObject);
    }

    protected override void UpdateIdle()
    {
        if (stat.ScanRange >= (transform.position - player.position).magnitude)
            State = Define.State.Move;

        //TODO : 일정시간이후 패트롤로 넘어가기

    }

    protected override void UpdatePatrol()
    {

        //패트롤 도중 몬스터 사거리안에 이동하면 플레이어 추적
        if (stat.ScanRange >= (transform.position - player.position).magnitude)
            State = Define.State.Move;


        //TODO : 일정시간이후 Idle로 넘어가기

    }

    protected override void UpdateMove()
    {
        //Player추적
        nma.destination = player.position;

        //TODO : 공격범위안에 들어왔을때 멈추기
        if ((transform.position - player.position).magnitude <= stat.AtkRange)
            State = Define.State.Attack;
    }


    protected override void UpdateAttack()
    {

    }
    protected override void UpdateSkill()
    {

    }

    protected override void UpdateDie()
    {

    }

}
