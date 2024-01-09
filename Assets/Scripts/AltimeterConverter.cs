using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltimeterConverter : MonoBehaviour
{
    public RafaleController rafale;
    public RectTransform hundredsPointer;
    public RectTransform thousandsPointer;

    public void Altimeter(){

        float currentAlt = rafale.CurrentMSL*3;
        float currentThousands= currentAlt /1000f;
        currentThousands= Mathf.Clamp(currentThousands,0f,10f);

        float currentHundreds = currentAlt - (Mathf.Floor(currentThousands)*1000f);
        currentHundreds= Mathf.Clamp(currentHundreds,0f,1000f);

        float normalizedThousands= Mathf.InverseLerp(0f,10f,currentThousands);
        float thousandsRotation= 360f *normalizedThousands;
        thousandsPointer.rotation= Quaternion.Euler(0f,0f,-thousandsRotation);

        float normalizedHundreds= Mathf.InverseLerp(0f,1000f, currentHundreds);
        float hundredsRotation= 360f * normalizedHundreds;
        hundredsPointer.rotation= Quaternion.Euler(0f,0f,-hundredsRotation);
    }
}
