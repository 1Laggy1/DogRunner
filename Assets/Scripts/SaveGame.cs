using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using GooglePlayGames;
// using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour
{
    public float timelvl6;
    public float timelvl5;
    public float timelvl4;
    public float timelvl3;
    public float timelvl1;
    public float timelvl2;
    public int timelvl4int;
    public int timelvl3int;
    public int timelvl1int;
    public int timelvl2int;
    public float Attemptslvl6;
    public float Attemptslvl5;
    public float Attemptslvl4;
    public float Attemptslvl3;
    public float Attemptslvl1;
    public float Attemptslvl2;
    public float HmEatAll;
    private const string leaderBoard = "CgkIi_i6mNECEAIQBQ";
    private const string leaderBoard2 = "CgkIi_i6mNECEAIQBg";
    private const string leaderBoard3 = "CgkIi_i6mNECEAIQBw";
    //private const string leaderBoard4 = "CgkIi_i6mNECEAIQBw";
    private const string achiv = "CgkIi_i6mNECEAIQBA";
    //public float tutorial = 0;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();

        //tutorial = PlayerPrefs.GetFloat("tutorial");
        //timelvl4 = PlayerPrefs.GetFloat("timelvl4") * 1000;
        timelvl6 = PlayerPrefs.GetFloat("timelvl5") * 1000;
        timelvl5 = PlayerPrefs.GetFloat("timelvl5") * 1000;
        timelvl4 = PlayerPrefs.GetFloat("timelvl4") * 1000;
        timelvl3 = PlayerPrefs.GetFloat("timelvl3") * 1000;
        timelvl2 = PlayerPrefs.GetFloat("timelvl2") * 1000;
        timelvl1 = PlayerPrefs.GetFloat("timelvl1") * 1000;
        //timelvl4int = (int)timelvl4;
        timelvl3int = (int)timelvl3;
        timelvl2int = (int)timelvl2;
        timelvl1int = (int)timelvl1;
        Debug.Log(timelvl3int + "int");
        Debug.Log(PlayerPrefs.GetFloat("timelvl1"));
        // PlayGamesPlatform.DebugLogEnabled = true;
        // PlayGamesPlatform.Activate();
        if (SceneManager.GetActiveScene().name == "_Menu")
        {
            Social.localUser.Authenticate(success =>
            {

                if (success)
                {

                }
                else
                {

                }

            });
        }
        

        if (timelvl1int != 0)
        {
            Social.ReportScore(timelvl1int, leaderBoard, (bool success) => { });
        }
        if (timelvl2int != 0)
        {
            Social.ReportScore(timelvl2int, leaderBoard2, (bool success) => { });
        }
        if (timelvl3int != 0)
        {
            Social.ReportScore(timelvl3int, leaderBoard3, (bool success) => { });
        }
        //if (timelvl4int != 0)
        //{
        //    Social.ReportScore(timelvl4int, leaderBoard4, (bool success) => { });
        //}

        if (timelvl1int <= 1000)
        {
            Social.ReportProgress(achiv, 100.0f, (bool success) => { });
        }

    }

    // Update is called once per frame
    void Update()
    {
        HmEatAll = PlayerPrefs.GetFloat("HmEatAll");
    }

    public void ShowLeaderBoard()
    {
        Social.ShowLeaderboardUI();
    }

    public void ExitFromGPS()
    {
        //PlayGamesPlatform.Instance.SignOut();
        Application.Quit();
    }

}
