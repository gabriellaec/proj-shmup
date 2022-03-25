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

  void Construir() {
       Debug.Log("Construir");
       Debug.Log($"waspaused{gm.waspaused} | {gm.gameState} | {gm.gameState== GameManager.GameState.GAME}");

       
       if (gm.gameState == GameManager.GameState.GAME && !(gm.waspaused)) {
           Debug.Log("asteroids");

          foreach (Transform child in transform) {
              GameObject.Destroy(child.gameObject);
          }

        //   if (gm.level == 1){
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

        // Penguins L1
            for(int i = 0; i < 3; i++) {
                    for(int j = 0; j < 2; j++){
                        Vector3 posicao = new Vector3(23 +6* i, (float)2.5-5.55f * j);
                        GO = Instantiate (Penguin, posicao, Quaternion.identity, transform) as GameObject ; 

                        // if (i%2!=0){
                            Vector3 posicaoHeart = new Vector3(23 +6* i, 0);
                            GO = Instantiate (Coin, posicaoHeart, Quaternion.identity, transform) as GameObject ;     
                        // }                       
                    }
            }


        // Penguins L2
            for(int i = 0; i < 3; i++) {
                    for(int j = 0; j < 2; j++){
                        Vector3 posicao = new Vector3(23 +6* i, (float)2.5-5.55f * j);
                        GO = Instantiate (Penguin, posicao, Quaternion.identity, transform) as GameObject ;                        
                    }
            }

        //     Vector3 positionPenguin = new Vector3(26f, (float)0);
        // GO = Instantiate (Penguin, positionPenguin, Quaternion.identity, transform) as GameObject ;     
        // Vector3 positionPenguin2 = new Vector3(32f, (float)0);
        // GO = Instantiate (Penguin, positionPenguin2, Quaternion.identity, transform) as GameObject ;     





            // for(int i = 2; i < i_l1; i++) {
            //     if (i%2!=0){
            //         Vector3 posicao = new Vector3(-1 + 3f * i, (float)0);
            //         GO = Instantiate (Rocket, posicao, Quaternion.identity, transform) as GameObject ;

            //         if (randomPowerUp()==1){
            //                 Vector3 posicaoSurpriseCoin = new Vector3(-1 +3f * i, 2);
            //                 GO = Instantiate (Coin, posicaoSurpriseCoin, Quaternion.identity, transform) as GameObject ;   
            //             }else if (randomPowerUp()==2){
            //                 Vector3 posicaoSurpriseHeart = new Vector3(-1 +3f * i, 2);
            //                 GO = Instantiate (Heart, posicaoSurpriseHeart, Quaternion.identity, transform) as GameObject ;   
            //             }
            //     }
            // }

            //  for(int i = 21; i < i_l1+10; i++) {
            //      if (i%2!=0){
            //     Vector3 positionPenguin = new Vector3(-1 + 3f * i, (float)0);
            //     GO = Instantiate (Penguin, positionPenguin, Quaternion.identity, transform) as GameObject ;  
            //  }}
            

            // for(int i = 12; i < i_l1+10; i++) {
            //     if (i%2!=0){
            Vector3 position = new Vector3(-1 + 3f * 12, (float)0);
            GO = Instantiate (Comet, position, Quaternion.identity, transform) as GameObject ;


            Vector3 firtMeteorposition = new Vector3(-1 + 3f * (-8), (float)0);
            GO = Instantiate (Comet, firtMeteorposition, Quaternion.identity, transform) as GameObject ;


            // for(int i = 2; i < i_l1*2; i++) {
            //      if (i%4==0){
            //             if (randomPowerUp()==1){
            //                 Vector3 posicaoSurpriseCoin = new Vector3(-1 +3f * i, 2);
            //                 GO = Instantiate (Coin, posicaoSurpriseCoin, Quaternion.identity, transform) as GameObject ;   
            //             }else if (randomPowerUp()==2){
            //                 Vector3 posicaoSurpriseHeart = new Vector3(-1 +3f * i, 2);
            //                 GO = Instantiate (Heart, posicaoSurpriseHeart, Quaternion.identity, transform) as GameObject ;   
            //             }
                                                 
            //      }
            // }
            //     }
            // }

       }
      gm.waspaused=false;
  }

  void Penguins(){
        if (gm.gameState == GameManager.GameState.GAME && !(gm.waspaused)) {
            Debug.Log("penguins");

            foreach (Transform child in transform) {
                GameObject.Destroy(child.gameObject);
        }
        Debug.Log($"Progresso: {gm.progresso}");
       
        Vector3 positionPenguin = new Vector3(26f, (float)0);
        GO = Instantiate (Penguin, positionPenguin, Quaternion.identity, transform) as GameObject ;     
    }
    gm.waspaused=false;

  }

  void Update()
  {
      if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME)
      {
         Debug.Log("update");
        //   if (gm.level == 1){
        //     gm.level += 1;
            // gm.pontos *= 2;
            // Construir();
            Debug.Log($"Progresso: {gm.progresso}");
            if (gm.progresso >=15) Penguins();
        //     gm.levelchange = true;
        //   }else if (gm.level == 2){
        //     gm.level += 1;
        //     gm.pontos *= 2;
        //     Construir();
        //     gm.levelchange = true;
        //   }
        //   else {
        //     gm.ChangeState(GameManager.GameState.ENDGAME);
        //     gm.level = 1;
        //     gm.levelchange = true;
        //   }   
      }
  }

}