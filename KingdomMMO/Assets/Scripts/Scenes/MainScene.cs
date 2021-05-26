using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : BaseScene
{
    Button StartBtn;

    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Main;

        
    }

    public override void Clear()
    {

    }

    public void LoadGameScene()
    {
        Managers.Scene.LoadScene(Define.Scene.Game);
        Managers.Data.Load();
    }
}
