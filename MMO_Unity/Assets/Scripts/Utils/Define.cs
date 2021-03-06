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
        Die,
        Idle,
        Move,
        Skill,
    }

    public enum Layer
    {
        Monster = 8,
        Ground = 9,
        Block = 10,
    }
    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }

    public enum UIEvent
    {
        Click,
        Drag,
        EndDrag,
        PointerDown,
        PointerUp
    }

    public enum MouseEvent
    {
        Press,
        PointerDown,
        PointUp,
        Click,
    }

    public enum CameraMode
    {
        QuaterView,
    }

}
