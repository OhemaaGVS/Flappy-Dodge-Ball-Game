using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public delegate void ScoreDelegate();// A Delegate allows us to treat method as a variable and pass method as a variable for a callback. When it get called , it notifies all methods that reference the delegate.
    public static event ScoreDelegate ChangeBackground;
    public static event ScoreDelegate SelectRandomNumber;
    public static event ScoreDelegate RewardAStar ;
    private int score = 0;
    private int highscore;
    public int GetHighScore()// a getter that returns score
    {
        return highscore;
    }
    public int GetScore()
    {
        return score;
    }
    private static Score instance;
    public static Score GetScoreInstance() // a getter that returns the instance
    {
        return instance;
    }
    private void OnEnable() //subscribing to the events
    {
        
        
        GameEventHandler.GameReStarted += GameReStarted;
    }

    private void OnDisable() //unsubscribing to the events
    {
        GameEventHandler.GameReStarted -= GameReStarted;
    }
    
    
    public void SetScore()// adds one to the score
    {
        score++;
        if (score % 25  ==0)
        {
            SelectRandomNumber();
            ChangeBackground();
        
        
        }
        
        if (score % 100 == 0)
        {
            RewardAStar();


        }
     
    }

    public void SetHighScore() // sets the high score. compares it to the current score. if the current score is greater then that becomes the new high score

    {
        int savedScore = PlayerPrefs.GetInt("MyHighScore");// player prefs Stores and accesses player preferences between game sessions.
        if (score > savedScore)
        {   
            PlayerPrefs.SetInt("MyHighScore", score);
           
            highscore = PlayerPrefs.GetInt("MyHighScore");
           // Debug.Log("the highscore is "+ highscore);
         CloudOnceServices.instance.SubmitMyScoreToLeaderboard(highscore);
        }
        else
        {
            highscore = PlayerPrefs.GetInt("MyHighScore");
        }
    }
    private void Awake()// intializes the instance and sets high score 
    {
        instance = this;
        highscore = PlayerPrefs.GetInt("MyHighScore");
    }

    private void Start()// sets score to 0
    {
        score = 0;
      
        
    }

    public void GameReStarted()// set score to 0 , and setting highscore
    {
        score = 0;

        highscore = PlayerPrefs.GetInt("MyHighScore");
    }

    public void SetScore0()// sets score to 0
    {
        score = 0;
    }
}  

