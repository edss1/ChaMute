using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : BaseController
{
    Stat _stat;

    [SerializeField]
    float _scanRange = 10;

    [SerializeField]
    float _attackRange = 2;


    public override void Init()
    {

        WorldObjectType = Define.WorldObject.Monster;
        _stat = gameObject.GetComponent<Stat>();

        if (gameObject.GetComponentInChildren<UI_HPBar>() == null)
            Managers.UI.MakeWorldSpaceUI<UI_HPBar>(transform);
    }

    protected override void UpdateIdle()
    {
        //TODO : 매니저가 생기면 옮기자
        GameObject player = Managers.Game.GetPlayer();
        if(player == null)
            return;


        float distance = (player.transform.position - transform.position).magnitude;
        if(distance <= _scanRange)
        {
            _lockTarget = player;
            State = Define.State.Move;
            return;
        }
    }

    protected override void UpdateMove()
    {

        if (_lockTarget != null)
        {
            _destPos = _lockTarget.transform.position;
            float distance = (_destPos - transform.position).magnitude;
            if (distance <= _attackRange)
            {
                NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
                nma.SetDestination(transform.position);
                State = Define.State.Skill;

                return;
            }
        }

        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.1f)
        {
            NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
            State = Define.State.Idle;
        }

        else
        {
            NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
            nma.SetDestination(_destPos);
            nma.speed = _stat.MoveSpeed;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 1000 * Time.deltaTime);
            
            //가속도
            nma.acceleration = 1000;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 15 * Time.deltaTime);

            
        }
    }

    protected override void UpdateSkill()
    {
        if (_lockTarget != null)
        {
            Vector3 dir = _lockTarget.transform.position - transform.position;
            Quaternion quat = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, quat, _stat.MoveSpeed * Time.deltaTime);
        }

    }

    void OnHitEvent()
    {
        if(_lockTarget != null)
        {
            Stat targetStat = _lockTarget.GetComponent<Stat>();
            targetStat.OnAttacked(_stat);

            if(targetStat.Hp > 0)
            {
                float distance = (_lockTarget.transform.position - transform.position).magnitude;
                if(distance <= _attackRange)
                    State = Define.State.Skill;
                else
                    State = Define.State.Move;
            }
            else
            {
                State = Define.State.Idle;
            }
        }
        else
        {
            State = Define.State.Idle;
        }
    }

}
