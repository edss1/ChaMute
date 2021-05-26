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
    public string GameDataFileName = "PlayerData.json";
    public Data.Stat _status;
    public Data.Stat status
    {
        get
        {
            if(_status == null)
            {
                Load();
                Save();
            }
            return _status;
        }
    }

    //데이터를 늘린다면 이줄이랑
    public Dictionary<int, Data.Stat> StatDict { get; private set; } = new Dictionary<int, Data.Stat>();

    public void Init()
    {
        //이것 추가
        StatDict = LoadJson<Data.StatData, int, Data.Stat>("StatData").MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key,Value>
    {
        TextAsset textAsset = Resources.Load<TextAsset>($"Data/{path}");
        return  JsonUtility.FromJson<Loader>(textAsset.text);
    }

    public void Load()
    {
        string filePath = Application.persistentDataPath + GameDataFileName;

        if(File.Exists(filePath))
        {
            Debug.Log("불러오기 완료");
            string FromJsonData = File.ReadAllText(filePath);
            _status = JsonUtility.FromJson<Data.Stat>(FromJsonData);
        }

        else
        {
            Debug.Log("새로운 파일 생성");
            _status = new Data.Stat();
        }
    }

    public void Save()

    {

       string ToJsonData = JsonUtility.ToJson(status);

        string filePath = Application.persistentDataPath + GameDataFileName;

        File.WriteAllText(filePath, ToJsonData);

        Debug.Log("저장 완료");

    }

    private void OnApplicationQuit()

    {

        Save();

    }
}
