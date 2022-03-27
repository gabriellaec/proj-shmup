
using UnityEngine;
using UnityEngine.UI;
public class UI_FimDeJogo : MonoBehaviour
{
   public Text message;
   public Text score;
   public Text highscore;
   public int recorde;

    GameManager gm;
    public AudioClip perdeuSFX;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();

        if(gm.vidas > 0 && gm.timeRemainig >=0 && !(gm.bateu_nave)){
           message.text = "Você Ganhou!!";
           gm.pontos += (int)(gm.timeRemainig*5);
       } 
       else if (gm.vidas > 0 && gm.timeRemainig <= 0){
            AudioManager.PlaySFX(perdeuSFX);
            message.text = "Timeout!!";
       } 
       else{
           AudioManager.PlaySFX(perdeuSFX);
           gm.bateu_nave=false;
           message.text = "Você Perdeu!!";
       } 

        // highscore
        if ( (PlayerPrefs.GetInt("HighScore",0)) < gm.pontos) 
            PlayerPrefs.SetInt("HighScore", gm.pontos);

       recorde = PlayerPrefs.GetInt("HighScore",0);
       if (recorde == gm.pontos) score.text = "New High Score!!";
       else score.text = $"Score: {gm.pontos}";

       
       highscore.text = $"HighScore: {recorde.ToString()}";
    }

   
    public void Voltar()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }

}