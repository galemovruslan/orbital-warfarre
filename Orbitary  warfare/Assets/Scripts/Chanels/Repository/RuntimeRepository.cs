using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Chanels/Repository")]
public class RuntimeRepository : ScriptableObject
{
    private List<GameObject> _data = new List<GameObject>();

    private void OnEnable()
    {
        _data.Clear();
    }

    public void AddObject(GameObject newObject)
    {
        if (_data.Contains(newObject)) { return; }

        _data.Add(newObject);
    }

    public List<GameObject> GetObjects()
    {
        return _data;
        
    }

    public bool Contains(GameObject obj)
    {
        return _data.Contains(obj);
    }

}
