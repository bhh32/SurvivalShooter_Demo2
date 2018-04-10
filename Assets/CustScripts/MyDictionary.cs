using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDictionary<TKey, TValue> 
{
    TKey[] keys;
    TValue[] values;

    int capacity = 1;
    int count = 0;

    private int lastIdx = 0;

    // Same as overloading subscript operator
    public TValue this [TKey key]
    {
        get 
        {
            for (int i = 0; i < count; ++i)
            {
                if (keys[i].Equals(key))
                {
                    return values[i];
                }
            }

            return default(TValue);
        }
    }

    // Same as overloading subscript operator
    public TKey this [TValue val]
    {
        get
        {
            for (int i = 0; i < count; ++i)
            {
                if (values[i].Equals(val))
                    return keys[i];
            }

            return default(TKey);
        }
    }

    public MyDictionary()
    {
        capacity = 1;
        keys = new TKey[capacity];
        values = new TValue[capacity];
    }

    public MyDictionary(int cap)
    {
        capacity = cap;

        keys = new TKey[capacity];
        values = new TValue[capacity];
    }

    public void Add(TKey key, TValue val)
    {
        if (capacity == 0)
            capacity = keys.Length;

        if (count == keys.Length)
        {
            capacity += 2;
            TKey[] tempKey = keys;
            TValue[] tempVal = values;

            keys = new TKey[capacity];
            values = new TValue[capacity];

            tempKey.CopyTo(keys, 0);
            tempVal.CopyTo(values, 0);
        }

        keys[lastIdx] = key;
        values[lastIdx] = val;

        count++;
        lastIdx++;
    }

    public bool ContainsKey(TKey key)
    {
        for (int i = 0; i < count; ++i)
        {
            if (keys[i].Equals(key))
                return true;
        }

        return false;
    }
}
