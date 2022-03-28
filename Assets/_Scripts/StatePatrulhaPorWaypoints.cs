using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePatrulhaPorWaypoints : State
{
  public Transform[] waypoints;  
  SteerableBehaviour steerable;

  GameManager gm;


 
  public override void Awake()
  {
      base.Awake();
   
         steerable = GetComponent<SteerableBehaviour>();

  }

  public void Start()
  {
      gm = GameManager.GetInstance();
      waypoints[0].position = transform.position;
      waypoints[1].position = GameObject.FindWithTag("Player").transform.position;
  }

  public override void Update()
  {
      if (gm.gameState != GameManager.GameState.GAME) return;
      if(Vector3.Distance(transform.position, waypoints[1].position) > .1f) {
          Vector3 direction = waypoints[1].position - transform.position;
          direction.Normalize();
         steerable.Thrust(direction.x, direction.y);
      } else {
          waypoints[1].position = GameObject.FindWithTag("Player").transform.position;
      }
  }
 
}