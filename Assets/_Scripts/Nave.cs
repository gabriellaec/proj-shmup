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

    if (posPlayer != Vector3.zero) 
    {
        float angle = Mathf.Atan2(posPlayer.y, posPlayer.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
  }

   private void OnTriggerEnter2D(Collider2D collision)
  {
      Debug.Log("ola" + collision.gameObject.tag);
      
      if (collision.CompareTag("Inimigos") || collision.CompareTag("heart") || collision.CompareTag("coin") || collision.CompareTag("SpaceStation") || collision.CompareTag("SuperGun")){
          Debug.Log("oiee");
          return;

      } 

     Destroy(gameObject);
  }

}

