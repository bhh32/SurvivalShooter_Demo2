using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyListGeneric<T>
{
    T[] instance;
    private int idx = 0;
    public int Idx 
    {
        get{ return idx; }
    }

    private int lastIdx = 0;

    private int capacity;
    public int Capacity
    {
        get { return capacity; }
        set 
        { 
            capacity = value;

            // Guards against an array capacity of 0;
            if (capacity == 0)
                capacity = 1;
            
            T[] temp = instance;
            instance = new T[capacity];

            int cpyAmt = instance.Length < temp.Length ? instance.Length : temp.Length;
            System.Array.Copy(temp, instance, cpyAmt);
        }
    }

    private int count;
    public int Count
    {
        get{return count;}
    }

    public MyListGeneric()
    {
        capacity = 1;
        instance = new T[capacity];
    }

    public MyListGeneric(int cap)
    {
        capacity = cap;
        instance = new T[capacity];
    }

    public void Add(T newElement)
    {
        if (capacity == 0)
        {
            capacity = instance.Length;
        }

        if (count == instance.Length - 1)
        {
            capacity += 2;
            T[] temp = instance;
            instance = new T[capacity];
            temp.CopyTo(instance, 0);
        }

        instance[lastIdx] = newElement;
        count++;
        lastIdx++;
    }

    public bool Remove(T element)
    {
        // Ensure we just at least one element
        if (count > 0)
        {
            // Iterate through each element to check if it is the same as the requested element
            for (int i = 0; i < count - 1; ++i)
            {
                // If it is the same...
                if (instance[i].Equals(element))
                {
                    // ... Move everything down one
                    for (int j = i; j < count - 1; ++j)
                    {
                        instance[j] = instance[j + 1];
                    }

                    // Reduce the count
                    count--;
                    // Return true to leave the method early
                    return true;
                }
            }
        }

        // Return false since we didn't find the element
        return false;
    }

    public T AtIdx(int idx)
    {
        return instance[idx];
    }

    public void Clear()
    {
        for (int i = 0; i < count; ++i)
        {
            instance[i] = default(T);
        }

        count = 0;
        lastIdx = count;
    }

    public bool Contains(T element)
    {
        foreach (var x in instance)
        {
            if (x.Equals(element))
                return true;
        }

        return false;
    }

    public int IndexOf(T element)
    {
        for (int i = 0; i < count; ++i)
        {
            if (instance[i].Equals(element))
            {
                return i;
            }
        }

        return -1;
    }

    public T[] ToArray()
    {
        T[] temp = new T[count];
        for (int i = 0; i < count; ++i)
        {
            temp[i] = instance[i];
        }

        return temp;
    }
}

[System.Serializable]
public class MyListGeneric : MyListGeneric<int>
{
    
}
