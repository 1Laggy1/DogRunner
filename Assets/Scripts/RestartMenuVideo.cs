using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartMenuVideo : MonoBehaviour
{
    private float timeToRestart;
    private float timeToRestartRound;
    private float video = 38;
    //public RestartMenuVideo VideoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        //VideoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        timeToRestart += Time.deltaTime;
        timeToRestartRound = Mathf.Round(timeToRestart);

        VideoMenuRestart();
    }

    void VideoMenuRestart()
    {
        if ((timeToRestartRound == video))
        {
            GetComponent<UnityEngine.Video.VideoPlayer>().enabled = false;
            GetComponent<UnityEngine.Video.VideoPlayer>().enabled = true;
            video = video + 38;
            //Music2 = Music + 1;
            Debug.Log("Video restarting");
        }
    }

}
