using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    public delegate void BirdDelegate(); //A Delegate allows us to treat method as a variable and pass method as a variable for a callback. When it get called , it notifies all methods that reference the delegate.
    public static event BirdDelegate BirdDied;// creating a public event bird died
    public static event BirdDelegate BirdScored; // creating a public event bird scored
    public static event BirdDelegate SlowDownSpeedOfBalls;
    public static event BirdDelegate SpeedUpSpeedOfBalls;
    public static event BirdDelegate RapidBallTimer;
    public static event BirdDelegate StarTimer;
    public static event BirdDelegate StopTimer;
    public static event BirdDelegate ShowNormalAd;
    public Text NumStars;
    private bool StarBeingUsed = false;
    private bool RapidBallUsed = false;
    private string birdCurrentColour;
    private float tapForce = 185;
    private float tilt = 1.5f;
    private Vector3 startPos;
    private bool invincible = false;
    private bool changerapidly = false;
    private Rigidbody2D rigidbody;
    private Quaternion downRotation;
    private Quaternion forwardRotation;
    private static Bird instance;
    public AudioSource BirdJumpSound;
    public AudioSource BirdScoredSound;
    public AudioSource BirdDiedSound;
    public AudioSource BirdInvincibleSound;
    private int deaths = 0;// use for ads
    private int Stars=0;
    public int GetBirdStars()
    {
        return Stars;
    }
    
    float timer = 0.0f;
   //ublic GameObject button;
    public static Bird GetBirdInstance() // getting the bird instance tso it can be accesed by other scripts
    {
        return instance;
    }
    private void OnEnable() // subscribing to the events game started and game restarted
    {
        GameEventHandler.GameStarted += GameStarted;
        GameEventHandler.GameReStarted += GameReStarted;
        AddManager.RewardPlayer += RewardPlayer;
        Score.RewardAStar += RewardAStar;

    }

   private void OnDisable()// unsubscribing  to the events 
    {
        GameEventHandler.GameStarted -= GameStarted;
        GameEventHandler.GameReStarted -= GameReStarted;
        AddManager.RewardPlayer -= RewardPlayer;
        Score.RewardAStar -= RewardAStar;
    }


    private void GameStarted()// when the event game started takes place this make the bird unable to move 
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.simulated = true;
    }

   private void GameReStarted()// when the event game restarted takes place this calls the function toset the bird back to its starting position and calls a function to set the birds colour
    {
        SetBirdPos();
       // NumStars.text = "0";
        //Stars = 0;
        transform.rotation = Quaternion.identity;
        SetBirdColour();
    }
   private void Awake() // intiating the instance of the bird
   {
       instance = this;
       timer = 0.0f;
   }


    private void Start() // this function calls the function to set the birds position. it also sets the boolean change rapidly and invincible to false, it gets a reference to the rigid body component in the inspector
   {
       deaths = 0;
       Stars = 0;
       NumStars.text= "0";
        SetBirdPos();
        invincible = false;
        changerapidly = false;
        SetBirdColour();
        rigidbody = GetComponent<Rigidbody2D>();
        downRotation = Quaternion.Euler(0, 0, -90); //x,y,z
        forwardRotation = Quaternion.Euler(0, 0, 35);//x,y,z coordinates
        rigidbody.simulated = false;
    }
    private void SetBirdPos()// the function that sets the birds starting position
    {
        startPos = new Vector3(-1.5f, -1, 0);
        transform.position = startPos;

    }

   public void DeployStar()
    {


        if (Stars >= 1  && GameEventHandler.GetGameEventHandlerInstance().GetGameover()==false && StarBeingUsed ==false)
        {
           // NumStars.text = Stars.ToString(); 
            invincible = true;
            BirdInvincibleSound.Play();
            //StartCoroutine(ShowAndHide(col.gameObject, 0));
          //  invincible = true;
            StartCoroutine(Invincibility(gameObject, 0)); // starts the birds couroutine for invinciblity
            StarTimer();
            ReduceStar();
          
        }
   }

       void ReduceStar()
   {
       if (Stars != 0)
       {   
           Stars = Stars - 1;
           NumStars.text = Stars.ToString();
           Debug.Log(Stars);
       }
       }
       void RewardPlayer()
       {
           if (Stars != 5)
           {
               Stars = Stars + 1;
               NumStars.text = Stars.ToString();
           }
       }
       void RewardAStar()
       {
           if (Stars != 5)
           {
               Stars = Stars + 1;
               NumStars.text = Stars.ToString();
           }

       }
       
    
    private void SetBirdColour()// this function sets the birds colour using switch case statements(could have used if statements). it also accesses the sprite renderer of the bird in the inspector so it can change the colour of the bird
    {
     
        int colour = Random.Range(0, 6);
        //Debug.Log(birdCurrentColour);
        var BirdRenderer = gameObject.GetComponent<SpriteRenderer>();
        switch (colour)
        {
            case 0:

                if (birdCurrentColour != "Red")
                {
                    birdCurrentColour = "Red";
                    BirdRenderer.material.SetColor("_Color", Color.red);
                    break;

                }
                else
                {
                    birdCurrentColour = "Blue";
                    BirdRenderer.material.SetColor("_Color", Color.blue);
                    break;
                }
            case 1:
                if (birdCurrentColour != "Blue")
                {
                    birdCurrentColour = "Blue";
                    BirdRenderer.material.SetColor("_Color", Color.blue);
                    break;
                }

                else
                {
                    birdCurrentColour = "Cyan";
                    BirdRenderer.material.SetColor("_Color", Color.cyan);
                    break;
                }
            
            case 2:
                if (birdCurrentColour != "Cyan")
                {
                    birdCurrentColour = "Cyan";
                    BirdRenderer.material.SetColor("_Color", Color.cyan);
                    break;
                }
                else
                {
                    birdCurrentColour = "Pink";
                    BirdRenderer.material.SetColor("_Color", Color.magenta);
                    break;
                }
            case 3:
                if (birdCurrentColour != "Pink")
                {
                    birdCurrentColour = "Pink";
                    BirdRenderer.material.SetColor("_Color", Color.magenta);
                    break;
                }
                else
                {
                    birdCurrentColour = "Yellow";
                    BirdRenderer.material.SetColor("_Color", Color.yellow);
                    break;  
                }

            case 4:
                if (birdCurrentColour != "Yellow")
                {
                    birdCurrentColour = "Yellow";
                    BirdRenderer.material.SetColor("_Color", Color.yellow);
                    break;
                }
                else
                {
                    birdCurrentColour = "Green";
                    BirdRenderer.material.SetColor("_Color", Color.green);
                    break; 
                }
            case 5:
                if (birdCurrentColour != "Green")
                {
                    birdCurrentColour = "Green";
                    BirdRenderer.material.SetColor("_Color", Color.green);
                    break;
                }
                else
                {
                    birdCurrentColour = "Red";
                    BirdRenderer.material.SetColor("_Color", Color.red);
                    break;

                }

        }
    }


    private void Update()// happens every frame . checks if game over is false, if it is it checks if the mouse has been clicked. if the mousse has been clicked it will call the function "bird jump". then it makes the bird tilt forward
    {
        
        
        if (GameEventHandler.GetGameEventHandlerInstance().GetGameover()) return;
        
            if (Input.GetMouseButtonDown(0))//0 means lift click. right will indicate right click. corrosponds to phones
            {
                BirdJump();

            }
            if ((GameEventHandler.GetGameEventHandlerInstance().GetGameover() == false))
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tilt * Time.deltaTime);// trans.rot is a quaternion. lerp means going from source value to target value over a certain amount of time
            }
        
    }

    private void BirdJump()// this function causes the bird to jump up
    {
        BirdJumpSound.Play();
        transform.rotation = forwardRotation;
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(Vector2.up * tapForce, ForceMode2D.Force);


    }

    private void OnTriggerStay2D(Collider2D col)// this happens when a GameObject collides with another GameObject. if statements are used to check if when collisions occur the right decisions are taken. it usese the game objects tags to make these desicions
    {
        if (col.gameObject.tag != birdCurrentColour && ((col.gameObject.tag != "backround" && col.gameObject.tag != "Invincible" && invincible == false && col.gameObject.tag != "Multicolour" && col.gameObject.tag != "RapidColourChange" && col.gameObject.tag != "SlowDown" && col.gameObject.tag != "SpeedUp" && col.gameObject.tag != "DeadZone")))
        {
            rigidbody.simulated = false;
            invincible = false;
            changerapidly = false;
            BirdDied();// the event bird died
            BirdDiedSound.Play();
            deaths = deaths + 1;
             if (deaths == 5)
             {
                 Debug.Log("show add");
                 ShowNormalAd();
                 deaths = 0;
             }
        }


        if ((col.gameObject.tag != birdCurrentColour || col.gameObject.tag == birdCurrentColour) && invincible == true && col.gameObject.tag != "backround" && col.gameObject.tag != "DeadZone" && col.gameObject.tag != "Invincible")
        {
            StartCoroutine(ShowAndHide(col.gameObject, 0)); // calls the courrountine showand hide for the ball
            BirdScoredSound.Play();
            BirdScored(); // the event bird scored 
            BirdScored();

        }

        if (col.gameObject.tag == birdCurrentColour && invincible == false)
        {

            StartCoroutine(ShowAndHide(col.gameObject, 0));
            BirdScored();
            BirdScoredSound.Play();
        }

      
        if (col.gameObject.tag == "Invincible" &&  StarBeingUsed ==false)
        {
            StartCoroutine(ShowAndHide(col.gameObject, 0));
            Debug.Log("in");
          
           changerapidly = false;
           BirdInvincibleSound.Play();
           invincible = true;
           StartCoroutine(Invincibility(gameObject, 0)); // starts the birds couroutine for invinciblity
           StarTimer();
            
           
            
        }

        if (col.gameObject.tag == "Invincible" && StarBeingUsed == true )
        {
           StartCoroutine(ShowAndHide(col.gameObject, 0));
            Debug.Log("no star");
           RewardPlayer();
           
            
        }
      

        
        if (col.gameObject.tag == "Multicolour")
        {
            StopTimer();
            BirdScoredSound.Play();
            invincible = false;
            changerapidly = false;
            StartCoroutine(ShowAndHide(col.gameObject, 0));
            SetBirdColour();


        }

        if (col.gameObject.tag == "RapidColourChange" )
        {
            StartCoroutine(ShowAndHide(col.gameObject, 0));
            BirdScoredSound.Play();
            invincible = false;
            changerapidly = true;
            
            StartCoroutine(ChangeRapidly(gameObject, 0));// starts the couroutine for the bird to change colour rapidly 
            RapidBallTimer();


        }
        //if (col.gameObject.tag == "RapidColourChange" && RapidBallUsed == true)
        //{
        //    StartCoroutine(ShowAndHide(col.gameObject, 0));
        //    RapidBallTimer();
        //    Debug.Log("activated");
            
        //}
        if (col.gameObject.tag == "DeadZone")// if the bird hits the sky or the groud as they have the tags deadzone
        {
            changerapidly = false;
            invincible = false;
            rigidbody.simulated = false;// freezes bird where he hit
            BirdDied();// the event bird died
            BirdDiedSound.Play();
            deaths = deaths + 1;
            if (deaths == 5)
            {
                Debug.Log("show add");
                ShowNormalAd();
                deaths = 0;
            }
        }



        if (col.gameObject.tag == "SlowDown")// if the bird hits the ball it slows down the speed of the balls
        {
            BirdScoredSound.Play();
            SlowDownSpeedOfBalls();
            StartCoroutine(ShowAndHide(col.gameObject, 0));

        }
        if (col.gameObject.tag == "SpeedUp")// if the bird hits the ball it slows down the speed of the balls
        {
            BirdScoredSound.Play();
            SpeedUpSpeedOfBalls();
            StartCoroutine(ShowAndHide(col.gameObject, 0));

        }
    }

   

 
   

    //The yield return statement is special; it is what actually tells Unity to pause the script and continue on the next frame. 
    //IEnumerator is an interface, which when implemented allows you to iterate through the list of controls.  look at book 
        private  IEnumerator Invincibility(GameObject gt, float delay)
    {
       
            // changes the birds colour very quickly
            for (int i = 0; i < 600; i++)
            {
                

                if (invincible == true && GameEventHandler.GetGameEventHandlerInstance().GetGameover() == false)
                {

                    //StarBeingUsed = true;
                    SetBirdColour();
                   
                    yield return new WaitForSeconds(0.0002f);
                    StarBeingUsed = true;
                }
            }
           
            
            invincible=false;
            StarBeingUsed = false;
 
            Debug.Log("NotINVIN");
            
            
        }

         private IEnumerator ShowAndHide(GameObject go, float delay)
         { // hides the ball after the bird touched it
             go.SetActive(false);
             yield return new WaitForSeconds(2f);
             if (GameEventHandler.GetGameEventHandlerInstance().GetGameover() == false)
             {
                 go.SetActive(true);
             }
         }

         private IEnumerator ChangeRapidly(GameObject g, float delay)
         {
        // theo's idea for bird to change every few seconds
           for (int i = 0; i < 6; i++)
             
                 {
                if (GameEventHandler.GetGameEventHandlerInstance().GetGameover() == false && changerapidly==true)
                {
                   
                     SetBirdColour();
                     //RapidBallUsed = true;
                    yield return new WaitForSeconds(3f);
                    
                 }
             }
           changerapidly = false;

           Debug.Log("Done changing colour");
         }

    }
    
   