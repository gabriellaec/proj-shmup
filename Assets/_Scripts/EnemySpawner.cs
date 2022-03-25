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

    public GameObject GO;
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

    Debug.Log($"Surpresinha: {rnd}");
   }

  async void Construir() {
       Debug.Log("Construir");
       Debug.Log($"waspaused{gm.waspaused} | {gm.gameState} | {gm.gameState== GameManager.GameState.GAME}");

       
       if (gm.gameState == GameManager.GameState.GAME && !(gm.waspaused)) {
           Debug.Log("asteroids");

          foreach (Transform child in transform) {
              GameObject.Destroy(child.gameObject);
          }

            int i_l1 = 8;
            int i_l2_start=50;
            int i_l2_end=66;

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