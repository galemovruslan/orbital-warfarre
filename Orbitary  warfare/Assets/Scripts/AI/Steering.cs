using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering
{
    public float Thrust { get; set; }
    public float Rotation { get; set; }

    public Steering()
    {
        Thrust = 0;
        Rotation = 0;
    }

    public Steering(float thrust, float rotation)
    {
        Thrust = thrust;
        Rotation = rotation;
    }
}
