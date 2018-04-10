using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionObject : MonoBehaviour, IInteractable
{
    public void Interact(GameObject obj)
    {
        if (obj.CompareTag("Player"))
        {
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.AddExplosionForce(100f, transform.position, 10f);
            var health = obj.GetComponent<PlayerHealth>();
            health.currentHealth -= 10;
            health.healthSlider.value = health.currentHealth;

            Destroy(gameObject);
        }
    }

    public bool CanInteract()
    {
        return true;
    }
}
