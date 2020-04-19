using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class BannerAds : MonoBehaviour
{
    public string gameID = "1234567";
    public string placementID = "bannerPlacement";
    public bool testMode = true;

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameID, testMode);
        StartCoroutine(ShowBannerWhenReady());
    }

    IEnumerator ShowBannerWhenReady() 
    {
        while (!Advertisement.IsReady(placementID)) 
        {
            yield return new WaitForSeconds(0.5f);
        }
        //Advertisement.Banner.Show(placementID);
    }

    
}
