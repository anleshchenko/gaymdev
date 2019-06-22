using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    private AudioSource[] music;
    
    void Start()
    {
        music = GetComponents<AudioSource>();
        if (PlayerPrefs.GetInt("music") == 0)
            foreach (var mus in music)
            {
                mus.mute = true;
            }
        else
            foreach (var mus in music)
            {
                mus.mute = false;
            }
    }
}
