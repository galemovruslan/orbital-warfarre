
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Enemy Wave")]
public class WaveContent : ScriptableObject
{
    [SerializeField] private Description[] Enemies;

    public IEnumerable<Description> GetDescriptions()
    {
        return Enemies;
    }

    public int GetWaveLength()
    {
        return Enemies.Length;
    }

}

    [System.Serializable]
    public struct Description
    {
        public Enemy EnemyPrefab;
        public int Amount;
    }
