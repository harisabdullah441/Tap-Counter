using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Main_Manu_UI : MonoBehaviour
{
   
  
    public GameObject Main_Screen;

   public AudioSource Main_Menu_audio;
    public AudioClip buttonClick_sound;
    public AudioSource button_audio;
    
    public Animator Setting_screen_anim;
    public Animator HowToplay_screen_anim;
    public Animator Credit_screen_anim;
    
   
    public Slider volume_slider;
    public  GameObject sound_on;
    public  GameObject sound_off;
    public Button Easy_diff_btn;
    public Button Medium_diff_btn;
    public Button Hard_diff_btn;

   
    void Start()
    {
        Main_Screen.SetActive(true);
    
     
        
        volume_slider.value= PlayerPrefs.GetFloat("Volume_Set", 0.4f);
       
        if (PlayerPrefs.GetInt("Menu_Sound",1)==1)
        { sound_off_clicked(); }
        if (PlayerPrefs.GetInt("Menu_Sound",1) == 0)
        { sound_on_clicked(); }
        PlayerPrefs.GetString("Difficulty_lvl","Easy");
    }

    private void Update()
    {
        Difficulty_btn_highlight();
        Quit_Game();
    }

    public void Credit_btn_Clicked()
    {
      
        button_clicked_sound();
        Credit_screen_anim.SetTrigger("credit_btn_pop_in");
    }
   
     public void How_to_play_btn_clicked()
    {
       
        button_clicked_sound();
        HowToplay_screen_anim.SetTrigger("HowToplay_btn_pop_in");
    }
    public void Settings_btn_Clicked()
    {
       
        button_clicked_sound();
        Setting_screen_anim.SetTrigger("setting_btn_pop_in");
    
    }

    public void Back_btn_clicked()
    {
      
        button_clicked_sound();
        Setting_screen_anim.SetTrigger("setting_btn_pop_out");
        HowToplay_screen_anim.SetTrigger("HowToplay_btn_pop_out");
        Credit_screen_anim.SetTrigger("credit_btn_pop_out");

    }
   
    public void Play_btn_clicked()
    {
        button_clicked_sound();
    if(PlayerPrefs.GetString("Difficulty_lvl", "Easy") =="Easy")
        { SceneManager.LoadScene(1); }
        if (PlayerPrefs.GetString("Difficulty_lvl", "Easy") == "Medium")
        { SceneManager.LoadScene(2); }
        if (PlayerPrefs.GetString("Difficulty_lvl", "Easy") == "Hard")
        { SceneManager.LoadScene(3); }
       
    }
public void button_clicked_sound()
    {
        button_audio.PlayOneShot(buttonClick_sound);
      
    }
    public void sound_on_clicked()
    {
        sound_on.SetActive(false);
        sound_off.SetActive(true);
          PlayerPrefs.SetInt("Menu_Sound", 0);
         Main_Menu_audio.Stop();
       

    }
    public void sound_off_clicked()
    {
        sound_on.SetActive(true);
        sound_off.SetActive(false);
           PlayerPrefs.SetInt("Menu_Sound", 1);

          Main_Menu_audio.Play();
    }
    public void Volume_set(float volume_value)
    {
        Main_Menu_audio.volume = volume_value;
        PlayerPrefs.SetFloat("Volume_Set", volume_value);
       
    }
   
    

  public void Difficulty_lvl()
    {
        PlayerPrefs.SetString("Difficulty_lvl", EventSystem.current.currentSelectedGameObject.name);
           Debug.Log(PlayerPrefs.GetString("Difficulty_lvl"));

    }
    public void Difficulty_btn_highlight()
    {
        if (PlayerPrefs.GetString("Difficulty_lvl", "Easy") == "Easy")
        {
            // Easy button color change
            ColorBlock colors = Easy_diff_btn.colors;
            colors.normalColor = Color.gray;
            colors.highlightedColor = Color.gray;
            colors.pressedColor = Color.gray;
             Easy_diff_btn.colors = colors;
            // Medium button color Reverse
            ColorBlock colors_M = Medium_diff_btn.colors;
            colors.normalColor = Color.white;
            colors.highlightedColor = Color.white;
            colors.pressedColor = Color.white;
            Medium_diff_btn.colors = colors;
            // Hard button color Reverse
            ColorBlock colors_H = Hard_diff_btn.colors;
            colors.normalColor = Color.white;
            colors.highlightedColor = Color.white;
            colors.pressedColor = Color.white;
            Hard_diff_btn.colors = colors;
        }
        if (PlayerPrefs.GetString("Difficulty_lvl", "Easy") == "Medium")
        {
            ColorBlock colors = Medium_diff_btn.colors;
            colors.normalColor = Color.gray;
            colors.highlightedColor = Color.gray;
            colors.pressedColor = Color.gray;
            Medium_diff_btn.colors = colors;
            // Easy button color Reverse
            ColorBlock colors_E = Easy_diff_btn.colors;
            colors.normalColor = Color.white;
            colors.highlightedColor = Color.white;
            colors.pressedColor = Color.white;
            Easy_diff_btn.colors = colors;
            // Hard button color Reverse
            ColorBlock colors_H = Hard_diff_btn.colors;
            colors.normalColor = Color.white;
            colors.highlightedColor = Color.white;
            colors.pressedColor = Color.white;
            Hard_diff_btn.colors = colors;
        }
        if (PlayerPrefs.GetString("Difficulty_lvl", "Easy") == "Hard")
        {
            ColorBlock colors = Hard_diff_btn.colors;
            colors.normalColor = Color.gray;
            colors.highlightedColor = Color.gray;
            colors.pressedColor = Color.gray;
           Hard_diff_btn.colors = colors;
            // Easy button color Reverse
            ColorBlock colors_E = Easy_diff_btn.colors;
            colors.normalColor = Color.white;
            colors.highlightedColor = Color.white;
            colors.pressedColor = Color.white;
            Easy_diff_btn.colors = colors;
            // Medium button color Reverse
            ColorBlock colors_M = Medium_diff_btn.colors;
            colors.normalColor = Color.white;
            colors.highlightedColor = Color.white;
            colors.pressedColor = Color.white;
            Medium_diff_btn.colors = colors;
        }
   
    }

    void Quit_Game()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            {
            Application.Quit();
        }
    }
}
