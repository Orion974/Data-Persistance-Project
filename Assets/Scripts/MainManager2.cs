using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class MainManager2 : MonoBehaviour
{
    public static MainManager2 Instance;
    private string playerName;

    public int playerBestScore;

    private void Awake()
    {
        
        
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }
    public string GetPlayerName()
    {
        return playerName;
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int playerBestScore;
    }
    public void SavePlayerInfo()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.playerBestScore = playerBestScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
       // Debug.Log("Valeur sauvegardee de playername" + Instance.playerName.text);

    }
    public void LoadPlayerInfo()
    {

        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            playerBestScore = data.playerBestScore;
        }

    }
}
