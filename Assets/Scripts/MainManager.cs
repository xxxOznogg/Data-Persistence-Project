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
    //public ScoreList highScores

    private void Awake(){
        //create a singleton MainManager

        if(Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

  


    // Start is called before the first frame update
    void Start()
    {
        
    }

           
   

    private void Update()
    {
       
    }


    
}
