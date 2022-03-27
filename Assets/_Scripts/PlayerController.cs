using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
    Animator animator;
    public GameObject bullet;
    public GameObject superBullet;
    public GameObject shield;
    GameObject go_shield;
    private int _lifes;
    public Transform arma01;
    public float shootDelay = 0.001f;
    private float _lastShootTimestamp = 0.0f;
    public AudioClip shootSFX;
    public AudioClip thrustersSFX;
    public AudioClip winSFX; 
    public AudioClip coinSFX;   
    public AudioClip heartSFX; 
    public AudioClip damageSFX;
    public AudioClip fireballSFX;

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
        _lastShootTimestamp = Time.time;

        if (gm.superShot){
            AudioManager.PlaySFX(fireballSFX);
            Instantiate(superBullet, transform.position + new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity);
        } else{
            AudioManager.PlaySFX(shootSFX);
            Instantiate(bullet, transform.position + new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity);
        }
            


   }

     public void TakeDamage()
   {
        if (!(gm.immune)){
            AudioManager.PlaySFX(damageSFX);
            Debug.Log($"vidas: {gm.vidas} | {gm.gameState} \t");
            gm.vidas--;
            //  animator.SetTrigger("morreu");
            Debug.Log($"bateu_nave: {gm.bateu_nave} | {gm.gameState}");
            if (gm.gameState == GameManager.GameState.GAME && (gm.vidas <= 0 || gm.bateu_nave)) {           
                gm.ChangeState(GameManager.GameState.ENDGAME);
                Reset();
            }
        }
    //    animator.SetTrigger("ressurgiu");       
   }

   private void Reset(){
       transform.position =  new Vector3(0, -4.0f, 0);
   }
    public void Die()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        if (gm.timeRemainig < gm.endpowerup)
            gm.superShot = false;

        if (gm.timeRemainig < gm.endshield){
            Destroy(go_shield);
            gm.immune = false;
        }
            

        if (gm.pause_to_menu){
            Reset();
            gm.pause_to_menu=false;
        } 

        gm.progresso = transform.position.x;

        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Thrust(xInput, yInput);

        float screen_size=5.0f;
        if (transform.position.y <= -screen_size)
            transform.position = new Vector3(transform.position.x, -screen_size, transform.position.z);
        else if (transform.position.y >=screen_size)
            transform.position = new Vector3(transform.position.x, screen_size-(float)0.3, transform.position.z);
        
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

        if(gm.timeRemainig <=0  && gm.gameState == GameManager.GameState.GAME) {
            gm.ChangeState(GameManager.GameState.ENDGAME);
            Reset();
        }

        // if (transform.position.x == 50 || transform.position.x == 100 || transform.position.x == 150)
        //     gm.levelchange = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigos"))
        {
            TakeDamage();
        //    transform.position = (transform.position - Vector3.right);
        Debug.Log("INIMIGO");
        }

        else if (collision.CompareTag("Nave"))
        {
            gm.bateu_nave = true;
            TakeDamage();
        }

        else if (collision.CompareTag("heart"))
        {
            AudioManager.PlaySFX(heartSFX);
            Destroy(collision.gameObject);
            gm.vidas++;
            Debug.Log($"Vidas {gm.vidas}");
        }

        else if (collision.CompareTag("coin"))
        {
            AudioManager.PlaySFX(coinSFX);
            Destroy(collision.gameObject);
            gm.pontos += 500;
            Debug.Log($"pontos {gm.pontos}");
        }

        else if (collision.CompareTag("SpaceStation"))
        {
            AudioManager.PlaySFX(winSFX);
            if (gm.gameState == GameManager.GameState.GAME) {           
                    gm.ChangeState(GameManager.GameState.ENDGAME);
                    Reset();
            }
        }

        else if (collision.CompareTag("SuperGun"))
        {
            gm.superShot=true;
            Destroy(collision.gameObject);
            Debug.Log("SUPERGUN!!!");
            gm.endpowerup = gm.timeRemainig - 12;
        }

        else if (collision.CompareTag("Potion"))
        {
            AudioManager.PlaySFX(heartSFX);
            gm.immune=true;
            Destroy(collision.gameObject);
            Debug.Log("SHIELD!!!");
            gm.endshield = gm.timeRemainig - 10;
            go_shield = Instantiate(shield, transform.position, Quaternion.identity);
        }
    }  

}
