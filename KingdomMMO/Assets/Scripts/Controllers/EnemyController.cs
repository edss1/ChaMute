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
    private GameObject player;

    private Vector3 returnPos;

    [SerializeField]
    private Vector3 randomVec;
    [SerializeField]
    private float patrolTime = 0.0f;

    public override void Init()
    {
        stat = gameObject.GetOrAddComponent<EnemyStatus>();
        player = GameObject.FindGameObjectWithTag("Player");
        returnPos = transform.position;
    }

    protected override void UpdateIdle()
    {
        float distance = (player.transform.position - transform.position).magnitude;
        if (distance <= stat.ScanRange)
        {
            lockTarget = player;
            State = Define.State.Move;
            return;
        }
        
        patrolTime += Time.deltaTime;

        if (patrolTime > 2.0f)
        {
            randomVec = new Vector3(transform.position.x + Random.Range(-3,3), 0 , transform.position.z + Random.Range(-3, 3));
            State = Define.State.Patrol;
        }


    }

    protected override void UpdatePatrol()
    {
        //패트롤 도중 몬스터 사거리안에 이동하면 플레이어 추적
        float distance = (player.transform.position - transform.position).magnitude;
        if (distance <= stat.ScanRange)
        {
            lockTarget = player;
            State = Define.State.Move;
        }


        NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
        nma.SetDestination(randomVec);
        patrolTime = 0;
        
        if( (transform.position-randomVec).magnitude<0.1f)
        State = Define.State.Idle;

    }

    protected override void UpdateMove()
    {
        if (lockTarget != null)
        {
            destPos = lockTarget.transform.position;
            float distance = (destPos - transform.position).magnitude;
            if (distance <= stat.AtkRange)
            {
                NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
                nma.SetDestination(transform.position);
                State = Define.State.Attack;

                return;
            }
        }

        Vector3 dir = destPos - transform.position;
        if (dir.magnitude < 0.1f)
        {
            NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
            State = Define.State.Idle;
        }

        else
        {
            NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
            nma.SetDestination(destPos);
            nma.speed = stat.MoveSpeed;

            //가속도
            nma.acceleration = 1000;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 100 * Time.deltaTime);


        }

        //되돌아가기
       if (dir.magnitude > stat.ScanRange)
       {
            State = Define.State.Return;
       }
    }


    //TODO : 본인의 포지션에서 일정거리 이상 멀어졌을때 돌아가는것으로 수정요함
    protected override void UpdateReturn()
    {
        NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
        nma.SetDestination(returnPos);
        nma.speed = stat.MoveSpeed / 3;
        Vector3 dir = returnPos - transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(dir.x,0,dir.z)), 100 * Time.deltaTime);
        stat.Hp = stat.MaxHp;

        if (dir.magnitude < 0.1f)
        {
            State = Define.State.Idle;
        }
    }


    protected override void UpdateAttack()
    {
        Vector3 dir = lockTarget.transform.position - transform.position;
        Quaternion quat = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, quat, stat.MoveSpeed * Time.deltaTime);

        if((transform.position - player.transform.position).magnitude > stat.AtkRange)
        {
            State = Define.State.Move;
        }
    }




    protected override void UpdateSkill()
    {

    }

    protected override void UpdateDie()
    {

    }

}
