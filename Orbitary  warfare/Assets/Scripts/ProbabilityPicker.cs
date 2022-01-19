using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProbabilityPicker
{
    public static T PickWeightedObject<T>(T[] variants, int[] weights)
    {
        RangesFromWeights(weights, out int[] ranges);
        return PickObject<T>(variants, ranges);
    }

    public static T PickObject<T>(T[] variants, int[] ranges)
    {
        int idx = PickIndex(ranges);
        return variants[idx];
    }

    public static int PickWeightedIndex(int[] weights)
    {
        RangesFromWeights(weights, out int[] ranges);
        return PickIndex(ranges);
    }

    public static int PickIndex(int[] ranges)
    {
        int index = Random.Range(0, ranges[ranges.Length-1]);
        for (int i = 0; i < ranges.Length; i++)
        {
            if (index <= ranges[i])
            {
                return i;    
            }
        }
        return ranges.Length;
    }

    public static void RangesFromWeights(int[] weights, out int[] ranges)
    {
        ranges = new int[weights.Length];
        int nextRange = 0;
        for (int i = 0; i < weights.Length; i++)
        {
            nextRange += weights[i];
            ranges[i] = nextRange;
        }
    }

}
