using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum ItemType            // 아이템의 속성 설정에 대한 갯수
    {
        None,
        Weapon,                     // 무기류 (검, 방패, 창 등 해당)
        Amore,                      // 옷류   (상의, 하의, 모자 등 해당)
        Accessory,                  // 악세서리 (목걸이, 반지)
        Material,                   // 재료
        Useable,                    // 소모품
        Blueprint,                  // 설계도
        Goods,                      // 재화
        Charm,                      // 부적
        QuestItem,                  // 퀘스트 아이템류
    }

    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Main,
        Game,
    }

    public enum WorldObject
    {
        Unknown,
        Player,
        Monster,
    }

    public enum State
    {
        Idle,
        Move,
        Patrol,
        Attack,
        Return,
        Skill,
        Die
    }
}
