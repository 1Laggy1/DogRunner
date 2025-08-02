using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class SupportAd : MonoBehaviour
{
    
    public float HME;
    public GameObject ErrorText;
    public SupportAdStart sas;

    void Start()
    {
       // MobileAds.Initialize(appID);
    }
    public void OnClick()
    {

        
        if (sas.rewardedAd.IsLoaded())
        {
            sas.rewardedAd.Show();
        }
        else
        {
            ErrorText.GetComponent<UnityEngine.UI.Text>().text = "Ad not loaded";
        }

    }

    

}