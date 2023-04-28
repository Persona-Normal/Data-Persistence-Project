using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{

    public static DataPersistenceManager Instance { get; private set; }

    [SerializeField] string highScoreJsonFileName = "highscorefile";
    public string playerName;
    public HighScoreData highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScoreData();
    }

    [System.Serializable]
    public class HighScoreData 
    {
        public string playerName;
        public int score;
    }


    public void LoadHighScoreData()
    {
        string path = GetPath();

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            highScore = JsonUtility.FromJson<HighScoreData>(json);
        }
        else
        {
            highScore = new HighScoreData();
            highScore.playerName = "";
            highScore.score = 0;
        }
    }

    private string GetPath()
    {
        return Application.persistentDataPath + "/" + highScoreJsonFileName + ".json";
    }

    public void SaveHighScoreData()
    {
        string json = JsonUtility.ToJson(Instance.highScore);
        File.WriteAllText(GetPath(), json);
    }
}
