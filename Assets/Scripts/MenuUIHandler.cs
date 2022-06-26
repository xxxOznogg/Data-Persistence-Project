using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif
[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI PlayerName;

    public void NewPlayerName(string PlayerName)
    {
        MainManager.Instance.PlayerName = PlayerName;
    }
 

    void Start()
    {
        
    }


    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit(){
        
    

        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();

        #else
            Application.Quit();

        #endif
    }
}
