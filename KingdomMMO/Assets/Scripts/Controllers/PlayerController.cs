﻿//PlayerController 스크립트
/*
 * 작성일자 : 2021-04-29                                 
스크립트 설명 : 플레이어 제어하는 스크립트
스크립트 사용법 : 
                 
수정일자(1차) : 
수정내용(1차) : 
                                  
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : BaseController
{
    private UI_Joystick joystick;
    private PlayerStatus stat;

    GameObject[] enemy;
    [SerializeField]
    GameObject nearEnemy;

    public override void Init()
    {
        joystick = FindObjectOfType<UI_Joystick>();
        stat = gameObject.GetOrAddComponent<PlayerStatus>();


    }

    protected override void UpdateIdle()
    {
        //타겟이 없을경우 타겟 설정 후 이동하기
        if (lockTarget == null)
        {
            enemy = GameObject.FindGameObjectsWithTag("Enemy");
            float nearDist = Mathf.Infinity;

            for (int i = 0; i < enemy.Length; i++)
            {
                float _dist = Vector3.Distance(transform.position, enemy[i].transform.position);
                if (_dist < nearDist)
                {
                    nearDist = _dist;
                    nearEnemy = enemy[i];
                }
            }

            //시야 안에 들어왔을경우 가장 가까운 적을 타겟에 넣고, Move로 바꾸기
            if ((nearEnemy != null) && (Vector3.Distance(nearEnemy.transform.position, this.transform.position) < stat.ScanRange))
            {

                lockTarget = nearEnemy;
                State = Define.State.Move;
            }
        }

        //타겟이 있을경우
        else
        {
            //사거리 밖일경우 타겟 없애기
            if (Vector3.Distance(nearEnemy.transform.position, this.transform.position) > stat.ScanRange)
                lockTarget = null;
            else
                State = Define.State.Move;

        }

        //조이스틱 입력시 Move
        if (joystick.isInput == true)
        {
            lockTarget = null;
            State = Define.State.Move;
            return;
        }


        //TODO : Emeny가 인식거리안에 들어왔을때, 타겟의 위치를 몬스터로 정해서 이동
        //TODO : Emeny가 인식거리안에 없을때는 일정시간당 거리를 패트롤함

    }
    protected override void UpdateMove()
    {
        Vector3 dir = destPos - transform.position;
        if (joystick.isInput == true)
        {
            lockTarget = null;
            Destroy(this.GetComponent<NavMeshAgent>());
            MoveByJoystick();
        }


        //TODO : Emeny가 플레이어와의 거리가 사거리보다 짧다면 Skill로 바뀜
        //TODO : Emeny가 플레이어와의 거리가 사거리보다 멀면 Idle로 바뀜
        //현재는 조이스틱을 놓았을 경우, Idle로 돌아감
        //State = Define.State.Idle;
        else
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
            else
            {
                enemy = GameObject.FindGameObjectsWithTag("Enemy");
                float nearDist = Mathf.Infinity;

                for (int i = 0; i < enemy.Length; i++)
                {
                    float _dist = Vector3.Distance(transform.position, enemy[i].transform.position);
                    if (_dist < nearDist)
                    {
                        nearDist = _dist;
                        nearEnemy = enemy[i];
                    }
                }

                lockTarget = nearEnemy;
            }

            //TODO destPos 받아오기
           
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
        }
    }



    protected override void UpdateAttack()
    {
        if (joystick.isInput == true)
        {
            lockTarget = null;
            State = Define.State.Move;
        }

        else
        {
            if (lockTarget != null)
            {
                Vector3 dir = lockTarget.transform.position - transform.position;
                Quaternion quat = Quaternion.LookRotation(dir);
                transform.rotation = Quaternion.Lerp(transform.rotation, quat, stat.MoveSpeed * Time.deltaTime);

                if (Vector3.Distance(lockTarget.transform.position, transform.position) > stat.AtkRange )
                {
                    State = Define.State.Move;
                }
            }
        }
        
    }

    protected override void UpdateSkill()
    {
        //TODO : Emeny가 죽었으면 타겟 재설정, 타겟이 없다면 Idle로 변경
        //TODO : 조이스틱 패드를 만졌을 경우 타겟 재설성

    }

    protected override void UpdatePatrol()
    {
        //TODO : 일정시간 IDLE을 한 후 랜덤위치로 이동을 함. 목적지에 도착하면 다시 Idle
        if (joystick.isInput == true)
        {
            lockTarget = null;
            State = Define.State.Move;
        }
    }



    protected override void UpdateDie()
    {

    }






    /// <summary>
    /// 조이스틱을 이용해 이동
    /// </summary>
    private void MoveByJoystick()
    {
        //이동
        Vector3 dir = joystick.inputDir;

        Vector3 upMovement = Vector3.forward * stat.MoveSpeed * Time.deltaTime * dir.normalized.y;
        Vector3 rightMovement = Vector3.right * stat.MoveSpeed * Time.deltaTime * dir.normalized.x;

        transform.position += upMovement;
        transform.position += rightMovement;


        //회전
        Vector3 quatDir = new Vector3(dir.x, 0, dir.y);
        Quaternion quat = Quaternion.LookRotation(quatDir);

        transform.rotation = Quaternion.Lerp(transform.rotation, quat, 10 * Time.deltaTime);
    }


    void findTarget()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, 10.0f);
    }
}