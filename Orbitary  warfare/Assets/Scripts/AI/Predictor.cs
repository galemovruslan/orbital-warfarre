using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Predictor
{

    public static Vector3 Predict(Vector3 position, Vector3 velocity, float predictionTime)
    {
        Vector3 currentPosition = position;
        Vector3 predictedPosition = currentPosition + velocity * predictionTime;
        return predictedPosition;
    }

}
