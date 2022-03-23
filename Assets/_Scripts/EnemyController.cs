using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{
 public GameObject tiro;
    public void Shoot()
  {
      Instantiate(tiro, transform.position  + new Vector3(0.8f, 0.0f, 0.0f), Quaternion.identity);
      //throw new System.NotImplementedException();
  }

    public void TakeDamage()
   {
       Die();
   }

    public void Die()
    {
        Destroy(gameObject);
    }

    float angle = 0;

    private void FixedUpdate()
    {
        angle += 0.1f;
        Mathf.Clamp(angle, 0.0f, 4.0f * Mathf.PI);
        float x = Mathf.Sin(angle);
        float y = Mathf.Cos(angle);

        Thrust(x, y);
       
    }
}
