using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShotBehaviour : SteerableBehaviour
{
    GameManager gm;

    private void Start(){
        gm = GameManager.GetInstance();
    }
    private void Update()
   {
       Thrust(1, 0);
   }
   private void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.CompareTag("Player")) return;
       
       IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
       if (!(damageable is null))
       {
           damageable.TakeDamage();
       }

       Destroy(gameObject, 2.5f);
       gm.pontos += 100;
       Debug.Log($"pontos: {gm.pontos} \t");


   }


   void OnBecameInvisible() {
        Destroy (gameObject);
   }
}