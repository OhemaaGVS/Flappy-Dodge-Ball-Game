using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PoolBall : MonoBehaviour
{
    public Transform transform;//Position, rotation and scale of an object.
    private bool inUse;
    public bool GetinUse()// getter for the private bool
    {
        return inUse;
    }
    public PoolBall(Transform t) // a constructer (Constructors allow you to set up your objects at the time you create them) setting transform to t 
    {
        transform = t;
    }
    public void SetinUseTrue()// a setter that sets inuse true
    {
        inUse = true;
    }
    public void SetinUseFalse()// a setter that sets in use false
    {
        inUse = false;
    }

}
