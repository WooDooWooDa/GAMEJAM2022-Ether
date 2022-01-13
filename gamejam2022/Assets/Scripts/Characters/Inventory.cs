using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Dictionary<string, GameObject> inventory;

    void Start()
    {
        inventory = new Dictionary<string, GameObject>();
    }

    public void Add(string key, GameObject obj)
    {
        inventory.Add(key, obj);
    }

    public GameObject GetInventoryItem(string key)
    {
        if (inventory.TryGetValue(key, out var value)) {
            return value;
        }
        return null;
    }
    
    

}
