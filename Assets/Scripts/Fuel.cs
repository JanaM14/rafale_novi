using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
        public RafaleController rafale;

        public RectTransform Pointer;

        static float minAngle= 70.0f;
        static float maxAngle= -70.0f;
        public int fuelCapacity = 5000;


        public void FuelConverter(){

            float currentFuel= rafale.UpdateFuel();
            float ang= Mathf.Lerp(minAngle,maxAngle,Mathf.InverseLerp(0f,fuelCapacity,currentFuel));

            Pointer.rotation= Quaternion.Euler(0f,0f,ang);
        }

    
}
