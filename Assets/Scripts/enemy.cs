using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour, IDamageable
{ 
    Transform Target;
    private GameObject targetGameObject;
    private Character targetCharacter;
    public int  damage = 1;
    private Rigidbody2D rb;

    [SerializeField] private float speed;
    [SerializeField] private float hp = 4;
    [SerializeField] private int experience_reward = 400;
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
            targetGameObject.GetComponent<Level>().AddExperience(experience_reward);
            Destroy(gameObject);
        }
    }
}
