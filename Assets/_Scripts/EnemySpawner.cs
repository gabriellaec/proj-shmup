using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Asteroid;
    public GameObject Rocket;
    public GameObject Penguin;
    public GameObject Comet;

    public GameObject GO;
    GameManager gm;

  void Start()
  {
      gm = GameManager.GetInstance();
      GameManager.changeStateDelegate += Construir;
      Construir();  
      Debug.Log("start");
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
            for(int i = 2; i < i_l1; i++) {
                 if (i%2==0){
                    for(int j = 0; j < 2; j++){
                        Vector3 posicao = new Vector3(-1 +3f * i, 3-5.55f * j);
                        GO = Instantiate (Asteroid, posicao, Quaternion.identity, transform) as GameObject ;                        
                    }
                 }
            }
            for(int i = 2; i < i_l1; i++) {
                if (i%2!=0){
                    Vector3 posicao = new Vector3(-1 + 3f * i, (float)0);
                    GO = Instantiate (Rocket, posicao, Quaternion.identity, transform) as GameObject ;
                }
            }

             for(int i = 9; i < i_l1+10; i++) {
                 if (i%2!=0){
                Vector3 positionPenguin = new Vector3(-1 + 3f * i, (float)0);
                GO = Instantiate (Penguin, positionPenguin, Quaternion.identity, transform) as GameObject ;  
             }}

            // for(int i = 12; i < i_l1+10; i++) {
            //     if (i%2!=0){
            Vector3 position = new Vector3(-1 + 3f * 12, (float)0);
            GO = Instantiate (Comet, position, Quaternion.identity, transform) as GameObject ;
            //     }
            // }

            
   
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
            Construir();
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