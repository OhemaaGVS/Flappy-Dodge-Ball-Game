using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backround : MonoBehaviour
{
    public delegate void BackGroundDelegate(); //A Delegate allows us to treat method as a variable and pass method as a variable for a callback. When it get called , it notifies all methods that reference the delegate.
    //public static event BackGroundDelegate SelectRandomNumber;
    private BoxCollider2D groundCollider; //This stores a reference to the collider attached to the Ground.
    private float groundHorizontalLength;  
    private Rigidbody2D rb2d;
    public Sprite DefaultBackRound;
    public Sprite BackGround1;
    public Sprite BackGround2;
    public Sprite BackGround3;
    public Sprite BackGround4;
    public Sprite BackGround5;
    public Sprite BackGround6;
    public Sprite BackGround7;
    public Sprite BackGround8;
    public AudioSource BackGround1Music;
    public AudioSource BackGround2Music;
    public AudioSource BackGround3Music;
    public AudioSource BackGround4Music;
    public AudioSource BackGround5Music;
    public AudioSource BackGround6Music;
    public AudioSource BackGround7Music;
    public AudioSource BackGround8Music;
    
    SpriteRenderer SR;

    private void OnEnable() // subscribing to the events game started and game restarted
    {
        Bird.BirdDied += BirdDied;
        GameEventHandler.GameStarted += GameStarted;
        Score.ChangeBackground += ChangeBackground;
        GameEventHandler.DefaultBackground += DefaultBackground;
    }

    private void OnDisable()// unsubscribing  to the events 
    {
        Bird.BirdDied -= BirdDied;
        GameEventHandler.GameStarted -= GameStarted;
        Score.ChangeBackground-= ChangeBackground;
        GameEventHandler.DefaultBackground -= DefaultBackground;
    }
    private void BirdDied()
    {
        MuteMusic();
    }
    private void MuteMusic()
    {
        BackGround1Music.Stop();
        BackGround2Music.Stop();
        BackGround3Music.Stop();
        BackGround4Music.Stop();
        BackGround5Music.Stop();
        BackGround6Music.Stop();
        BackGround7Music.Stop();
        BackGround8Music.Stop();
        
    }
    private void DefaultBackground()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = DefaultBackRound;
      
    }
    private void GameStarted()
    {
        BackGround1Music.Play();
    }

    private void ChangeBackground()
    {
        StartCoroutine("FadeOut");
        //SelectRandomNumber();
        int background = RandomNumberGenerator.GetRandomNumberGeneratorInstance().Getnumber();
        string currentBackGround = gameObject.GetComponent<SpriteRenderer>().sprite.name;
        switch (background)
        {
            case 0:
                if (currentBackGround != "BlueSky")
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = BackGround1;
                    MuteMusic();
                    BackGround1Music.Play();
                    break;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = BackGround2;
                   MuteMusic();
                    BackGround2Music.Play();
                    break;
                }
               

            case 1:
                if (currentBackGround != "canyon")
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = BackGround2;
                    MuteMusic();
                    BackGround2Music.Play();
                    break;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = BackGround3;
                    MuteMusic();
                    BackGround3Music.Play();
                    break;
                }
               
            case 2:

                if (currentBackGround != "flowergarden")
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = BackGround3;
                    MuteMusic();
                    BackGround3Music.Play();
                    break;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = BackGround4;
                    MuteMusic();
                    BackGround4Music.Play();
                    break;
                }
            case 3:

                if (currentBackGround != "icy-mountain")
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = BackGround4;
                    MuteMusic();
                    BackGround4Music.Play();
                    break;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = BackGround5;
                    MuteMusic();
                    BackGround5Music.Play();
                    break;
                }
            case 4:

                if (currentBackGround != "greenland")
                {
                   // B1.Play();
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = BackGround5;
                    MuteMusic();
                    BackGround5Music.Play();
                    break;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = BackGround6;
                    MuteMusic();
                    BackGround6Music.Play();
                    break;
                }
            case 5:

                if (currentBackGround != "mountain")
                {
                    //B1.Play();
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = BackGround6;
                    MuteMusic();
                    BackGround6Music.Play();
                    break;
                }
                else
                {
                   //B1.Play();
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = BackGround7;
                    MuteMusic();
                    BackGround7Music.Play();
                    break;
                }
            case 6:

                if (currentBackGround != "winterland")
                {
                   // B1.Play();
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = BackGround7;
                    MuteMusic();
                    BackGround7Music.Play();
                    break;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = BackGround8;
                    MuteMusic();
                    BackGround8Music.Play();
                    break;
                }
            case 7:

                if (currentBackGround != "dark")
                {
                    //B1.Play();
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = BackGround8;
                    MuteMusic();
                    BackGround8Music.Play();
                    break;
                }
                else
                {   this.gameObject.GetComponent<SpriteRenderer>().sprite = BackGround1;
                    MuteMusic();
                    BackGround1Music.Play();
                    break;
                }
            
            
        }
        StartCoroutine("FadeIn");

    }


    private IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = SR.material.color;
            c.a = f;
            SR.material.color = c;
            yield return new WaitForSeconds(0.05f);
            break;

        }
        //StartCoroutine("s");
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = a;
        




    }
    private IEnumerator FadeIn()
    {
        // this.gameObject.GetComponent<SpriteRenderer>().sprite = a;
        for (float f = 0.05f; f <= 1f; f += 0.05f)
        {
            Color c = SR.material.color;
            c.a = f;
            SR.material.color = c;
            yield return new WaitForSeconds(0.05f);

        }

    }
   private void Start()
    {
       
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        rb2d = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
      
    }
       
    private void Awake ()
    {
        groundCollider = GetComponent<BoxCollider2D> ();
        //Store the size of the collider along the x axis (its length in units).
        groundHorizontalLength = groundCollider.size.x;
    }
    private void Update()
    {
        
         
       if (GameEventHandler.GetGameEventHandlerInstance().GetGameover()==true)
        {
            rb2d.velocity = Vector2.zero;

        }
        else
        {
            rb2d.velocity = new Vector2(-1, 0);
        }


       if (transform.position.x < -groundHorizontalLength) //Check if the difference along the x axis between the main Camera and the position of the object this is attached to is greater than groundHorizontalLength.
            {
                RepositionBackground();
            }
        
    }

    private void RepositionBackground()
    {
        
        Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);
        //Move this object from it's position offscreen
        transform.position = (Vector2) transform.position + groundOffSet;
    }
}
