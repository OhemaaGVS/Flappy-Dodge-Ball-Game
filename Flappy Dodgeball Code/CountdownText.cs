using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class CountdownText : MonoBehaviour
{

    public delegate void StartCountdown();// A Delegate allows us to treat method as a variable and pass method as a variable for a callback. When it get called , it notifies all methods that reference the delegate.
    public static event StartCountdown CountdownFinished; // public event 
    Text countdown;
    private void OnEnable()
    {
        countdown = GetComponent<Text>();
        countdown.text = "3";
        StartCoroutine("Countdown");
    }

    private IEnumerator Countdown() // the countdown routine , waits one second before showing another number
    {
        int count = 3;
        for (int i = 0; i < count; i++)
        {
            countdown.text = (count - i).ToString();
            yield return new WaitForSeconds(1);
        }

        CountdownFinished();// calling the event countdown finished 

    }


}
