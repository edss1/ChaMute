using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataSaveLoad : MonoBehaviour
{
    PlayerStatus stat;
    public PlayerData playerData = new PlayerData();

    private void Start()
    {
        stat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
    }


    [ContextMenu("To Json Data")]
    public void SavePlayerDataToJson()
    {
        playerData.level = stat.Level;
        playerData.maxHp = stat.MaxHp;
        playerData.attack = stat.Attack;
        playerData.totalExp = stat.Exp;


        string jsonData = JsonUtility.ToJson(playerData, true);
        string filePath = Path.Combine(Application.dataPath, "playerData.json");
        File.WriteAllText(filePath, jsonData);
    }

    [ContextMenu("From Json Data")]
    public void LoadPlayerDataToJson()
    {

        string filePath = Path.Combine(Application.dataPath, "playerData.json");
        string jsonData = File.ReadAllText(filePath);
        playerData = JsonUtility.FromJson<PlayerData>(jsonData);

        stat.Level = playerData.level;
        stat.MaxHp = playerData.maxHp;
        stat.Attack = playerData.attack;
        stat.Exp = playerData.totalExp;
    }
}


[System.Serializable]
public class PlayerData
{
    public int level;
    public int maxHp;
    public int attack;
    public int totalExp;
}
