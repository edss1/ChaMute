//CameraController 스크립트
/*
 * 작성일자 : 2021-05-03                                 
스크립트 설명 : 카메라 플레이어따라 이동하는 스크립트
스크립트 사용법 : 
                 
수정일자(1차) :                                       
수정내용(1차) :                                   
                                  
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 lookOffset = new Vector3(0, 8, -10);
    public Transform player;

    void Start()
    {
        
    }


    private void LateUpdate()
    {
        FollowPlayer();    
    }
    

    private void FollowPlayer()
    {
        transform.position = player.position + lookOffset;
        transform.LookAt(player);
        
    }
}
