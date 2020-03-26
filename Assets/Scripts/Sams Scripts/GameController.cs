using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int health = 10;
    public Text healthText;

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
    
    //canMove sets the speed for the enemies to 0, and pauses their spawning in the BasicWaveSpawner
    public bool canMove = true;
    public bool endingAddMoney = true;

    public GameObject loseObjects;

    //these two scripts are stored for the end game scenario
    public BasicWaveSpawner spawner;
    public ButtonScript bS;

    public bool targetFirst;




    // Start is called before the first frame update
    void Start()
    {
        mouse = new Vector3(transform.position.x, transform.position.y, 10);
        researchPoints = 400;
        health = 10;
    }

    private void Update()
    {
        LoseState();

        healthText.text = "Health: " + health;
        researchText.text = "Research Points: " + researchPoints;
    }

    void LoseState() 
    {
        if (health <= 0) 
        {
            canMove = false;
            spawner.gameObject.SetActive(false);
            if (bS.openWindow == true) { bS.CloseTurretWindow(); }
            if (bS.openWindow == true) { bS.CloseUpgradeWindow(); }
            bS.gameObject.SetActive(false);
            loseObjects.SetActive(true);
            
        }
    }

    public void PauseGame() 
    {
     
        bS.gameObject.SetActive(false);
        if (bS.openWindow == true) { bS.CloseTurretWindow(); }
        if (bS.openWindow == true) { bS.CloseUpgradeWindow(); }
        pause.SetActive(true);
        canMove = false;
    }

    public void UnPauseGame() 
    {
        
        bS.gameObject.SetActive(true);
        pause.SetActive(false);
        canMove = true;
    }

    public void AdWatched()
    {
        health += 5;
        canMove = true;
        spawner.waveIndex -= 1;
        spawner.gameObject.SetActive(true);
        bS.gameObject.SetActive(true);
        loseObjects.SetActive(false);
    }

    public void Win() 
    {

        WinButtons.SetActive(true);
        if (bS.openWindow == true) { bS.CloseTurretWindow(); }
        if (bS.openWindow == true) { bS.CloseUpgradeWindow(); }
        bS.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
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
