using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumberGenerator : MonoBehaviour
{   private static RandomNumberGenerator instance;
    public static RandomNumberGenerator GetRandomNumberGeneratorInstance()

    {
        return instance;
    }
    private int number;
    public int Getnumber()

    {
        return number;
    }
    // Start is called before the first frame update
    private void OnEnable() // subscribing to the events game started and game restarted
    {
        Score.SelectRandomNumber += SelectRandomNumber;
    }

    private void OnDisable()// unsubscribing  to the events 
    {
        Score.SelectRandomNumber -= SelectRandomNumber;
    }

    public void SelectRandomNumber()

    {
        number = Random.Range(0,7);
      //  Debug.Log("my number is " + number);
    }

    private void Awake()
    {
        instance = this;
    }
}
