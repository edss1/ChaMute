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
    public Dictionary<int, Data.Amore> AmoreDict { get; private set; } = new Dictionary<int, Data.Amore>();
    public Dictionary<int, Data.Accessory> AccessoryDict { get; private set; } = new Dictionary<int, Data.Accessory>();
    public Dictionary<int, Data.Material> MaterialDict { get; private set; } = new Dictionary<int, Data.Material>();
    public Dictionary<int, Data.Useable> UseableDict { get; private set; } = new Dictionary<int, Data.Useable>();
    public Dictionary<int, Data.Blueprint> BlueprintDict { get; private set; } = new Dictionary<int, Data.Blueprint>();
    public Dictionary<int, Data.Charm> CharmDict { get; private set; } = new Dictionary<int, Data.Charm>();
   
    public void Init()
    {
        //이것 추가
        StatDict = LoadJson<Data.StatData, int, Data.Stat>("StatData").MakeDict();
        WeaponDict = LoadJson<Data.WeaponData, int, Data.Weapon>("WeaponData").MakeDict();
        AmoreDict = LoadJson<Data.AmoreData, int, Data.Amore>("AmoreData").MakeDict();
        AccessoryDict = LoadJson<Data.AccessoryData, int, Data.Accessory>("AccessoryData").MakeDict();
        MaterialDict = LoadJson<Data.MaterialData, int, Data.Material>("MaterialData").MakeDict();
        UseableDict = LoadJson<Data.UseableData, int, Data.Useable>("UseableData").MakeDict();
        BlueprintDict = LoadJson<Data.BlueprintData, int, Data.Blueprint>("BlueprintData").MakeDict();
        CharmDict = LoadJson<Data.CharmData, int, Data.Charm>("CharmData").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key,Value>
    {
        TextAsset textAsset = Resources.Load<TextAsset>($"Data/{path}");
        return  JsonUtility.FromJson<Loader>(textAsset.text);
    }

}
