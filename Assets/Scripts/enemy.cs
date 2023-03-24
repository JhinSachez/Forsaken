using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{ 
    Transform Target;
    private GameObject targetGameObject;
    [SerializeField] private float speed;
    private Character targetCharacter;
    [SerializeField] private float hp = 4;
    public int  damage = 1;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    public void setTarget(GameObject target)
    {
        targetGameObject = target;
        Target = target.transform;
    }
    
    
    private void FixedUpdate()
    {
        Vector3 direction = (Target.position - transform.position).normalized;
        rb.velocity = direction * speed; 
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameObject);
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<Character>();
        }
        
        targetCharacter.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp < 1)
        {
            Destroy(gameObject);
        }
    }
}
