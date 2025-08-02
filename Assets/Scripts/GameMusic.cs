using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    public float MusicWork;
    
    public PlayerMovement pm;
    void Start ()
    {
        MusicWork = PlayerPrefs.GetFloat("MusicWork");


    }


    void Update()
    {
        if ((MusicWork == 1) && (pm.MusicStart == true))
        {
            GetComponent<AudioSource>().enabled = true;

        }
        else if ((MusicWork == 0) && (pm.MusicStart == true))
        {
            GetComponent<AudioSource>().enabled = false;
        }
        else if ((MusicWork == null) && (pm.MusicStart == true))
        {
            GetComponent<AudioSource>().enabled = true;
        }
    }
    
}
