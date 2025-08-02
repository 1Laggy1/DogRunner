using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicOnOffButton : MonoBehaviour
{
    public float MusicWork = 1;
    public AudioSource MenuMusic;
    public Sprite SpriteOn;
    public Sprite SpriteOff;
    public float firstTime;

    public void MusicWorkButton()
    {
        if (MusicWork == 1)
        {
            MusicWork = 0;
            GetComponent<UnityEngine.UI.Text>().text = "Music: Off";
            PlayerPrefs.SetFloat("MusicWork", MusicWork);
        }
        else if (MusicWork == 0)
        {
            MusicWork = 1;
            GetComponent<UnityEngine.UI.Text>().text = "Music: On";
            PlayerPrefs.SetFloat("MusicWork", MusicWork);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        firstTime = PlayerPrefs.GetFloat("firstTime");
        if (firstTime != 0)
        {
            MusicWork = PlayerPrefs.GetFloat("MusicWork");
        }
        else if (firstTime == 0)
        {
            MusicWork = 1;
            firstTime++;
            PlayerPrefs.SetFloat("firstTime", firstTime);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (MusicWork == 0)
        {
            GetComponent<UnityEngine.UI.Text>().text = "Music: Off";
            PlayerPrefs.SetFloat("MusicWork", MusicWork);
            GetComponentInParent<Image>().sprite = SpriteOff;
            MenuMusic.GetComponent<AudioSource>().enabled = false;
        }
        else if (MusicWork == 1)
        {
            GetComponent<UnityEngine.UI.Text>().text = "Music: On";
            PlayerPrefs.SetFloat("MusicWork", MusicWork);
            GetComponentInParent<Image>().sprite = SpriteOn;
            MenuMusic.GetComponent<AudioSource>().enabled = true;
        }

    }
}
