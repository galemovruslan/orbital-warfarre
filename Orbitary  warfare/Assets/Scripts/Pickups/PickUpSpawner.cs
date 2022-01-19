using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] private PickUp _shieldObject;
    [SerializeField] private ShieldVariant[] _shieldVariants;

    [ContextMenu("Spawn")]
    public void SpawnRandomShield()
    {
        int[] weights = GetWeights(_shieldVariants);
        int index = ProbabilityPicker.PickWeightedIndex(weights);
        SpawnShield(index);
    }


    private int[] GetWeights(Weighted[] weightedVariants)
    {
        int[] weights = new int[weightedVariants.Length];

        for (int index = 0; index < weightedVariants.Length; index++)
        {
            weights[index] = weightedVariants[index].Weight;
        }
        return weights;
    }

    private void SpawnShield(int index)
    {
        PickUp createdPickup = Instantiate(_shieldObject, transform.position, Quaternion.identity);
        createdPickup.Init(_shieldVariants[index].Stock, _shieldVariants[index].Icon);
    }


    [System.Serializable]
    private class ShieldVariant : Weighted
    {
        int Weighted.Weight
        { 
            get => weight;
            set => weight = value; 
        }

        public ShieldStock Stock;
        public Sprite Icon;
        public int weight;

    }

    private interface Weighted
    {
        public int Weight { get; set; }
    }

    //private struct WeaponVariant
    //{
    //    public WeaponStock Stock;
    //    public Sprite Icon;
    //}

}
