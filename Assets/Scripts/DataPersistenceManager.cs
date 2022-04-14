using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager instance;

    public string playerName;
    public string tempPlayerName;
    public int hiScore;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {        
        
    }     

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int hiScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.hiScore = hiScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            hiScore = data.hiScore;
        }
    }




}
