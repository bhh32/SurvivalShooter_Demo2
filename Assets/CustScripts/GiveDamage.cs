using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamage : MonoBehaviour, IInteractable 
{
    [SerializeField] float damageGiven = 10f;

    ItemSpawner itemSpawner;

    void Awake()
    {
        itemSpawner = GetComponentInParent<ItemSpawner>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
            Interact(other.gameObject);
    }

    public bool CanInteract()
    {
        if (itemSpawner.CanSpawn)
            return true;
        else
            return false;
    }

    public void Interact(GameObject obj)
    {
        if (obj.CompareTag("Player"))
        {
            var health = obj.GetComponent<PlayerHealth>();

            if (health.currentHealth > 0)
            {
                health.currentHealth -= (int)damageGiven;
                health.healthSlider.value = health.currentHealth;
            }
        }
        itemSpawner.CanSpawn = true;
        Destroy(gameObject);
    }
}
