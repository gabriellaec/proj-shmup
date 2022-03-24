using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShotBehaviour : SteerableBehaviour
{
    GameManager gm;

    // private Animator anim;
    private void Start(){
        gm = GameManager.GetInstance();
        // anim = GetComponent<Animator>();
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

       if (collision.CompareTag("Inimigos")) {
           gm.pontos += 100;
           Debug.Log($"pontos: {gm.pontos} \t");
       }
       


   }


   void OnBecameInvisible() {
        // anim.SetTrigger("explode");
        Destroy (gameObject);
   }
}