using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metadata<T>
{
    public T instance;

    public string name;
    public string description;

    public Metadata(){}

    public Metadata(T v, string n, string d)
    {
        instance = v;
        name = n;
        description = d;
    }
}