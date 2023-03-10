using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl_select_audio_manager : MonoBehaviour
{
    public AudioClip btn_sound_clicked;
    public AudioSource btn_sound_audio_source;
   public void lvl_selection_btn_sound()
    {
        btn_sound_audio_source.PlayOneShot(btn_sound_clicked);
    }
}
