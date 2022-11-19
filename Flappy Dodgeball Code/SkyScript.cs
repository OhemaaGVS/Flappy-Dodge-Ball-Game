using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyScript : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
   


    public Sprite DefaultSky;
    public Sprite Sky1;
    public Sprite Sky2;
    public Sprite Sky3;
    public Sprite Sky4;
    public Sprite Sky5;
    public Sprite Sky6;
    public Sprite Sky7;
    public Sprite Sky8;
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
        this.gameObject.GetComponent<SpriteRenderer>().sprite = DefaultSky;

    }


    private void ChangeBackground()
    {
        StartCoroutine("FadeOut");
        //SelectRandomNumber();
        int Sky = RandomNumberGenerator.GetRandomNumberGeneratorInstance().Getnumber();
        string currentSky = gameObject.GetComponent<SpriteRenderer>().sprite.name;
        switch (Sky)
        {
            case 0:
                if (currentSky != "BlueTopSky")
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Sky1;

                    break;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Sky2;
                    break;
                }


            case 1:
                if (currentSky != "CanyonSky")
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Sky2;
                    break;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Sky3;
                    break;
                }

            case 2:

                if (currentSky != "FlowerGardenSky")
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Sky3;
                    break;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Sky4;
                    break;
                }
            case 3:

                if (currentSky != "IcyMountainSky")
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Sky4;
                    break;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Sky5;
                    break;
                }
            case 4:

                if (currentSky != "GreenLandSky")
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Sky5;
                    break;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Sky6;
                    break;
                }
            case 5:

                if (currentSky != "MountainSky")
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Sky6;
                    break;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Sky7;
                    break;
                }
            case 6:

                if (currentSky != "WinterLandSky")
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Sky7;
                    break;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Sky8;
                    break;
                }
            case 7:

                if (currentSky != "DarkSky")
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Sky8;
                    break;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Sky1;
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
