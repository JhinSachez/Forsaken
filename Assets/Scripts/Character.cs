using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
   public int maxHP = 100;
   public int currentHP = 100;
   public int armor = 0;
   private bool isDead;

   [SerializeField] private StatusBar hpBar;

   private void Start()
   {
      hpBar.SetState(currentHP, maxHP);
   }

   public void TakeDamage(int damage)
   {
      if (isDead == true) { return;}
      ApplyArmor(ref damage);
      
      currentHP -= damage;

      if (currentHP <= 0)
      {
         GetComponent<GameOver>().GameOvers(); 
         isDead = true;
      }
      hpBar.SetState(currentHP, maxHP);
   }

   private void ApplyArmor(ref int damage)
   {
      damage -= armor;
      if (damage < 0)
      {
         damage = 0;
      }
   }

   public void Heal(int amount)
   {
      if (currentHP < 0f)
      {
         return;
      }

      currentHP += amount;
      if (currentHP > maxHP)
      {
         currentHP = maxHP;
      }
      hpBar.SetState(currentHP, maxHP);
   }
}
