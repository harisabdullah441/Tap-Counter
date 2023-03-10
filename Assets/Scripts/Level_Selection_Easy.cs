using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Level_Selection_Easy : MonoBehaviour
{
    public Button[] total_btn;
    int current_lvl;
    public AudioSource Audio;
    public AudioSource btn_audio;
    public AudioClip btn_audio_clip;
    void Start()
    {
        if (PlayerPrefs.GetInt("Menu_Sound", 1) == 1)
        { Audio.Play(); }
        if (PlayerPrefs.GetInt("Menu_Sound", 1) == 0)
        { Audio.Stop(); }
        Audio.volume = PlayerPrefs.GetFloat("Volume_Set", 0.4f);
        current_lvl = PlayerPrefs.GetInt("Current_Level_Easy", 1);
        //PlayerPrefs.DeleteKey("Current_Level_Easy");
        Debug.Log(current_lvl);
            for(int lvl = current_lvl; lvl>0;lvl--)
            {
                total_btn[lvl].interactable = true;
         
        }
        for (int lvl = current_lvl; lvl <total_btn.Length ; lvl++)
        {
            total_btn[lvl].interactable = false;
         
        }
    }

    public void btn_clicked_info()
    {
     SceneManager.LoadScene(4);
      
        PlayerPrefs.SetString("btn_name_info", EventSystem.current.currentSelectedGameObject.name) ;
        
    }
 
    public void back_btn_clicked()
    {
        SceneManager.LoadScene(0);
    }
    public void btn_clicked_audio()
    {
        btn_audio.PlayOneShot(btn_audio_clip);
    }
}
