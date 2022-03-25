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
       if (gm.gameState != GameManager.GameState.GAME) return;
       Thrust(1, 0);
   }
   private void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.CompareTag("Player") || collision.CompareTag("heart") || collision.CompareTag("coin") || collision.CompareTag("SpaceStation") ) return;
       
       IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
       if (!(damageable is null))
       {
           damageable.TakeDamage();
       }

       Destroy(gameObject);
        if (collision != null){
            if (collision.CompareTag("Inimigos")) {
                gm.pontos += 100;
                if (gm.pontos >=10000 && gm.gameState == GameManager.GameState.GAME) {           
                        gm.ChangeState(GameManager.GameState.ENDGAME);
                    }
                Debug.Log($"pontos: {gm.pontos} \t");
            }
        }
       


   }


   void OnBecameInvisible() {
        Destroy (gameObject);
   }
}