using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameplay_UI : MonoBehaviour
{
    public gameplay_mechanics gameplay_Mechanics;
    public Text tapcounttext;
    public Text timerText;
    public GameObject WinScreen;
    public GameObject LoseScreen;
    public GameObject Resume_Screen;
    public Text Target_txt;
    public bool isPaused=false;
    public Text CountDown_text;
    public GameObject GamePaly_Screen_Texts;
    public AudioSource gameplay_audio;
    public AudioClip gameplay_btn_audio;
    public AudioSource gameplay_btn_audio_paly;
    private bool temp=true;
    public GameObject pause_btn;
    public Animator game_over_screen_anim;
    public Animator game_win_screen_anim;
    public AudioClip tap_audio_clip;
    public AudioSource tap_audio_source;
    public Text Difficulty_lvl;
    public Text lvl_value;

    private void Start()
    {
       
        WinScreen.SetActive(false);
        Resume_Screen.SetActive(false);
        LoseScreen.SetActive(false);

        Target_txt.text = gameplay_Mechanics.lvl_target.ToString();
        PlayerPrefs.GetInt("Current_Level_Easy", 1);
        PlayerPrefs.GetInt("Current_Level_Medium", 1);
        PlayerPrefs.GetInt("Current_Level_Hard", 1);
        Difficulty_lvl.text = "     "+ PlayerPrefs.GetString("Difficulty_lvl");
        lvl_value.text = gameplay_Mechanics.current_lvl_number.ToString();
        gameplay_audio.volume = PlayerPrefs.GetFloat("Volume_Set", 0.4f);
    }
    public void tapcount_text()
    {

        tapcounttext.text = gameplay_Mechanics.tapcountvalue.ToString();
}
   public void timer_Text()
    {
        timerText.text =  gameplay_Mechanics.lvl_time.ToString("0");
    
    }

    public void Update()
    {
      
        timer_Text();

        if (gameplay_Mechanics.lvl_time <= 5)
        {
            timerText.color = new Color32(145, 0, 0, 255);

        }
        if (gameplay_Mechanics.lvl_time >5 && gameplay_Mechanics.lvl_time <= 10)
        {
            timerText.color = new Color32(255, 23, 23, 255);
           

        }
        CountDown_text.text = gameplay_Mechanics.CountDown.ToString("0");
        CountDown_disable();
       Gameplay_Screen_text_disable();
    }

    public void Show_Win_Lose_Screen()
    {
       if( gameplay_Mechanics.hasWon)
        {
            
            WinScreen.SetActive(true);
            game_win_screen_anim.SetTrigger("game_win_pop_in");
            GamePaly_Screen_Texts.SetActive(false);



        }
       else
        {
            LoseScreen.SetActive(true);
            game_over_screen_anim.SetTrigger("game_over_pop_in");
            GamePaly_Screen_Texts.SetActive(false);
        }

    }

  public void High_Score_Text()
    {
        Target_txt.text = PlayerPrefs.GetInt("Highscore").ToString();
  
    }
   public void Replay_btn_clicked()
    {
        SceneManager.LoadScene(4);
        gameplay_btn_audio_play();
        pause_btn.SetActive(true);
    }
    public void Menu_btn_clicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        gameplay_btn_audio_play();
        pause_btn.SetActive(true);
    }

    public void Pasue_btn_clicked()
    {

        gameplay_audio.Stop();
        GamePaly_Screen_Texts.SetActive(false);
            Time.timeScale = 0;
        Resume_Screen.SetActive(true);
        isPaused = true;
        gameplay_btn_audio_play();
       


    }
    public void Next_lvl_btn_clicked()
    {
        gameplay_btn_audio_play();
        if (PlayerPrefs.GetString("Difficulty_lvl") == "Easy")
        { 
            SceneManager.LoadScene(1);
        }
        if (PlayerPrefs.GetString("Difficulty_lvl") == "Medium")
        { 
            SceneManager.LoadScene(2);
        }
        if (PlayerPrefs.GetString("Difficulty_lvl") == "Hard")
        { 
            SceneManager.LoadScene(3);
        }
      

       
    }
    public void Resume_btn_clicked()
    {
        if (PlayerPrefs.GetInt("Menu_Sound") == 1)
        { gameplay_audio.Play(); }
        GamePaly_Screen_Texts.SetActive(true);
        Time.timeScale = 1;
        Resume_Screen.SetActive(false);
        isPaused = false;
        gameplay_btn_audio_play();
    }

    public void CountDown_disable()
    {
        if (gameplay_Mechanics.CountdownEnded)
        {
            CountDown_text.gameObject.SetActive(false);
          
        }
    }
    public void Gameplay_Screen_text_disable()
    {
        if (!gameplay_Mechanics.CountdownEnded)
        {
          GamePaly_Screen_Texts.SetActive(false);

        }
        else if(gameplay_Mechanics.CountdownEnded && temp)
        {
            GamePaly_Screen_Texts.SetActive(true);
            temp = false;

        }
    }
    public void gameplay_btn_audio_play()
    {
        gameplay_btn_audio_paly.PlayOneShot(gameplay_btn_audio);
    }
    public void tap_audio_play()
    {
        tap_audio_source.PlayOneShot(tap_audio_clip);
    }
}
