using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class SupportAdStart : MonoBehaviour
{
    public SupportAd SupportAd;
    public RewardedAd rewardedAd;
    private InterstitialAd interstitialAd;
    //public MenuButtons mb;
    public bool letsGo;
    public int numberScenes2;
    public float HME;

    private string interstitialAdUnitId = "ca-app-pub-1713143637407054/4524905771";
    // Start is called before the first frame update
    void Start()
    {
        interstitialAd = new InterstitialAd(interstitialAdUnitId);
        LoadRewardedAd();
        //this.rewardedAd = new RewardedAd("ca-app-pub-1713143637407054/6893688869");
        this.interstitialAd.OnAdClosed += HandleOnAdClosed;
        //rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        //AdRequest request = new AdRequest.Builder().Build();
        AdRequest adRequest = new AdRequest.Builder().Build();
        //this.rewardedAd.LoadAd(request);
        interstitialAd.LoadAd(adRequest);
        // Create an empty ad request.

        // Load the rewarded ad with the request.


    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShowIntAd(int numberScenes)
    {
        numberScenes2 = numberScenes;
        // if (interstitialAd.IsLoaded())
        // {
        //     interstitialAd.Show();
        // }
        // else
        // {
            PlayerPrefs.SetFloat("Loading", numberScenes);
            SceneManager.LoadScene(7);
        // }
    }
    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        PlayerPrefs.SetFloat("Loading", numberScenes2);
        SceneManager.LoadScene(7);
    }
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        HME = PlayerPrefs.GetFloat("HmEatAll") + 5;
        LoadRewardedAd();
        PlayerPrefs.SetFloat("HmEatAll", HME);
        Debug.Log("Lol");
    }
    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        LoadRewardedAd();
        Debug.Log("Lol");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        LoadRewardedAd();
        Debug.Log("Lol");
    }

    public void LoadRewardedAd()
    {
        if (SupportAd != null)
        {
            this.rewardedAd = new RewardedAd("ca-app-pub-1713143637407054/6893688869");
            this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
            this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
            rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
            AdRequest request = new AdRequest.Builder().Build();
            this.rewardedAd.LoadAd(request);

        }
        
    }
}

