using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePatrulhaPorWaypoints : State
{
  public Transform[] waypoints;  
  SteerableBehaviour steerable;


 
  public override void Awake()
  {
      base.Awake();
      // Configure a transição para outro estado aqui.
    //   Transition ataque = new Transition();
    //   ataque.condition = new ConditionDistLT(transform, GameObject.FindWithTag("Player").transform,2.0f);
    //   ataque.target = GetComponent<StateAtaque>();
    //   transitions.Add(ataque);

      steerable = GetComponent<SteerableBehaviour>();

  }

  public void Start()
  {
      waypoints[0].position = transform.position;
      waypoints[1].position = GameObject.FindWithTag("Player").transform.position;
  }

  public override void Update()
  {
      if(Vector3.Distance(transform.position, waypoints[1].position) > .1f) {
          Vector3 direction = waypoints[1].position - transform.position;
          direction.Normalize();
         steerable.Thrust(direction.x, direction.y);
      } else {
          waypoints[1].position = GameObject.FindWithTag("Player").transform.position;
      }
  }
 
}