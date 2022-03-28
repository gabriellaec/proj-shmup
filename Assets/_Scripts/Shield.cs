using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : SteerableBehaviour
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
}
