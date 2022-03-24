using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{
 public GameObject tiro;
 private GameObject player;

   void Start()
  {
      //Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;
      player = GameObject.FindWithTag("Player");
      //direction = (posPlayer - transform.position).normalized;
  }
    public void Shoot()
  {
      Vector3 posPlayer = player.transform.position;
       if (posPlayer != Vector3.zero) 
        {
            float angle = Mathf.Atan2(posPlayer.y, posPlayer.x) * Mathf.Rad2Deg;
        }

      Instantiate(tiro, transform.position  + new Vector3(1f, 0.0f, 0.0f), Quaternion.AngleAxis(angle, Vector3.forward));
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
       

       Vector3 posPlayer = player.transform.position;
       if (posPlayer != Vector3.zero) 
        {
            float angle = Mathf.Atan2(posPlayer.y, posPlayer.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
      
    }
}
