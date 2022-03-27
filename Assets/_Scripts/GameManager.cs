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
   public bool bateu_nave = false;

   public float endpowerup = 300;



   public bool pause_to_menu = false;
   private static GameManager _instance;

   public bool waspaused = false;

   public bool superShot = false;


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
        timeRemainig = 300;
        endpowerup = 300;
    }
   private GameManager()
   {
       vidas = 10;
       pontos = 0;
       gameState = GameState.MENU;
       timeRemainig = 300;
   }
}