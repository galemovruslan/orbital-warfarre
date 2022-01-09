using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predictor
{

    public Vector3 Predict(Vector3 position, Vector3 velocity, float predictionTime)
    {
        Vector3 currentPosition = position;
        Vector3 predictedPosition = currentPosition + velocity * predictionTime;
        return predictedPosition;
    }

}
