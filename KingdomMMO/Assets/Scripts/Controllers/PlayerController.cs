//PlayerController 스크립트
/*
 * 작성일자 : 2021-04-29                                 
스크립트 설명 : 플레이어 제어하는 스크립트
스크립트 사용법 : 
                 
수정일자(1차) : 05-11
수정내용(1차) : enemy를 배열로 받아와서 가까운 적 찾기

수정일자(2차) : 05-18
수정내용(2차) : Idle일 경우, destPos 수정 및 rotation 수정
         
수정일자(3차) : 05-25
수정내용(3차) : 벽뚫기 안되도록 수정

수정일자(3차) : 05-31
수정내용(3차) : 공격속도를 애니메이션으로 적용시키기

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

    bool stopAttacked = false;

    BoxCollider boxCollider;
    LayerMask layerMask;

    float atkTime;

    public override void Init()
    {
        joystick = FindObjectOfType<UI_Joystick>();
        stat = gameObject.GetOrAddComponent<PlayerStatus>();
        boxCollider = GetComponent<BoxCollider>();
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
    }


    protected override void UpdateMove()
    {
        Vector3 dir = destPos - transform.position;
        if (joystick.isInput == true)
        {
            lockTarget = null;
            nearEnemy = null;
            Destroy(this.GetComponent<NavMeshAgent>());
            MoveByJoystick();
        }
        

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
                if ((nearEnemy != null) && (Vector3.Distance(nearEnemy.transform.position, this.transform.position) < stat.ScanRange))
                    lockTarget = nearEnemy;

                else
                {
                    destPos = transform.position;

                }
            }

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
                if (lockTarget != null)
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 100 * Time.deltaTime);
                else
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-dir), 100 * Time.deltaTime);
            }
        }
    }
    
    

    protected override void UpdateAttack()
    {
        //공격속도를 애니메이션으로 적용
        anim.SetFloat("AtkSpd",(stat.AtkSpd));
        atkTime += Time.deltaTime;

        if (joystick.isInput == true)
        {
            lockTarget = null;
            State = Define.State.Move;
        }


        else
        {
            
            if (lockTarget != null)
            {
                if (atkTime < (1 / stat.AtkSpd)*0.8)
                {

                    Vector3 dir = lockTarget.transform.position - transform.position;
                    Quaternion quat = Quaternion.LookRotation(dir);
                    transform.rotation = Quaternion.Lerp(transform.rotation, quat, stat.MoveSpeed * Time.deltaTime);

                    //TODO
                    if (Vector3.Distance(lockTarget.transform.position, transform.position) > stat.AtkRange)
                    {
                        State = Define.State.Move;
                    }
                }

                else
                {
                    OnHitEvent();
                    atkTime = 0;
                }
            }

            else
                State = Define.State.Idle;
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
        
        //회전
        Vector3 quatDir = new Vector3(dir.x, 0, dir.y);
        Quaternion quat = Quaternion.LookRotation(quatDir);

        transform.rotation = Quaternion.Lerp(transform.rotation, quat, 10 * Time.deltaTime);

        Debug.DrawRay(transform.position, quatDir.normalized, Color.green);
        if (!Physics.Raycast(transform.position + Vector3.up * 0.5f, quatDir, 1.5f, LayerMask.GetMask("Block")))
        {
            transform.position += upMovement;
            transform.position += rightMovement;
        }
    }

    /// <summary>
    /// 공격
    /// </summary>
    
    void OnHitEvent()
    {
        if (lockTarget != null)
        {
            EnemyStatus targetStat = lockTarget.GetComponent<EnemyStatus>();
            targetStat.OnAttacked(stat);
        }

        if (stopAttacked)
        {
            State = Define.State.Idle;
        }
        else
        {
            State = Define.State.Attack;
        }
    }
}