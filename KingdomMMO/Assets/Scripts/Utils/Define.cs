using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum ItemType            // 아이템의 속성 설정에 대한 갯수
    {
        None,
        Weapon,                    
        Amore,                     
        Accessory,                 
        Material,                  
        Useable,                   
        Blueprint,                 
        Goods,                     
        Charm,                     
        QuestItem,
        Shield,
        Cloak,
        Shoes,
        Helmet,

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
