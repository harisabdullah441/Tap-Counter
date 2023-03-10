using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_pop_out_anim : MonoBehaviour
{
    public GameObject Main_Screen;
    public GameObject Current_Screen;

    public void Main_menu_pop_out_anim_method()
    {
        Current_Screen.SetActive(false);
        Main_Screen.SetActive(true);
    }


}
