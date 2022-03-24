using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : SteerableBehaviour, IDamageable
{

    private Animator anim;

    public void start(){
        anim = GetComponent<Animator>();
    }
    public void TakeDamage()
   {
       Die();
   }

    public void Die()
    {
       anim = GetComponent<Animator>();
       anim.SetTrigger("explode");
       Destroy(gameObject,0.8f);
    }

}
