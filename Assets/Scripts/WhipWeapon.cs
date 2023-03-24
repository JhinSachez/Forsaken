using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : MonoBehaviour
{
    [SerializeField] private GameObject RightWhip;
    [SerializeField] private GameObject LeftWhip;

    Movement movementVector;
    
    private float timeToAttack = 4f;
    private float timer;
    Vector2 whipAttackSize = new Vector2(4f, 2f);
    private int whipDamage = 2;

    private void Awake()
    {
        movementVector = GetComponentInParent<Movement>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
        }
    }

    private void Attack()
    {
        timer = timeToAttack;

        if (movementVector.lastHorizontalVector > 0)
        {
            RightWhip.SetActive(true);
           Collider2D[] colliders = Physics2D.OverlapBoxAll(RightWhip.transform.position, whipAttackSize, 0f);
           ApplyDamage(colliders);
        }
        else
        {
            LeftWhip.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(LeftWhip.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            enemy e = colliders[i].GetComponent<enemy>();
            if (e != null)
            {
                colliders[i].GetComponent<enemy>().TakeDamage(whipDamage);
            }
        }
    }
}
