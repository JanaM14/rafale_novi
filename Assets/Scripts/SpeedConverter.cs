using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedConverter : MonoBehaviour
{
    static float minAngle= 140.0f;
    static float maxAngle= -140.0f;
    static SpeedConverter thisSpeedo;
    // Start is called before the first frame update
    void Start()
    {
        thisSpeedo= this;
    }

    public static void ShowSpeed(float speed, float min, float max){
        float ang= Mathf.Lerp(minAngle,maxAngle,Mathf.InverseLerp(min,max,speed));
        thisSpeedo.transform.eulerAngles= new Vector3(0,0,ang);
    }
}
