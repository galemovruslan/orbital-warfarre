using UnityEngine;

public class Steering
{
    public Vector3 Thrust { get; set; }
    public float Rotation { get; set; }
    public float Weight { get; set; }

    public Steering()
    {
        Thrust = Vector3.zero;
        Rotation = 0;
        Weight = 1;
    }

    public Steering(Vector3 thrust, float rotation)
    {
        Thrust = thrust;
        Rotation = rotation;
        Weight = 1;
    }

    public Steering(Vector3 thrust, float rotation, float weight)
    {
        Thrust = thrust;
        Rotation = rotation;
        Weight = Mathf.Clamp01(weight);
    }
}
