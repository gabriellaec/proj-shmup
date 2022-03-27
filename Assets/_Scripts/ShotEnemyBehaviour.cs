using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShotEnemyBehaviour : SteerableBehaviour
{

  private Vector3 direction;

  private GameObject player;

  GameManager gm;

  void Start()
  {
      player = GameObject.FindWithTag("Player");
      gm = GameManager.GetInstance(); 
  }

   void Update()
  {
     if (gm.gameState != GameManager.GameState.GAME) return;
      Vector3 posPlayer = player.transform.position;
      direction =  (posPlayer - transform.position).normalized;
      Thrust(direction.x, direction.y);
      Destroy(gameObject,5.0f); // se não atingir o player em 10s, some
    
  }

  
  private void OnBecameInvisible()
  {
      gameObject.SetActive(false);
  }

   private void OnTriggerEnter2D(Collider2D collision)
  {
      Debug.Log("ola" + collision.gameObject.tag);
      
      if (collision.CompareTag("Inimigos") || collision.CompareTag("heart") || collision.CompareTag("coin") || collision.CompareTag("SpaceStation") || collision.CompareTag("Nave") || collision.CompareTag("SuperGun")|| collision.CompareTag("Potion")){
          Debug.Log("oiee");
          return;

      } 

      IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
      if (!(damageable is null))
      {
          damageable.TakeDamage();
      }


     Destroy(gameObject);
  }

}