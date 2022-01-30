using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] private Variant[] _variants;
    [Min(0.1f)] [SerializeField] private float _spawnInterval = 1f;
    [Min(0)] [SerializeField] private float _timeOffset = 0f;

    private float _nextSpawnTime;
    private float _currentTime;

    private void OnEnable()
    {
        _nextSpawnTime = _timeOffset;
        _currentTime = 0f;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime < _nextSpawnTime) { return; }

        SpawnRandom();

        _nextSpawnTime += _spawnInterval;
    }

    public void SpawnRandom()
    {
        int[] weights = GetWeights(_variants);
        int index = ProbabilityPicker.PickWeightedIndex(weights);
        SpawnPickUp(index);
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

    private void SpawnPickUp(int index)
    {
        PickUp createdPickup = Instantiate(_variants[index].pickUp, transform.position, Quaternion.identity);
        createdPickup.Init();
    }


    [System.Serializable]
    private class Variant : Weighted
    {
        int Weighted.Weight
        { 
            get => weight;
            set => weight = value; 
        }

        public PickUp pickUp;
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
