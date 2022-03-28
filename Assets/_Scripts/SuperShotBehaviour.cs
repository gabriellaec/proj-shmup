using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SuperShotBehaviour : SteerableBehaviour
{
    GameManager gm;
    private Vector3 direction;
    Vector3 posMouse;
    private void Start(){
        gm = GameManager.GetInstance();
        posMouse = Input.mousePosition;
        posMouse = Camera.main.ScreenToWorldPoint(posMouse);
        direction = (posMouse-transform.position).normalized;
    }
    private void Update()
   {
       if (gm.gameState != GameManager.GameState.GAME) return;
       //Vector3 posMouse = Input.mousePosition;
       //posMouse.z = 0.0f;
       //posMouse = Camera.main.ScreenToWorldPoint(posMouse);
       //direction = (posMouse-transform.position).normalized;
       Thrust(2.5f*direction.x, 2*direction.y);
       Destroy(gameObject,1.0f);
       //Thrust(2, 0);
   }
   private void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.CompareTag("Player") || collision.CompareTag("heart") || collision.CompareTag("coin") || collision.CompareTag("SpaceStation") || collision.CompareTag("SuperGun")|| collision.CompareTag("Nave")|| collision.CompareTag("Potion")) return;
       
       IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
       if (!(damageable is null))
       {
           damageable.TakeDamage();
       }

        try{ 
            Destroy(gameObject,3f);
            if (collision != null){
                if (collision.CompareTag("Inimigos")) {
                    gm.pontos += 300;
                    Debug.Log($"pontos: {gm.pontos} \t");
                }
            }
        } catch { // se já deu destroy mas está explodindo
            Debug.Log("sendo destruido");
        }
       


   }

   void OnBecameInvisible() {
        Destroy (gameObject);
   }
}