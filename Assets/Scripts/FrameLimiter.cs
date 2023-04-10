using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameLimiter : MonoBehaviour
{
    // Start is called before the first frame update
    public int noLimit = 0;
    public int limit30 = 30;
    public int limit60 = 60;

    //public enum limits 
    //{
        //x = 10;

    //}

    //public limits limit;


    private void Awake()
    {
        //Application.targetFrameRate = limit60;
        Application.targetFrameRate = noLimit;
    }

}
