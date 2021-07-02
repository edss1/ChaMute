using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : BaseScene
{
    Button StartBtn;

    [SerializeField]
    GameObject inv;

    UI_Inventory inventory;

    [SerializeField]
    GameObject dataSaveLoadObject;
    DataSaveLoad data;
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Main;

        Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;

        data = dataSaveLoadObject.GetComponent<DataSaveLoad>();

    }

    public override void Clear()
    {

    }

    public void LoadGameScene()
    {
        Managers.Scene.LoadScene(Define.Scene.Game);
    }
}
