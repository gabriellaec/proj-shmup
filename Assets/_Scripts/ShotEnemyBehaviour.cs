using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShotEnemyBehaviour : SteerableBehaviour
{

  private Vector3 direction;

  private GameObject player;

  void Start()
  {
      //Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;
      player = GameObject.FindWithTag("Player");
      //direction = (posPlayer - transform.position).normalized;
  }

   void Update()
  {
      Vector3 posPlayer = player.transform.position;
      direction =  (posPlayer - transform.position).normalized;
      Thrust(direction.x, direction.y);
  }

  
  private void OnBecameInvisible()
  {
      gameObject.SetActive(false);
  }

   private void OnTriggerEnter2D(Collider2D collision)
  {
      Debug.Log("ola" + collision.gameObject.tag);
      if (collision.CompareTag("Inimigos")){
          Debug.Log("oiee");
        Destroy(gameObject);
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