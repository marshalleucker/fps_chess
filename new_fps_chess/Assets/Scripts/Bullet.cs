using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifespan = 1.0f; // The time in seconds before the bullet is automatically destroyed
    public float colliderActivationDelay = 0.1f;
    private Collider bulletCollider;

    void Start()
    {
        bulletCollider = GetComponent<Collider>();
        bulletCollider.enabled = false;
        Invoke("ActivateCollider", colliderActivationDelay);
        Destroy(gameObject, lifespan);
    }

    void ActivateCollider()
    {
        bulletCollider.enabled = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Destroy the bullet when it collides with anything
        Destroy(gameObject);
    }
}