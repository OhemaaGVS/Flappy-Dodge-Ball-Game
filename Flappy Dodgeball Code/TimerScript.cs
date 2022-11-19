using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    
    public Image RapidBallTimebar;
    public Image StarTimebar;
    public bool CountDownForRapidBall = false;
    public bool CountDownForStar = false;
    float RapidBallTime;
    float StarTime;
    float RapidBallTimeAmt = 18;
    float StarTimeAmt = 10;
    // Start is called before the first frame update
    void Start()
    {
        CountDownForRapidBall = false;
        CountDownForStar = false;
        RapidBallTimebar = GameObject.Find("RapidBallTimer").GetComponent<Image>();
        RapidBallTimebar.enabled = false;
        StarTimebar = GameObject.Find("StarTimer").GetComponent<Image>();
        StarTimebar.enabled = false;
        RapidBallTime = RapidBallTimeAmt;
        StarTime = StarTimeAmt;
    }

    // Update is called once per frame
    void Update()
    {
        if (CountDownForRapidBall == true && RapidBallTime > 0)
        {
            
            RapidBallTimebar.enabled = true;
            RapidBallTime -= Time.deltaTime;
            RapidBallTimebar.fillAmount = RapidBallTime / RapidBallTimeAmt;
        }
        if (RapidBallTime < 0)
        {
            
            RapidBallTimebar.enabled = false;
            CountDownForRapidBall = false;

            RapidBallTimebar.fillAmount = 1;
            RapidBallTime = RapidBallTimeAmt;
        }

        if (CountDownForStar == true && StarTime > 0)
        {
            StarTimebar.enabled = true;
            StarTime -= Time.deltaTime;
            StarTimebar.fillAmount = StarTime / StarTimeAmt;
        }
        if (StarTime < 0)
        {
            
            StarTimebar.enabled = false;
            CountDownForStar = false;

            StarTimebar.fillAmount = 1;
            StarTime = StarTimeAmt;
        }
      
        
        if (GameEventHandler.GetGameEventHandlerInstance().GetGameover() ==true)
        {
            
            CountDownForRapidBall= false;
            CountDownForStar = false;
            
        }
    }

    void StarTimer()
    {
        CountDownForStar = true;
        
        RapidBallTimebar.enabled = false;
        CountDownForRapidBall = false;

        RapidBallTimebar.fillAmount = 1;
        RapidBallTime = RapidBallTimeAmt;
    }

    void RapidBallTimer()
    {
        CountDownForRapidBall = true;
        StarTimebar.enabled = false;
        CountDownForStar = false;

        StarTimebar.fillAmount = 1;
        StarTime = StarTimeAmt;
    }

    void OnEnable()
    {
        Bird.RapidBallTimer += RapidBallTimer;
        Bird.StarTimer += StarTimer;
        Bird.StopTimer += StopTimer;
        GameEventHandler.GameReStarted += GameReStarted;
    }

    void OnDisable()
    {
        Bird.RapidBallTimer -= RapidBallTimer;
        Bird.StarTimer -= StarTimer;
        Bird.StopTimer -= StopTimer;
        GameEventHandler.GameReStarted -= GameReStarted;
    }

    void GameReStarted()
    {
        RapidBallTimebar.enabled = false;
        RapidBallTimebar.fillAmount = 1;
        RapidBallTime = RapidBallTimeAmt;
        StarTimebar.enabled = false;
        StarTimebar.fillAmount = 1;
        StarTime = StarTimeAmt;
    }
    void StopTimer()
    {
        CountDownForRapidBall = false;
        CountDownForStar = false;
        RapidBallTimebar.enabled = false;
        RapidBallTimebar.fillAmount = 1;
        RapidBallTime = RapidBallTimeAmt;
        StarTimebar.enabled = false;
        StarTimebar.fillAmount = 1;
        StarTime = StarTimeAmt;
  
    }





    















}
