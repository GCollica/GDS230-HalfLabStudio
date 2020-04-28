using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEditor;

public class GameController : MonoBehaviour
{
    public int health = 10;
    public AudioSource source;
    public AudioClip[] clips;
    public SpriteRenderer healthSprite;
    public Animator healthAnim;
    public Color32 green;
    public Color32 orange;
    public Color32 red;

    public GameObject watchAd;
    public GameObject gameOver;

    public GameObject enemyPlacer;
    public Vector3 mouse;
    public Text researchText;
    public int researchPoints;
    public GameObject turret1;
    public Transform[] waypoints;
    public bool upgradeWindow = false;
    public bool purchaseTurretWindow = false;

    public GameObject enemyParent;

    public GameObject WinButtons;
    public GameObject pause;
    
    //canMove sets the speed for the enemies to 0, and pauses their spawning in the AdvancedWaveSpawner
    //pausing is done this way so the buttons can still operate in runtime
    public bool canMove = true;
    public bool endingAddMoney = true;

    public GameObject loseObjects;

    //these two scripts are stored for the end game scenario
    public AdvancedWaveSpawner spawner;
    public ButtonScript bS;
    public CheckForEnemy checkForEnemyScript;

    public bool targetFirst;

    public GameObject bannerAdPlaceholder;

    public bool updateHealthAudio = true;

    public GameObject[] speedTimeButtons;
    
    // Start is called before the first frame update
    void Start()
    {
        mouse = new Vector3(transform.position.x, transform.position.y, 10);
        researchPoints = 375;
        health = 10;
        Time.timeScale = 1;
    }

    private void Update()
    {
        LoseState();
        
        
        
        researchText.text = researchPoints.ToString();

        if (health == Mathf.Clamp(health, 7, 10))
        {
            if (updateHealthAudio == true)
            {
                source.clip = clips[0];
                source.Play();
                updateHealthAudio = false;
            }
            healthSprite.color = green;
        }
        if (health == Mathf.Clamp(health, 4, 6))
        {
            if (updateHealthAudio == true)
            {
                source.clip = clips[1];
                source.Play();
                updateHealthAudio = false;
            }
            healthSprite.color = orange;
        }
        if (health == Mathf.Clamp(health, -1, 3))
        {
            healthSprite.color = red;   
        }
        if (health == 0) 
        {
            if (updateHealthAudio == true)
            {
                source.clip = clips[2];
                source.Play();
                updateHealthAudio = false;
            }
        }

    }

    public void SpeedUpGame1()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 2;
            speedTimeButtons[1].SetActive(true);
            speedTimeButtons[0].SetActive(false);

        }
    }
    public void SpeedUpGame2()
    {
        if (Time.timeScale == 2)
        {
            Time.timeScale = 3;
            speedTimeButtons[2].SetActive(true);
            speedTimeButtons[1].SetActive(false);

        }
    }
    public void SpeedUpGame3()
    {
        if (Time.timeScale == 3)
        {
            Time.timeScale = 1;
            speedTimeButtons[0].SetActive(true);
            speedTimeButtons[2].SetActive(false);

        }
    }

    void LoseState() 
    {
        if (health <= 0) 
        {
            healthAnim.SetBool("Lose", true);
            canMove = false;
            spawner.enabled = false;
            if (bS.openWindow == true) { bS.CloseTurretWindow(); }
            if (bS.openWindow == true) { bS.CloseUpgradeWindow(); }
            bS.gameObject.SetActive(false);
            loseObjects.SetActive(true);
           
        }
    }

    //public void StartAds() 
    //{
    //    if (Advertisement.IsReady("rewardedVideo")) 
    //    {
    //        var options = new ShowOptions { resultCallback = AdIsOver };
    //        Advertisement.Show("rewardedVideo", options);
    //    }
    //    if (!Advertisement.IsReady("rewardedVideo")) 
    //    {
    //        AdWatched();
    //    }
    //}

    //private void AdIsOver(ShowResult result) 
    //{
    //    switch (result) 
    //    {
    //        case ShowResult.Finished:
    //            Debug.Log("The Ad is over!");
    //            AdWatched();
    //            break;
    //        case ShowResult.Skipped:
    //            Debug.Log("The Ad is Skipped!");
    //            break;
    //        case ShowResult.Failed:
    //            Debug.Log("The Ad was not shown!");
    //            break;
    //    }
    //}

    public void PauseGame() 
    {
     
        bS.gameObject.SetActive(false);
        if (bS.openWindow == true) { bS.CloseTurretWindow(); }
        if (bS.openWindow == true) { bS.CloseUpgradeWindow(); }
        pause.SetActive(true);
        canMove = false;
        bannerAdPlaceholder.SetActive(true);
    }

    public void UnPauseGame() 
    {
        
        bS.gameObject.SetActive(true);
        pause.SetActive(false);
        canMove = true;
        bannerAdPlaceholder.SetActive(false);
    }

    public void AdWatched()
    {
        updateHealthAudio = true;
        healthAnim.SetBool("Lose", false);
        health += 5;
        canMove = true;
        spawner.waveIndex -= 1;
        spawner.enabled = true;
        bS.gameObject.SetActive(true);
        loseObjects.SetActive(false);
        watchAd.SetActive(false);
        gameOver.transform.position += new Vector3(2.5f, 0, 0);
        foreach (Transform child in enemyParent.transform) 
        {
            GameObject.Destroy(child.gameObject);
        }
        spawner.ResetEnemiesAlive();
        
    }

    public void Win() 
    {

        WinButtons.SetActive(true);
        if (bS.openWindow == true) { bS.CloseTurretWindow(); }
        if (bS.openWindow == true) { bS.CloseUpgradeWindow(); }
        bS.gameObject.SetActive(false);
        spawner.enabled = false;
        EndingHealthIncrease();
        
    }

    void EndingHealthIncrease()
    {
        if (endingAddMoney == true) 
        {
            if (health == 1) { researchPoints += 500; }
            if (health == 2) { researchPoints += 1000; }
            if (health == 3) { researchPoints += 1500; }
            if (health == 4) { researchPoints += 2000; }
            if (health == 5) { researchPoints += 2500; }
            if (health == 6) { researchPoints += 3000; }
            if (health == 7) { researchPoints += 3500; }
            if (health == 8) { researchPoints += 4000; }
            if (health == 9) { researchPoints += 4500; }
            if (health == 10) { researchPoints += 5000; }
            endingAddMoney = false;
        }
    }

   


}
