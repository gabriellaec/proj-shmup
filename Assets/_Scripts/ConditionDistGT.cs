using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionDistGT : Condition
{
   Transform agent;
   Transform target;
   float minDist;

   public ConditionDistGT(Transform ag, Transform ta, float dist)
   {
       agent = ag;
       target = ta;
       minDist = dist;
   }

   public override bool Test()
   {
    //    if (agent == null || target == null) return false; // se foi atingido

       return Vector2.Distance(agent.position, target.position) >= minDist;
   }
}