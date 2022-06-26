using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainManager : MonoBehaviour
{
    
    public static MainManager Instance;
    public string PlayerName;
    public int TopScore;
    //public ScoreList highScores

    private void Awake(){
        //create a singleton MainManager

        if(Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadTopScore();
    }

  
    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int TopScore;
    }

    public void SaveTopScore()
    {
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;
        data.TopScore = BoardManager.Instance.m_Points;

        string json = JsonUtility.ToJson(data);
        
        Debug.Log(Application.persistentDataPath);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
       
    }

    public void LoadTopScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.PlayerName;
            TopScore = data.TopScore;
            
        }
    }


    
}
