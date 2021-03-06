using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Asteroid;
    public GameObject Rocket;
    public GameObject Penguin;
    public GameObject Comet;
    public GameObject Heart;
    public GameObject Coin;
    public GameObject Nave;
    public GameObject GO;
    public GameObject SuperShot;
    public GameObject Shield;
    GameManager gm;

  void Start()
  {
      gm = GameManager.GetInstance();
      GameManager.changeStateDelegate += Construir;
      Construir();  
      Debug.Log("start");
  }

  int randomPowerUp(){
    var r = new System.Random();
    var rnd = r.Next(0, 100); 
    if (rnd<=20) return 1; //moedinha
    else if (rnd<=40) return 2; //coracao
    return 0;

   }

  void Construir() {
       Debug.Log("Construir");
       Debug.Log($"waspaused{gm.waspaused} | {gm.gameState} | {gm.gameState== GameManager.GameState.GAME}");

       
       if (gm.gameState == GameManager.GameState.GAME && !(gm.waspaused)) {
           Debug.Log("asteroids");

          foreach (Transform child in transform) {
              GameObject.Destroy(child.gameObject);
          }

            int i_l1 = 8;
            int i_l2_start=50;
            Vector3 posicaoNave = new Vector3(-5,3);
            GO = Instantiate (Nave, posicaoNave, Quaternion.identity, transform) as GameObject ;  

            // Level 1
            for(int i = 2; i < i_l1; i++) {
                 if (i%2==0){
                    for(int j = 0; j < 2; j++){
                        Vector3 posicao = new Vector3(-1 +3f * i, (float)2.5-5.55f * j);
                        GO = Instantiate (Asteroid, posicao, Quaternion.identity, transform) as GameObject ;                        
                    }
                 }else{
                     Vector3 posicao = new Vector3(-1 + 3f * i, (float)0);
                     GO = Instantiate (Rocket, posicao, Quaternion.identity, transform) as GameObject ;
                 }
            }

            // Penguins L1
            for(int i = 0; i < 3; i++) {
                for(int j = 0; j < 2; j++){
                    Vector3 posicao = new Vector3(23 +6* i, (float)2.5-5.55f * j);
                    GO = Instantiate (Penguin, posicao, Quaternion.identity, transform) as GameObject ;                
                }

                if (i%2==0){
                        Vector3 posicaoCoin = new Vector3(23 +6* i, 0);
                        GO = Instantiate (Coin, posicaoCoin, Quaternion.identity, transform) as GameObject ;     
                } else{
                    Vector3 posicaoHeart = new Vector3(23 +6* i, 0);
                    GO = Instantiate (Heart, posicaoHeart, Quaternion.identity, transform) as GameObject ;   
                }   
            }

            // Level 2
            for(int i = 2; i < 8; i++) {
                //  if (i%2==0){
                    for(int j = 0; j < 2; j++){
                        Vector3 posicao = new Vector3(i_l2_start +2f * i, (float)2.5-5.55f * j);
                        GO = Instantiate (Asteroid, posicao, Quaternion.identity, transform) as GameObject ;                        
                    }

                    // if (i%2!=0){
                        Vector3 posicaoRocket = new Vector3(i_l2_start +2f * i, (float)0);
                        GO = Instantiate (Rocket, posicaoRocket, Quaternion.identity, transform) as GameObject ;
                    // }
                //  }
            }

        // Penguins L2
            for(int i = 0; i < 4; i++) {
                    for(int j = 0; j < 2; j++){
                        if (i%2==0){
                            Vector3 posicao = new Vector3(66 +6* i, (float)2.5-5.55f * j);
                            GO = Instantiate (Penguin, posicao, Quaternion.identity, transform) as GameObject ;        
                        }else{
                            Vector3 posicao = new Vector3(66 +3* i, (float)-5.55f * j);
                            GO = Instantiate (Penguin, posicao, Quaternion.identity, transform) as GameObject ; 
                        }
                                        
                    }


                    if (i%2!=0){
                        Vector3 posicaoCoin = new Vector3(66 +6* i, 0);
                        GO = Instantiate (Coin, posicaoCoin, Quaternion.identity, transform) as GameObject ;     
                    } else{
                        Vector3 posicaoHeart = new Vector3(66 +6* i, 0);
                        GO = Instantiate (Heart, posicaoHeart, Quaternion.identity, transform) as GameObject ;   
                    }   
            }


        // Level 3
            for(int i = 0; i < 8; i++) {
                if (i%2==0){
                    
                        for(int j = 0; j < 2; j++){
                            if (j==0){
                                Vector3 posicao = new Vector3(102 +4f * i, (float)2.5-5.55f * j);
                                GO = Instantiate (Penguin, posicao, Quaternion.identity, transform) as GameObject ;                        
                            } else{
                                Vector3 posicao = new Vector3(102 +4f * i, (float)2.5-5.55f * j);
                                GO = Instantiate (Asteroid, posicao, Quaternion.identity, transform) as GameObject ;                        
                            }
                    
                        }
                    
                  }else{
                        for(int j = 0; j < 2; j++){
                            if (j!=0){
                                Vector3 posicao = new Vector3(102 +4f * i, (float)2.5-5.55f * j);
                                GO = Instantiate (Penguin, posicao, Quaternion.identity, transform) as GameObject ;                        
                            } else{
                                Vector3 posicao = new Vector3(102 +4f * i, (float)2.5-5.55f * j);
                                GO = Instantiate (Asteroid, posicao, Quaternion.identity, transform) as GameObject ;                        
                            }
                    
                        }

                  }
            }



            // Level 4
            for(int i = 0; i < 10; i++) {
                if (i%2==0){
                        for(int j = 0; j < 3; j++){
                            if (j==1){
                                Vector3 posicao = new Vector3(146 +3f * i, (float)2.5-2.55f * j);
                                GO = Instantiate (Asteroid, posicao, Quaternion.identity, transform) as GameObject ;                        
                            }else if (j%2==0){
                                Vector3 posicao = new Vector3(146 +3f * i, (float)2.5-2.55f * j);
                                GO = Instantiate (Penguin, posicao, Quaternion.identity, transform) as GameObject ;                        
                            } else{
                                Vector3 posicao = new Vector3(146 +3f * i, (float)2.5-2.55f * j);
                                GO = Instantiate (Rocket, posicao, Quaternion.identity, transform) as GameObject ;                        
                            }
                    
                        }
                    
                  }else{
                        for(int j = 0; j < 3; j++){
                            if (j==1){
                                Vector3 posicao = new Vector3(146 +3f * i, (float)2.5-2.55f * j);
                                GO = Instantiate (Asteroid, posicao, Quaternion.identity, transform) as GameObject ;                        
                            }else if (j%2!=0){
                                Vector3 posicao = new Vector3(146 +3f * i, (float)2.5-2.55f * j);
                                GO = Instantiate (Penguin, posicao, Quaternion.identity, transform) as GameObject ;                        
                            } else{
                                Vector3 posicao = new Vector3(146 +3f * i, (float)2.5-2.55f * j);
                                GO = Instantiate (Rocket, posicao, Quaternion.identity, transform) as GameObject ;                        
                            }
                    
                        }

                  }

                  for(int j = 0; j < 5; j++){
                        Vector3 posicao = new Vector3(176 , (float)4-2 * j);
                        GO = Instantiate (Asteroid, posicao, Quaternion.identity, transform) as GameObject ;                        
                  }
            }

        for (int i=12; i< 176; i+=15){
            Vector3 position = new Vector3(-1 + 3f * i, (float)0);
            GO = Instantiate (Comet, position, Quaternion.identity, transform) as GameObject ;
        }
            

        for (int j=5; j> -5; j--){
            Vector3 firtMeteorposition = new Vector3(-1 + 3f * (-8),j);
            GO = Instantiate (Comet, firtMeteorposition, Quaternion.identity, transform) as GameObject ;

        }

        // bonus
        for (int j=4; j> -6; j-=2){
            Vector3 b1_pos = new Vector3(42,j);
            GO = Instantiate (Coin, b1_pos, Quaternion.identity, transform) as GameObject ;

            Vector3 b2_pos = new Vector3(92,j);
            GO = Instantiate (Coin, b2_pos, Quaternion.identity, transform) as GameObject ;

            Vector3 b3_pos = new Vector3(137,j);
            GO = Instantiate (Coin, b3_pos, Quaternion.identity, transform) as GameObject ;
        }

        // armas especiais
        Vector3 posicaoA1 = new Vector3(75,0);
        GO = Instantiate (SuperShot, posicaoA1, Quaternion.identity, transform) as GameObject ;
        Vector3 posicaoA2 = new Vector3(20,0);
        GO = Instantiate (SuperShot, posicaoA2, Quaternion.identity, transform) as GameObject ;       
        Vector3 posicaoA3 = new Vector3(130,0);
        GO = Instantiate (SuperShot, posicaoA3, Quaternion.identity, transform) as GameObject ;  
        Vector3 posicaoA4 = new Vector3(160,0);
        GO = Instantiate (SuperShot, posicaoA4, Quaternion.identity, transform) as GameObject ;                         
        Vector3 posicaoA5 = new Vector3(220,0);
        GO = Instantiate (SuperShot, posicaoA5, Quaternion.identity, transform) as GameObject ;                                                
           

        // Escudos
        Vector3 posicaoE1 = new Vector3(29,-3);
        GO = Instantiate (Shield, posicaoE1, Quaternion.identity, transform) as GameObject ;
        Vector3 posicaoE2 = new Vector3(52,3);
        GO = Instantiate (Shield, posicaoE2, Quaternion.identity, transform) as GameObject ;       
        Vector3 posicaoE3 = new Vector3(160,0);
        GO = Instantiate (Shield, posicaoE3, Quaternion.identity, transform) as GameObject ;                         
           

       }
      gm.waspaused=false;
  }


  void Update()
  {
      if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME)
      {
        Debug.Log("update");
        Construir();
            
      }
  }

}