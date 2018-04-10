using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour, IDamageable
{
    float health = 100f;

    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    [SerializeField] float armor = 0f;
    public float Armor
    {
        get { return armor; }
        set { armor = value; }
    }

    public float ApplyDamage(float amount, float armor, Vector3 hitPoint)
    {
        if (Health <= 0f)
            Destroy(gameObject);
        else
            Health -= amount;

        return Health;
    }
}
