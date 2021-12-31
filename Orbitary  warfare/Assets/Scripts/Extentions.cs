using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extentions 
{
    public static float Remap(this float input, float minInput, float maxInput, float minOut = -1, float maxOut = 1)
    {
        float t = Mathf.InverseLerp(minInput, maxInput, input);
        return Mathf.Lerp(minOut, maxOut, t);
    }

}
