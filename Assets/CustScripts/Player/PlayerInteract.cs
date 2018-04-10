using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    
    Collider[] hitColliders;

    void Update()
    {
        Interacting();
    }

    void Interacting()
    {
        hitColliders = Physics.OverlapSphere(transform.position, 1f);

        if (hitColliders != null)
        {
            foreach (Collider c in hitColliders)
            {
                IInteractable i = c.GetComponent<IInteractable>();
                if (i != null && i.CanInteract())
                {
                    i.Interact(gameObject);
                }
            }
        }
    }
}
