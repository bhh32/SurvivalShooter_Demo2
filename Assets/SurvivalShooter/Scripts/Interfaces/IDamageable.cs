using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    float Health
    {
        get;
        set;
    }
    
    float Armor
    {
        get;
        set;
    }

    float ApplyDamage(float amount, float armor, Vector3 hitPoint);
}
