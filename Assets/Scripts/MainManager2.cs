using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class MainManager2 : MonoBehaviour
{
    public static MainManager2 Instance;
    public TextMeshProUGUI playerName;


    private void Awake()
    {

        playerName.text = "toto";
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    [System.Serializable]
    class SaveData
    {
        public string playerName;
    }
    public void SavePlayerInfo()
    {
        SaveData data = new SaveData();
        data.playerName = playerName.text;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }
    public void LoadPlayerInfo()
    {

        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName.text = data.playerName;
        }

    }
}
