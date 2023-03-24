using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
   public int maxHP = 100;
   public int currentHP = 100;

   [SerializeField] private StatusBar hpBar;
   public void TakeDamage(int damage)
   {
      currentHP -= damage;

      if (currentHP <= 0)
      {
         
      }
      hpBar.SetState(currentHP, maxHP);
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
   }
}
