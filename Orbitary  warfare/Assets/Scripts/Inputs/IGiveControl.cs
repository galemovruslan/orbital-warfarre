using UnityEngine;

public interface IGiveControl 
{
    ShipControlSignals GetControlSignals();
}

public struct ShipControlSignals
{
    public float rotation;
    public float thrust;

    public ShipControlSignals(float newRotation, float newThrust)
    {
        rotation = newRotation;
        thrust = newThrust;
    }
}