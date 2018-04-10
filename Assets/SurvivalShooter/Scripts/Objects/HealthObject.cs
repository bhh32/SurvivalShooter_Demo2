using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthObject : MonoBehaviour, IInteractable
{
    public float healthPerUse = 10f;
    public float rechargeTime = 30f;

    private float lastUseTime;

    void Start()
    {
        lastUseTime = rechargeTime;
    }

    void Update()
    {
        rechargeTime -= Time.deltaTime * 30f;
    }

    public bool CanInteract()
    {
        if (rechargeTime <= 0f)
        {
            rechargeTime = 30f;
            return true;
        }
        else
            return false;
    }

    public void Interact(GameObject obj)
    {
        if (obj.CompareTag("Player"))
        {
            var health = obj.GetComponent<PlayerHealth>();
            if (health.currentHealth < health.startingHealth)
            {
                health.currentHealth += 10;
                health.healthSlider.value = health.currentHealth;
            }
        }
    }
}
