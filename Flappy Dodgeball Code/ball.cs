
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;// makes sure no compiler errors


public class ball : MonoBehaviour
{
    [System.Serializable]// when C# serializes an object, it saves the complete state of the ebject only valid on enums, classes and structs
    public struct YSpawnRange// A struct is a value type.Value types hold their value in memory where they are declared Yspawnrange is the spawnrange for the y since the x range is set
    {
        public float min;
        public float max;

    }
    private static ball instance;
    public static ball GetBallInstance() { return instance; }// public getter for the ball instance so other scripts can access it if neccissary 
    public GameObject g;
    public int poolSize;
    public float shiftSpeed;
    public float spawnRate;
    public YSpawnRange ySpawnRange;
    public Vector3 defaultSpawnPos;
    private bool spawnImmediate;// boolean for spawning the object imediatly
    private Vector3 immediateSpawnPos;
    public Vector2 targetAspectRatio;
    private float spawnTimer;
    private float targetAspect;//10/16
    private PoolBall[] poolBalls;// creating a list
    
    
    private void Awake()
    
    {
       
        Configure();
        //shiftSpeed = 7f;
        instance = this; // creating the instance
       
    }


   private void OnEnable() //subscribing to the event GameRestarted 
    {
        GameEventHandler.GameReStarted += GameReStarted;
        Bird.SlowDownSpeedOfBalls += SlowDownSpeedOfBalls;
        Bird.SpeedUpSpeedOfBalls += SpeedUpSpeedOfBalls;
        GameEventHandler.GameStarted -= GameStarted;
    }

   private void OnDisable() //unsubscribing to the event GameRestarted 
    {
        GameEventHandler.GameReStarted -= GameReStarted;
        Bird.SlowDownSpeedOfBalls -= SlowDownSpeedOfBalls;
        Bird.SpeedUpSpeedOfBalls -= SpeedUpSpeedOfBalls;
        GameEventHandler.GameStarted -= GameStarted;
    }

   private void SpeedUpSpeedOfBalls()
   {
       if (shiftSpeed !=7)
       {
           shiftSpeed = shiftSpeed + 0.5f;
       }
   }
   private void SlowDownSpeedOfBalls()
   {
       if (shiftSpeed != 3)
       {
           shiftSpeed = shiftSpeed - 0.5f;
       }

   }

   private void GameStarted()
   {
       shiftSpeed = SetDefaultBallSpeed.GetBallSpeedInstance().GetBallSpeed();
     
   }

   private void Start()
   {
       shiftSpeed = SetDefaultBallSpeed.GetBallSpeedInstance().GetBallSpeed();
       
   }
   private void GameReStarted() // this function is called when the event GameRestarted is called. this function sets the boolean in use false of each object within the array (objects are no longer in use) and moves the objetcs off the screen. it also checks if objects need to spawned immediatly, if it does it will call the function spawn immediatly.
       
    {
        shiftSpeed = SetDefaultBallSpeed.GetBallSpeedInstance().GetBallSpeed();
        for (int i = 0; i < poolBalls.Length; i++)
        {
            poolBalls[i].SetinUseFalse();
            poolBalls[i].transform.position = Vector3.one * 100;
        }
        if (spawnImmediate)
        {
            SpawnImmediate();
        }

    }
    private void Update()// happens each frame. checks if Game over is false or true. If Gameover is false then it calls the function shift. if the spawn timer is greater than the spawn rate of the object it calls the function spawn and sets the timer back to 0
    {

       
        if (GameEventHandler.GetGameEventHandlerInstance().GetGameover())
        {
            return;
          
        }

            Shift();
          
            spawnTimer += Time.deltaTime;
            if (spawnTimer > spawnRate)
            {   
                Spawn();
                spawnTimer = 0;
              //  r.isKinematic = true;
            }

        }

    private void Configure()// creating the game objects (the balls) , checks if the balls need to be spawened immediatly 
    {
        targetAspect = targetAspectRatio.x / targetAspectRatio.y;
        poolBalls = new PoolBall[poolSize];
        for (int i = 0; i < poolBalls.Length; i++)
        {
            GameObject go = Instantiate(g) as GameObject;
           
            Transform t = go.transform;
            t.SetParent(transform);
            t.position = Vector3.one * 1000;
            
            poolBalls[i] = new PoolBall(t);
        }
        
        if (spawnImmediate)
        {
            SpawnImmediate();
        }
    }

    private void Spawn()// this function spawns the balls. the x position is a set value whereas the y position of the balls will vairy as the balls go up and down. the hieght of the ball is selected randomly within a range (the yspawnrange)
    {
        Transform t = GetPoolBall();
        if (t == null) return;
        Vector3 pos = Vector3.zero;
        
        pos.x = (defaultSpawnPos.x * Camera.main.aspect) / targetAspect;
        pos.y = Random.Range(ySpawnRange.min, ySpawnRange.max);
        t.position = pos;
    }

    private void SpawnImmediate()// the function that spawns the balls instantly when the game begins
    {
        Transform t = GetPoolBall();
        if (t == null) return;
        Vector3 pos = Vector3.zero;
        pos.x = (immediateSpawnPos.x * Camera.main.aspect) / targetAspect;
        pos.y = Random.Range(ySpawnRange.min, ySpawnRange.max);
        t.position = pos;
        Spawn();

    }

    private void Shift()// this function shifts the balls to the left then calls the Check dispose balls function
    {
        for (int i = 0; i < poolBalls.Length; i++)
        {
            poolBalls[i].transform.position += -Vector3.right * shiftSpeed * Time.deltaTime;//moving the position 
          
      
               
    
            CheckDisposeObject(poolBalls[i]);
            }
            
        }
    
        

    private void CheckDisposeObject(PoolBall poolBall)// this function checks if the balls x position is less than the negative default set position. if it is then it sets inuse false and moves the ball off the screen
    {
        if (poolBall.transform.position.x < (-defaultSpawnPos.x * Camera.main.aspect / targetAspect  ))
        {
            poolBall.SetinUseFalse(); 
            poolBall.transform.position = Vector3.one * 1000;

        }
    }

    private Transform GetPoolBall() // this function  checks if the balls are not in use. if they are needed it sets in use to true so that they can be spawned 
    {
        for (int i = 0; i < poolBalls.Length; i++)
        {
            if (!poolBalls[i].GetinUse())
            {
                poolBalls[i].SetinUseTrue();
                return poolBalls[i].transform;

            }

        }
        return null;

    }


 }

    


