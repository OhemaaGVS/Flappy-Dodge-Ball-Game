using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDefaultBallSpeed : MonoBehaviour
{
    private static SetDefaultBallSpeed instance;
    private float BallSpeed = 4f;
    public static SetDefaultBallSpeed GetBallSpeedInstance ()
    {
        return instance;
       
    }
    public float GetBallSpeed()
    {
        return BallSpeed;
    }
    // Start is called before the first frame update
    private void Awake()
    {    
        instance = this;
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
