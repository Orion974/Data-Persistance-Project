using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{

    public TextMeshProUGUI playerName3;

    private void Start()
    {
        MainManager2.Instance.LoadPlayerInfo();
    }

    public void StartNew()
    {

          
        Debug.Log("Valeur actuelle de playername" + MainManager2.Instance.GetPlayerName());
        Debug.Log("Valeur actuelle de playername" + playerName3.text);

        if (MainManager2.Instance.GetPlayerName() != playerName3.text)
        {
            Debug.Log("Je suis appliqué");
            MainManager2.Instance.playerBestScore = 0;
            MainManager2.Instance.SetPlayerName(playerName3.text);
            MainManager2.Instance.SavePlayerInfo();
        }
        else MainManager2.Instance.SavePlayerInfo();
        SceneManager.LoadScene(1);

    }

    public void Exit()
    {
        MainManager2.Instance.SavePlayerInfo();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif
    }


}
