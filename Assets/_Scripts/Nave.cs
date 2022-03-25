using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : SteerableBehaviour
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
  }

   private void OnTriggerEnter2D(Collider2D collision)
  {
      Debug.Log("ola" + collision.gameObject.tag);
      
      if (collision.CompareTag("Inimigos") || collision.CompareTag("heart") || collision.CompareTag("coin") || collision.CompareTag("SpaceStation") ){
          Debug.Log("oiee");
          return;

      } 

     Destroy(gameObject);
  }

}

