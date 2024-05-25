using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    //Una funcion que se encargue de guardar la informacion del jugador en un JSON
    public static void SaveData(int score, string playerName)
    {
        PersistantData data = new PersistantData(score, playerName);
        string path = Application.persistentDataPath + "/savefile.json";

        if (System.IO.File.Exists(path))
        {
            List<PersistantData> list = LoadData();
            list.Add(data);
            string json = JsonUtility.ToJson(list);
            System.IO.File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        }
        else
        {
            List<PersistantData> list = new List<PersistantData>();
            list.Add(data);
            string json = JsonUtility.ToJson(list);
            System.IO.File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }

    //Una funcion que recupere la informacion del JSON
    public static List<PersistantData> LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            List<PersistantData> data = JsonUtility.FromJson<List<PersistantData>>(json);
            return data;
        }
        else
        {
            return null;
        }
    }
}

public class PersistantData
{
    public int score = 0;
    public string playerName;

    public PersistantData(int score, string playerName)
    {
        this.score = score;
        this.playerName = playerName;
    }
}
