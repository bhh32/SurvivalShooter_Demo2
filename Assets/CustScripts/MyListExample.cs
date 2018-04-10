using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyListExample : MonoBehaviour 
{
    MyListGeneric<int> intGen;
    int[] cpy;

	// Use this for initialization
	void Start () 
    {
        intGen = new MyListGeneric<int>();
        intGen.Add(4);
        intGen.Add(5);
        intGen.Add(1);
        intGen.Add(6);
        Debug.Log(string.Format("Added new elements;\nCapacity is: {0}, Count is: {1}", intGen.Capacity, intGen.Count));

        bool testing = intGen.Contains(5);
        bool testing2 = intGen.Contains(9);
        Debug.Log(string.Format("Testing: {0}, Testing2: {1}", testing, testing2));

        Debug.Log("First Count: " + intGen.Count);
        for (int i = 0; i < intGen.Count; ++i)
        {
            Debug.Log(intGen.AtIdx(i));
        }

        Debug.Log(string.Format("Remove Tested: {0}", intGen.Remove(1)));
        Debug.Log(string.Format("Remove Tested Again: {0}", intGen.Remove(50)));

        Debug.Log("New Count After Remove: " + intGen.Count);
        for (int i = 0; i < intGen.Count; ++i)
        {
            Debug.Log(intGen.AtIdx(i));
        }

        cpy = intGen.ToArray();

        for (int i = 0; i < cpy.Length; ++i)
        {
            Debug.Log("Copy Element: " + cpy[i]);
        }

        Debug.Log(string.Format("Idx of 4 is: {0}", intGen.IndexOf(4)));
        Debug.Log(string.Format("Idx of 5 is: {0}", intGen.IndexOf(5)));
        Debug.Log(string.Format("Idx of 6 is: {0}", intGen.IndexOf(6)));

        intGen.Clear();
        Debug.Log("New Count After Clear: " + intGen.Count);

        Debug.Log(string.Format("Idx of 4 is (-1 means doesn't exist): {0}", intGen.IndexOf(4)));
        Debug.Log(string.Format("Capacity is: {0}", intGen.Capacity));
        intGen.Capacity = 0;
        Debug.Log(string.Format("Reset Capacity is: {0}", intGen.Capacity));

        intGen.Add(10);
        intGen.Add(25);
        intGen.Add(23);
        intGen.Add(12);
        intGen.Add(34);
        intGen.Add(43);
        intGen.Add(12);
        intGen.Add(54);
        intGen.Add(56);
        Debug.Log(string.Format("Added a new element;\nCapacity is: {0}, Count is: {1}", intGen.Capacity, intGen.Count));
	}
}
