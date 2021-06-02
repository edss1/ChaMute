//DataManager 스크립트
/*
 * 작성일자 : 2021-04-29                                 
스크립트 설명 : Data를 관리하는 매니저
스크립트 사용법 :
                 
수정일자(1차) : Save, Load 추가
수정내용(1차) :
                                  
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public interface ILoader<Key,Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
  

    //데이터를 늘린다면 이줄이랑
    public Dictionary<int, Data.Stat> StatDict { get; private set; } = new Dictionary<int, Data.Stat>();
    public Dictionary<int, Data.Weapon> WeaponDict { get; private set; } = new Dictionary<int, Data.Weapon>();
   //public Dictionary<int, Data.Item> ItemDict { get; private set; } = new Dictionary<int, Data.Item>();
   //public Dictionary<int, Data.Item> ItemDict { get; private set; } = new Dictionary<int, Data.Item>();
   //public Dictionary<int, Data.Item> ItemDict { get; private set; } = new Dictionary<int, Data.Item>();
   //public Dictionary<int, Data.Item> ItemDict { get; private set; } = new Dictionary<int, Data.Item>();
   //public Dictionary<int, Data.Item> ItemDict { get; private set; } = new Dictionary<int, Data.Item>();

    public void Init()
    {
        //이것 추가
        StatDict = LoadJson<Data.StatData, int, Data.Stat>("StatData").MakeDict();
        WeaponDict = LoadJson<Data.WeaponData, int, Data.Weapon>("WeaponData").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key,Value>
    {
        TextAsset textAsset = Resources.Load<TextAsset>($"Data/{path}");
        return  JsonUtility.FromJson<Loader>(textAsset.text);
    }

}
