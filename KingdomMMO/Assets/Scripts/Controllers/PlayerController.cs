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

public class PlayerController : MonoBehaviour
{
    private UI_Joystick joystick;
    private PlayerStatus stat;

    void Awake()
    {
        joystick = FindObjectOfType<UI_Joystick>();
        stat = Util.GetOrAddComponent<PlayerStatus>(gameObject);
    }

    void Update()
    {
        if (joystick.isInput == true)
        {
            MoveByJoystick();
        }
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