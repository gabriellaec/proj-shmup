using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager
{
   public enum GameState { MENU, GAME, PAUSE, ENDGAME };
   public GameState gameState { get; private set; }
   public int vidas;
   public int pontos;
   public float timeRemainig;
   public bool levelchange;
   public float progresso;



   public bool pause_to_menu = false;
   private static GameManager _instance;

   public bool waspaused = false;


   public static GameManager GetInstance()
   {
       if(_instance == null)
       {
           _instance = new GameManager();
       }

       return _instance;
   }

   public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    public void ChangeState(GameState nextState)
    {
    if (nextState == GameState.GAME && (gameState != GameState.PAUSE )) Reset();

    else if (nextState == GameState.GAME && (gameState == GameState.PAUSE )) 
        waspaused = true;

    else if (nextState == GameState.MENU && (gameState == GameState.PAUSE ))
        pause_to_menu = true;

    gameState = nextState;
    changeStateDelegate();
    }

    private void Reset()
    {
        vidas = 10;
        pontos = 0;
        timeRemainig = 420;
        // levelchange = false;
    }
   private GameManager()
   {
       vidas = 10;
       pontos = 0;
       gameState = GameState.MENU;
       timeRemainig = 420;
    //    levelchange = false;
   }
}