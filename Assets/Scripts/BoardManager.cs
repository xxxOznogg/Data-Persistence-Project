using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class BoardManager : MonoBehaviour
{

    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;
    public Text ScoreText;
    public Text TopScoreText;
    public GameObject GameOverText;
    public static BoardManager Instance;
    
    public bool m_Started = false;
    public int m_Points;
    public bool m_GameOver = false;

    

    private void Awake(){

        if(Instance == null){
            Instance = this;
            return;
        }
        
        DontDestroyOnLoad(gameObject);

    }


    void Start()
    {
        MainManager.Instance.LoadTopScore();
        TopScoreText.text = $"Player: {MainManager.Instance.PlayerName} Top Score : {MainManager.Instance.TopScore}";
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
                brick.transform.SetParent(Instance.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_Started)
        {
            AddPoint(0);
            if (Input.GetKeyDown(KeyCode.Space))
            {
    
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(Instance.transform);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Player: {MainManager.Instance.PlayerName}  Score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
        
        

        if((MainManager.Instance.TopScore < m_Points)||(MainManager.Instance.TopScore == 0))
        {
            MainManager.Instance.SaveTopScore();
            Debug.Log("New Top Score!!! Saving");
        }

        MainManager.Instance.LoadTopScore();
    }


  
}
