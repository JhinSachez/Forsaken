using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    float destroyDelay = 2f;
    public int bulletDamage = 1;

    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void LaunchProjectile(Vector2 direction)
    {
        rb.velocity = direction * speed;
        Destroy(gameObject, destroyDelay);
    }

    private void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }
    
    private void Attack()
    {

        
    }
    
    private void ApplyDamage(Collider2D colliders)
    {
        enemy e = colliders.GetComponent<enemy>();
            if (e != null)
            {
                colliders.GetComponent<enemy>().TakeDamage(bulletDamage);
            }
    }

    
}
    
    

