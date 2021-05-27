using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataSaveLoad : MonoBehaviour
{
    public PlayerData playerData;


    [ContextMenu("To Json Data")]
    void SavePlayerDataToJson()
    {
        string jsonData = JsonUtility.ToJson(playerData, true);
        string filePath = Path.Combine(Application.dataPath, "playerData.json");
        File.WriteAllText(filePath, jsonData);
    }

    [ContextMenu("From Json Data")]
    void LoadPlayerDataToJson()
    {
        string filePath = Path.Combine(Application.dataPath, "playerData.json");
        string jsonData = File.ReadAllText(filePath);
        JsonUtility.FromJson<PlayerData>(jsonData);

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
