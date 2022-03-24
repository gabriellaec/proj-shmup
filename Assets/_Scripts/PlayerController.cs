﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
    Animator animator;
    public GameObject bullet;
    private int _lifes;
    public Transform arma01;
    public float shootDelay = 0.001f;
    private float _lastShootTimestamp = 0.0f;
    public AudioClip shootSFX;
    public AudioClip thrustersSFX;
   GameManager gm;

    private int lifes;
    private void Start()
    {
        animator = GetComponent<Animator>();
        gm = GameManager.GetInstance();
    }

  
   public void Shoot()
   {
        if (Time.time - _lastShootTimestamp < shootDelay) return;
        AudioManager.PlaySFX(shootSFX);
        _lastShootTimestamp = Time.time;
        Instantiate(bullet, transform.position + new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity);

   }

     public void TakeDamage()
   {
       Debug.Log($"vidas: {gm.vidas} | {gm.gameState} \t");
       gm.vidas--;
       if (gm.vidas <= 0 && gm.gameState == GameManager.GameState.GAME) {
           
        //    Die();
           gm.ChangeState(GameManager.GameState.ENDGAME);

       }

       
   }
    public void Die()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Thrust(xInput, yInput);
        
        if (yInput != 0 || xInput != 0)
        {
            animator.SetFloat("Velocity", 1.0f);
            // AudioManager.PlaySFX(thrustersSFX);
        }
        else
        {
            animator.SetFloat("Velocity", 0.0f);
            // AudioManager.PauseSFX();
        }

         if(Input.GetAxisRaw("Jump") != 0)
       {
           Shoot();
       }

       if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
            gm.ChangeState(GameManager.GameState.PAUSE);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigos"))
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }

        else if (collision.CompareTag("heart"))
        {

            Destroy(collision.gameObject);
            gm.vidas++;
            Debug.Log($"Vidas {gm.vidas}");
        }
    }  

}
