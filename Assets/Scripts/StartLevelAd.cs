using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class StartLevelAd : MonoBehaviour
{

    private InterstitialAd interstitialAd;

    private string interstitialAdUnitId = "ca-app-pub-1713143637407054/4524905771";


    private void OnEnable()
    {
        interstitialAd = new InterstitialAd(interstitialAdUnitId);
        AdRequest adRequest = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(adRequest);
    }

    public void ShowAd()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        if (interstitialAd.IsLoaded())
            interstitialAd.Show();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
