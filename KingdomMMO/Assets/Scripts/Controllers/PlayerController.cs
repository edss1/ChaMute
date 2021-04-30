//PlayerController 스크립트
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

public class PlayerController : BaseController
{
    private UI_Joystick joystick;
    private PlayerStatus stat;

    public override void Init()
    {
        joystick = FindObjectOfType<UI_Joystick>();
        stat = Util.GetOrAddComponent<PlayerStatus>(gameObject);
    }

    protected override void UpdateIdle()
    {



        //조이스틱 입력시 Move
        if (joystick.isInput == true)
            State = Define.State.Move;

        //TODO : Emeny가 인식거리안에 들어왔을때, 타겟의 위치를 몬스터로 정해서 이동
        //TODO : Emeny가 인식거리안에 없을때는 일정시간당 거리를 패트롤함

    }
    protected override void UpdateMove()
    {
        if (joystick.isInput == true)
        {
            MoveByJoystick();
        }

        else
        {
            //TODO : Emeny가 플레이어와의 거리가 사거리보다 짧다면 Skill로 바뀜
            //TODO : Emeny가 플레이어와의 거리가 사거리보다 멀면 Idle로 바뀜
            //현재는 조이스틱을 놓았을 경우, Idle로 돌아감
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
}