using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    static ScoreUI instance;

    public static ScoreUI Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.Find("@ScoreManager").GetComponent<ScoreUI>();
                
            }
            return instance;
        }
    }


    
    public Text currentScore_T;
    public Text bestScore_T;

    private int currentScore;

    /// <summary>
    /// 프로퍼티를 이용한 get, set 구현
    /// </summary>
    public int CurrentScore
    {
        get => currentScore;

        set
        {
            currentScore = value;
            if (bestScore < currentScore)
            {
                bestScore = currentScore;
                PlayerPrefs.SetInt("Best Score", bestScore);
            }
            currentScore_T.text = string.Format("Score : {0}", currentScore);
            bestScore_T.text = string.Format("Best Score : {0}", bestScore);
        }        
    }
    private int bestScore;



    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }        
    }
    // Start is called before the first frame update
    void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score",0);
        bestScore_T.text = string.Format("Best Score : {0}",bestScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Get, Set 을 사용한 메소드 
    /// </summary>
    /// <param name="value"></param>
    /*
    public void SetScore(int value)
    {
        currentScore = value;
        if (bestScore < currentScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("Best Score", bestScore);
        }
        currentScore_T.text = string.Format("Score : {0}", currentScore);
        bestScore_T.text = string.Format("Best Score : {0}",bestScore);
    }

    public int GetScore()
    {
        return currentScore;
    }
    */
}
