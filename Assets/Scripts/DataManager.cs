using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [System.Serializable]
    public struct ScoreRecord
    {
        public string playerName;
        public int score;
    }

    public ScoreRecord topScore;
    public string playerName;

    public static DataManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        Load();
    }

    [System.Serializable]
    public class SaveData
    {
        public string playerName;
        public ScoreRecord topScore;
    }

    public void Save()
    {
        SaveData dataToSave = new SaveData();
        dataToSave.playerName = playerName;
        dataToSave.topScore = topScore;
        string json = JsonUtility.ToJson(dataToSave);
        File.WriteAllText(GetSaveFilePath(), json);
    }

    public void Load()
    {
        if (File.Exists(GetSaveFilePath()))
        {
            string json = File.ReadAllText(GetSaveFilePath());
            SaveData loadedData = JsonUtility.FromJson<SaveData>(json);
            playerName = loadedData.playerName;
            topScore = loadedData.topScore;
        }
    }

    private static string GetSaveFilePath()
    {
        return Path.Combine(Application.persistentDataPath, "save.json");
    }
}
