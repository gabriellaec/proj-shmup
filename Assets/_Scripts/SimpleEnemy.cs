using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : SteerableBehaviour, IDamageable
{
    public void TakeDamage()
   {
       Die();
   }

    public void Die()
    {
       Destroy(gameObject);
    }
}
