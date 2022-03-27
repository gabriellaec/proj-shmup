using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{
 public GameObject tiro;
 private GameObject player;
  GameManager gm;
  private Animator anim;
  public AudioClip explodeSFX;

   void Start()
  {
      gm = GameManager.GetInstance(); 
      anim = GetComponent<Animator>();
      player = GameObject.FindWithTag("Player");
  }
    public void Shoot()
  {
      Vector3 posPlayer = player.transform.position;
       if (posPlayer != Vector3.zero) 
        {
            float angle = Mathf.Atan2(posPlayer.y, posPlayer.x) * Mathf.Rad2Deg;
        }
      Instantiate(tiro, transform.position  + new Vector3(1f, 0.0f, 0.0f), Quaternion.AngleAxis(angle, Vector3.forward));
  }

    public void TakeDamage()
   {
       Die();
   }

    public void Die()
    {
       
       anim.SetTrigger("explode");
       AudioManager.PlaySFX(explodeSFX);
       Destroy(gameObject,0.79f);         
    }

    float angle = 0;

    private void FixedUpdate()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        angle += 0.1f;
        Mathf.Clamp(angle, 0.0f, 4.0f * Mathf.PI);
        float x = Mathf.Sin(angle);
        float y = Mathf.Cos(angle);

        float screen_size=5.0f;
        
        Thrust(x, y);


        if (transform.position.y <= -screen_size)
            transform.position = new Vector3(transform.position.x, screen_size-(float)1, transform.position.z);


       Vector3 posPlayer = player.transform.position;
       if (posPlayer != Vector3.zero) 
        {
            float angle = Mathf.Atan2(posPlayer.y, posPlayer.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
