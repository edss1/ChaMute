using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject goal; // 이동 목표 오브젝트
    public float moveSpeed; // 캐릭터의 이동 속도

    public enum CharacterState // 캐릭터 상태는
    {
        MOVE, // 이동 상태를 가짐
        STAY, // 대기 상태를 가짐
    }
    public CharacterState characterState = CharacterState.MOVE; // 첫 상태는 이동 상태
    private void OnTriggerStay(Collision other)
    {
        if (other.gameObject == goal) // 골의 콜라이더와 충돌시에는
            characterState = CharacterState.STAY; // 캐릭터를 대기 상태로 바꾼다.
        else // 그렇지 않은 경우에는
            characterState = CharacterState.MOVE; // 캐릭터를 이동 상태로 바꾼다.
    }
    private void Update()
    {
        transform.Translate((goal.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime); // 캐릭터는 goal을 향해 moveSpeed 속도로 이동한다.
        if (characterState == CharacterState.MOVE) // 만약 캐릭터가 이동 상태면
            moveSpeed = 5; // 이동 속도는 5

        else // 그렇지 않으면 (else if(characterState == CharacterState.STAY) 도 상관 없습니다.)
            moveSpeed = 0; // 이동 속도는 0 즉 이동하지 말아라
    }
}
