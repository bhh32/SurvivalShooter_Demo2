using System.Collections.Generic;
using UnityEngine;

public class MetadataExample : MonoBehaviour
{
    List<Metadata<int>> specialNumbers = new List<Metadata<int>>();

    void Start()
    {
        Metadata<int> numA = new Metadata<int>();
        numA.name = "Special 1";
        numA.description = "This does special things!";
        numA.instance = 15;

        Metadata<int> numB = new Metadata<int>();
        numB.name = "Special 2";
        numB.description = "This does really special things!";
        numB.instance = 1;

        Metadata<int> numC = new Metadata<int>(4, "Special 3", "Super Special Things Are Done Here!");

        specialNumbers.Add(numA);
        specialNumbers.Add(numB);
        specialNumbers.Add(numC);
    }

    void Update()
    {
        foreach (var thing in specialNumbers)
        {
            Debug.Log(string.Format("{0} {1} {2}", thing.name, thing.description, thing.instance));
        }
    }
}