using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gameplay_mechanics : MonoBehaviour
{
    public Gameplay_UI gameplay_ui;
   // public Main_Manu_UI main_menu_ui;
   public int tapcountvalue = 0;
    public float lvl_time;
   // public float startingTime=10f;
    public int high_score=0;
    public bool CountdownEnded;
    public float CountDown;
    private bool TimerEnded;
    public bool hasWon;
   string current_lvl;
    public int lvl_target;
   public int current_lvl_number;
   // int temp_easy;
    private void Start()
    {
        CountDown = 3;

        current_lvl = PlayerPrefs.GetString("btn_name_info", "1");
      if(PlayerPrefs.GetString("Difficulty_lvl")=="Easy")
        { Easy_Level_Details(); }
        if (PlayerPrefs.GetString("Difficulty_lvl") == "Medium")
        { Medium_Level_Details(); }
        if (PlayerPrefs.GetString("Difficulty_lvl") == "Hard")
        { Hard_Level_Details(); }

    }

    private void Update()
    {
        
        CountDown -= Time.deltaTime;

        if (!CountdownEnded)
        {
            if (CountDown <= 0)
            {
                CountdownEnded = true;
                if (PlayerPrefs.GetInt("Menu_Sound") == 1)
                { gameplay_ui.gameplay_audio.Play(); }
                else { gameplay_ui.gameplay_audio.Stop(); }

            }
            else
            {
                CountdownEnded = false;
            }
           
        }
        if (CountdownEnded)
        {
            if (!TimerEnded)
            {
                lvl_time -= Time.deltaTime;
                if (lvl_time > 0)
                {
                    if (Input.GetMouseButtonDown(0) && !gameplay_ui.isPaused)
                    {
                        tapcountvalue++;
                        gameplay_ui.tapcount_text();
                        gameplay_ui.tap_audio_play();
                     
                       
                    }
                }
                if (lvl_time <= 0)
                {
                    TimerEnded = true;
                    lvl_time = 0f;

                    if (tapcountvalue > lvl_target)
                    {
                        if (PlayerPrefs.GetString("Difficulty_lvl") == "Easy")
                        {
                          
                         if(current_lvl_number== PlayerPrefs.GetInt("Current_Level_Easy",1))
                            { PlayerPrefs.SetInt("Current_Level_Easy", PlayerPrefs.GetInt("Current_Level_Easy",1) + 1); }
                        }
                        if (PlayerPrefs.GetString("Difficulty_lvl") == "Medium")
                        {
                            if(current_lvl_number== PlayerPrefs.GetInt("Current_Level_Medium",1))
                            { PlayerPrefs.SetInt("Current_Level_Medium", PlayerPrefs.GetInt("Current_Level_Medium",1) + 1); }
                           
                         
                        }
                        if (PlayerPrefs.GetString("Difficulty_lvl") == "Hard")
                        {
                            if(current_lvl_number== PlayerPrefs.GetInt("Current_Level_Hard",1))
                            {
                                PlayerPrefs.SetInt("Current_Level_Hard", PlayerPrefs.GetInt("Current_Level_Hard",1) + 1);
                            }

                        }

                        hasWon = true;
                    }
                    if (tapcountvalue < lvl_target)
                    {
                        hasWon = false;
                    }
                    gameplay_ui.Show_Win_Lose_Screen();

                    gameplay_ui.High_Score_Text();
                    gameplay_ui.pause_btn.SetActive(false);
                }
               
            }
            else
            {
                gameplay_ui.gameplay_audio.Stop();
            }
        }
    }
  


    public void Easy_Level_Details()
    {
        switch(current_lvl)
        {
            case "1":
                lvl_target = 20;
                lvl_time = 5;
                current_lvl_number = 1;
                Debug.Log("easy_details_method_01");
                break;
            case "2":
                lvl_target = 40;
                lvl_time = 10;
                current_lvl_number = 2;
                break;
            case "3":
                lvl_target = 60;
                lvl_time = 15;
                current_lvl_number = 3;
                break;
            case "4":
                lvl_target = 80;
                lvl_time = 20;
                current_lvl_number = 4;
                break;
            case "5":
                lvl_target = 100;
                lvl_time = 25;
                current_lvl_number = 5;
                break;
            case "6":
                lvl_target = 120;
                lvl_time = 30;
                current_lvl_number = 6;
                break;
            case "7":
                lvl_target = 140;
                lvl_time = 35;
                current_lvl_number = 7;
                break;
            case "8":
                lvl_target = 160;
                lvl_time = 40;
                current_lvl_number = 8;
                break;
            case "9":
                lvl_target = 180;
                lvl_time = 45;
                current_lvl_number = 9;
                break;
            case "10":
                lvl_target = 200;
                lvl_time = 50;
                current_lvl_number = 10;
                break;
            case "11":
                lvl_target = 220;
                lvl_time = 55;
                current_lvl_number = 11;
                break;
            case "12":
                lvl_target = 240;
                lvl_time = 60;
                current_lvl_number = 12;
                break;
            case "13":
                lvl_target = 260;
                lvl_time = 65;
                current_lvl_number = 13;
                break;
            case "14":
                lvl_target = 280;
                lvl_time = 70;
                current_lvl_number = 14;
                break;
            case "15":
                lvl_target = 300;
                lvl_time = 75;
                current_lvl_number = 15;
                break;

        }
    }
    public void Medium_Level_Details()
    {
        switch (current_lvl)
        {
            case "1":
                lvl_target = 30;
                lvl_time = 5;
                current_lvl_number = 1;
                break;
            case "2":
                lvl_target = 60;
                lvl_time = 10;
                current_lvl_number = 2;
                break;
            case "3":
                lvl_target = 90;
                lvl_time = 15;
                current_lvl_number = 3;
                break;
            case "4":
                lvl_target = 120;
                lvl_time = 20;
                current_lvl_number = 4;
                break;
            case "5":
                lvl_target = 150;
                lvl_time = 25;
                current_lvl_number = 5;
                break;
            case "6":
                lvl_target = 180;
                lvl_time = 30;
                current_lvl_number = 6;
                break;
            case "7":
                lvl_target = 210;
                lvl_time = 35;
                current_lvl_number = 7;
                break;
            case "8":
                lvl_target = 240;
                lvl_time = 40;
                current_lvl_number = 8;
                break;
            case "9":
                lvl_target = 270;
                lvl_time = 45;
                current_lvl_number = 9;
                break;
            case "10":
                lvl_target = 300;
                lvl_time = 50;
                current_lvl_number = 10;
                break;
            case "11":
                lvl_target = 330;
                lvl_time = 55;
                current_lvl_number = 11;
                break;
            case "12":
                lvl_target = 360;
                lvl_time = 60;
                current_lvl_number = 12;
                break;
            case "13":
                lvl_target = 390;
                lvl_time = 65;
                current_lvl_number = 13;
                break;
            case "14":
                lvl_target = 420;
                lvl_time = 70;
                current_lvl_number = 14;
                break;
            case "15":
                lvl_target = 450;
                lvl_time = 75;
                current_lvl_number = 15;
                break;

        }
    }
    public void Hard_Level_Details()
    {
        switch (current_lvl)
        {
            case "1":
                lvl_target = 40;
                lvl_time = 5;
                current_lvl_number = 1;
                break;
            case "2":
                lvl_target = 80;
                lvl_time = 10;
                current_lvl_number = 2;
                break;
            case "3":
                lvl_target = 120;
                lvl_time = 15;
                current_lvl_number = 3;
                break;
            case "4":
                lvl_target = 160;
                lvl_time = 20;
                current_lvl_number = 4;
                break;
            case "5":
                lvl_target = 200;
                lvl_time = 25;
                current_lvl_number = 5;
                break;
            case "6":
                lvl_target = 240;
                lvl_time = 30;
                current_lvl_number = 6;
                break;
            case "7":
                lvl_target = 280;
                lvl_time = 35;
                current_lvl_number = 7;
                break;
            case "8":
                lvl_target = 320;
                lvl_time = 40;
                current_lvl_number = 8;
                break;
            case "9":
                lvl_target = 360;
                lvl_time = 45;
                current_lvl_number = 9;
                break;
            case "10":
                lvl_target = 400;
                lvl_time = 50;
                current_lvl_number = 10;
                break;
            case "11":
                lvl_target = 440;
                lvl_time = 55;
                current_lvl_number = 11;
                break;
            case "12":
                lvl_target = 480;
                lvl_time = 60;
                current_lvl_number = 12;
                break;
            case "13":
                lvl_target = 520;
                lvl_time = 65;
                current_lvl_number = 13;
                break;
            case "14":
                lvl_target = 560;
                lvl_time = 70;
                current_lvl_number = 14;
                break;
            case "15":
                lvl_target = 600;
                lvl_time = 75;
                current_lvl_number = 15;
                break;

        }
    }
}
