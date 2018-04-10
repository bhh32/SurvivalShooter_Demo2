using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour 
{
    Dictionary<string, GameObject> blockDatabase = new Dictionary<string, GameObject>();

    [SerializeField] GameObject blockA;
    [SerializeField] GameObject blockB;
    [SerializeField] GameObject blockC;
    [SerializeField] GameObject blockD;

    [SerializeField] string blockDesired;

    void Start()
    {
        blockDatabase.Add("block1", blockA);
        blockDatabase.Add("block2", blockB);
        blockDatabase.Add("block3", blockC);
        blockDatabase.Add("block4", blockD);
    }

    void Update()
    {
        if(blockDesired != string.Empty)
            Instantiate(blockDatabase[blockDesired]);
    }
}
