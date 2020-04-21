using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class BannerAds : MonoBehaviour
{
    public GameObject[] banner;
    private bool stop;
    private float startBanner = 0.5f;
    private void Update()
    {
        if (stop == false)
        {
            startBanner -= Time.deltaTime;
        }
        if (startBanner <= 0f) 
        {
            banner[Random.Range(0, 6)].SetActive(true);
            stop = true;
            startBanner = 5f;
        }

    }

}
