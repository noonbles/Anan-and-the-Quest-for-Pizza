using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class DataObject
{
    public int GameLevel;
    public bool IRSSpawn;
    public int Score;
}

public static class DataWriter
{
    public static void writeData(int gameLevel, bool irsSpawn, int score){
        
        DataObject data = new DataObject
        {
            GameLevel = gameLevel,
            IRSSpawn = irsSpawn,
            Score = score
        };

        string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);
        string filePath = Application.dataPath + "/data.json";

        File.WriteAllText(filePath, jsonString);

        Debug.Log("Data written to file: " + filePath);
    }

    private static DataObject readData(){
        string filePath = Application.dataPath + "/data.json";
        if(File.Exists(filePath)){
            string jsonString = File.ReadAllText(filePath);
            DataObject data = JsonConvert.DeserializeObject<DataObject>(jsonString);
            return data;
        }

        return new DataObject{
            GameLevel = 0,
            IRSSpawn = false,
            Score = 0
        };
    }

    public static int GetScore(){
        return readData().Score;
    }

    public static int GetLevel(){
        return readData().GameLevel;
    }
    
}
