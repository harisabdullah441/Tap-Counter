using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donot_destroy_audio : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicobj = GameObject.FindGameObjectsWithTag("Menu_Audio");
        if(musicobj.Length>1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
