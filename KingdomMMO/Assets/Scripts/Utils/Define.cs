using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{

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
        Skill,
        Die
    }
}
