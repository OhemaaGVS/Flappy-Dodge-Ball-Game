using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteStartPosSetter : MonoBehaviour
{
   public Vector3 startPos;
   private void Start()// moves the object to the desired start position
   {
    
        transform.position = startPos;
    }
    private void OnEnable()// subscribing to an event
    {
        GameEventHandler.GameReStarted += GameReStarted;
    }

    private void OnDisable()// subscribing to an event
    {
        GameEventHandler.GameReStarted -= GameReStarted;
    }
    private void GameReStarted()// when the event game restarted occurs it calls the function set start pos
    {
        SetStartPos();
    }

     private void SetStartPos() // sets the object to the desired position

    {
         transform.position = startPos;
    }
   }

