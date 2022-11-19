using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    public Sprite DefaultGround;
    public Sprite Ground1;
    public Sprite Ground2;
    public Sprite Ground3;
    public Sprite Ground4;
    public Sprite Ground5;
    public Sprite Ground6;
    public Sprite Ground7;
    public Sprite Ground8;
    SpriteRenderer SR;

    // Start is called before the first frame update
    void Start()
    {
         SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable() // subscribing to the events game started and game restarted
    {
        Score.ChangeBackground += ChangeBackground;
        GameEventHandler.DefaultBackground += DefaultBackground;
    }

    private void OnDisable()// unsubscribing  to the events 
    {
        Score.ChangeBackground -= ChangeBackground;
        GameEventHandler.DefaultBackground -= DefaultBackground;
    }

    private void DefaultBackground()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = DefaultGround;

    }


    private void ChangeBackground()
    {
        StartCoroutine("FadeOut");
        //SelectRandomNumber();
        int ground = RandomNumberGenerator.GetRandomNumberGeneratorInstance().Getnumber();
        string currentGround = gameObject.GetComponent<SpriteRenderer>().sprite.name;
        switch (ground)
        {
            case 0:
                if (currentGround != "ground")
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Ground1;

                    break;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Ground2;
                    break;
                }


            case 1:
                if (currentGround != "CanyonGround")
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Ground2;
                    break;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Ground3;
                    break;
                }

            case 2:

                if (currentGround != "FlowerGardenGround")
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Ground3;
                    break;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Ground4;
                    break;
                }
            case 3:

                if (currentGround != "IcyMountainGround")
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Ground4;
                    break;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Ground5;
                    break;
                }
            case 4:

                if (currentGround != "GreenLandGround")
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Ground5;
                    break;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Ground6;
                    break;
                }
            case 5:

                if (currentGround != "MountainGround")
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Ground6;
                    break;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Ground7;
                    break;
                }
            case 6:

                if (currentGround != "WinterLandGround")
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Ground7;
                    break;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Ground8;
                    break;
                }
            case 7:

                if (currentGround != "DarkGround")
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Ground8;
                    break;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Ground1;
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




































}
