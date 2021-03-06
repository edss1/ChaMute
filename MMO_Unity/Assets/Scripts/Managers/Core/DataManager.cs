using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ILoader<Key,Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{

    //데이터를 늘린다면 이줄이랑
    public Dictionary<int, Data.Stat> StatDict { get; private set; } = new Dictionary<int, Data.Stat>();

    public void Init()
    {
        //이것 추가
        StatDict = LoadJson<Data.StatData, int, Data.Stat>("StatData").MakeDict();
    }




    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key,Value>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");
        return  JsonUtility.FromJson<Loader>(textAsset.text);
        
    }
}
