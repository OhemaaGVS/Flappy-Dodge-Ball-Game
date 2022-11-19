using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class GameoverTextScript : MonoBehaviour
{
    Text gameover;
   
    private void OnEnable()
    {
        gameover = GetComponent<Text>();
        gameover.text = "GAME OVER";

    }
















}


