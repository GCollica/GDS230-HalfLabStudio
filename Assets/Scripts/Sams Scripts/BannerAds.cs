using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Advertisements;
public class BannerAds : MonoBehaviour
{
    public string gameId = "1234567";
    public string placementId = "BannerAd";
    public bool testMode = true;
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        
        
    }

    

    private void Update()
    {
        if (Advertisement.IsReady("BannerAd"))
        {
            Advertisement.Show("BannerAd");
        }
    }

}
