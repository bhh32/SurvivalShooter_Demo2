using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public delegate void TTimeChanged(float time);

    TTimeChanged OnTimeChanged;

    float lastSecond = 0f;

    void CheckNextSecond(float time)
    {
        if (time > lastSecond + 1)
        {
            Debug.Log("tick!");
            lastSecond = lastSecond + 1;
        }
    }

    void Start()
    {
        OnTimeChanged += CheckNextSecond;
    }

    void Update()
    {
        if(OnTimeChanged != null)
            OnTimeChanged(Time.time);
    }
}
