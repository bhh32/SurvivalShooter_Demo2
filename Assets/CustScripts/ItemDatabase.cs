using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour 
{
    public Dictionary<string, GameObject> items = new Dictionary<string, GameObject>();

    [SerializeField] GameObject healthPrefab;
    [SerializeField] GameObject damageDealer;

    void Start()
    {
        items.Add("health", healthPrefab);
        items.Add("damage", damageDealer);
    }
}
