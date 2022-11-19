using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEventHandler : MonoBehaviour
{
    public delegate void GameDelegate();// A Delegate allows us to treat method as a variable and pass method as a variable for a callback. When it get called , it notifies all methods that reference the delegate.
    public static event GameDelegate GameStarted;// creating the events game started and game restarted
    public static event GameDelegate GameReStarted;
    public static event GameDelegate DefaultBackground;
    private static GameEventHandler instance;
    public static GameEventHandler GetGameEventHandlerInstance() { return instance; }//A reference to our game control script so we can access it statically.
    public Text scoreText;
    public Text currentText;
    public Text highscoreText;
    public GameObject startPage;
    public GameObject gameOverPage;
    public GameObject countdownPage;
    public GameObject mainMenuPage;
    public GameObject instructionsPage;
    private bool gameOver = true;
    public AudioSource MenuMusic; 
    public bool GetGameover()// getter for the bool game over
    {
        return gameOver;
    }

   private void OnEnable() // subscribing to events
    {
        CountdownText.CountdownFinished += CountdownFinished;// to subscribe say +=, to unsubscribe say -=
        Bird.BirdDied += BirdDied;// to subscribe say +=, to unsubscribe say -=
        Bird.BirdScored += BirdScored;
    }

   private void OnDisable() // unsubscribing to the events
    {
        CountdownText.CountdownFinished -= CountdownFinished;// to subscribe say +=, to unsubscribe say -=
        Bird.BirdDied -= BirdDied;// to subscribe say +=, to unsubscribe say -=
        Bird.BirdScored -= BirdScored;
    }


    private void BirdScored()// when the event bird scored happens this function calls a function within the score class to add one to the score and displays it on the score text UI element
    {
        //The bird can't score if the game is over.
        if (gameOver == true) return;
        Score.GetScoreInstance().SetScore();
        scoreText.text = Score.GetScoreInstance().GetScore().ToString();
       

    }

   private void BirdDied()// on this event this function sets the highscore through the score class amd sets the page state to game over 
    {
        Score.GetScoreInstance().SetHighScore();
        SetPageState(PageState.GameOver);
        gameOver = true;

    }


    private void Awake()// creates an instance of the game event handeler;
    {
            instance = this;
    }

    private enum PageState //Enumerations allow you to create a collection of related constants. In this video you will learn how to declare and use enumerations in your code.
    {
        None,
        Menu,
        Instructions,
        Start,
        GameOver,
        Countdown
    }


    private void SetPageState(PageState state)// a function that uses switch case statements to set other page states to false and true
    {
        switch (state)
        {
            case PageState.None:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                mainMenuPage.SetActive(false);
                instructionsPage.SetActive(false);
                break;
            case PageState.Start:
                startPage.SetActive(true);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                mainMenuPage.SetActive(false);
                instructionsPage.SetActive(false);
                break;
            case PageState.GameOver:
                startPage.SetActive(false);
                gameOverPage.SetActive(true);
                countdownPage.SetActive(false);
                mainMenuPage.SetActive(false);
                instructionsPage.SetActive(false);
                break;
            case PageState.Countdown:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(true);
                mainMenuPage.SetActive(false);
                instructionsPage.SetActive(false);
                break;
            case PageState.Menu:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                mainMenuPage.SetActive(true);
                instructionsPage.SetActive(false);
                break;
            case PageState.Instructions:
                startPage.SetActive(false);
                gameOverPage.SetActive(false);
                countdownPage.SetActive(false);
                mainMenuPage.SetActive(false);
                instructionsPage.SetActive(true);
                break;


        }

    }

    private void ReturnHome()
    {
       
        Score.GetScoreInstance().SetScore0();
       // GameReStarted(); before ads
        DefaultBackground();
        highscoreText.text = "Highscore: " + Score.GetScoreInstance().GetHighScore().ToString();
        scoreText.text = "0";
        SetPageState(PageState.Start); 
        GameReStarted();
        SetPageState(PageState.Menu);
        if (!MenuMusic.isPlaying)
        {
            MenuMusic.Play();
        }
        //GameReStarted();
    }

    private void DisplayInstructions()
    {
        SetPageState(PageState.Instructions);
        scoreText.text = "0";
       
    }

    private void ProceedToGame()
    {
        SetPageState(PageState.Start);
        MenuMusic.Stop();
    }

    private void Start()// sets the page state to start and displays the highscore 

    {
        highscoreText.text = "Highscore: " + Score.GetScoreInstance().GetHighScore().ToString();
        SetPageState(PageState.Menu);
        MenuMusic.Play();
    }

    private void StartGame()//activated when play button is hit. sets the pagestate to Countdown
    {   

        SetPageState(PageState.Countdown);
        MenuMusic.Stop();
    }


    public void CountdownFinished()// when the event countdown finished is called this sets game over to false, sets the page state to false and sets the score to 0. it also calls the event GameStarted
    {  
        gameOver = false;
        SetPageState(PageState.None);
        Score.GetScoreInstance().SetScore0();
        GameStarted();
    }



    private void RestartGame()// this is activated when the restart button is clicked. it : sets the score text to 0, calls the event Game restarted and displays the highscore text aswell as sets the page state to start
    {
       // GameReStarted(); original version before adds 
        DefaultBackground();
        highscoreText.text = "Highscore: " + Score.GetScoreInstance().GetHighScore().ToString();
        scoreText.text = "0";
        SetPageState(PageState.Start);
        GameReStarted();
    }


}

















