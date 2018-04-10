using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDictionaryTest : MonoBehaviour 
{
    MyDictionary<string, float> myDict;

	// Use this for initialization
	void Start () 
    {
        myDict = new MyDictionary<string, float>();

        myDict.Add("Test1", 1f);
        myDict.Add("Test2", 2f);

        Debug.Log(myDict.ContainsKey("Test1"));
        Debug.Log(myDict.ContainsKey("Nope"));

        Debug.Log(myDict["Test1"]);
        Debug.Log(myDict[2]);
	}
}