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
    public int cashMoney;
    public GameObject turret1;
    public Transform[] waypoints;
    public bool upgradeWindow = false;
    public bool purchaseTurretWindow = false;
    public GameObject enemyParent;
    public GameObject enemyParentPrefab;
    public GameObject ePP;
    public GameObject WinButtons;
    public GameObject pause;

    public bool canMove = true;

    public GameObject loseObjects;

    


    //these two scripts are stored for the end game scenario
    public BasicWaveSpawner spawner;
    public ButtonScript bS;

    // Start is called before the first frame update
    void Start()
    {
        mouse = new Vector3(transform.position.x, transform.position.y, 10);
        cashMoney = 400;
        health = 10;
    }

    private void Update()
    {
        LoseState();

        healthText.text = "Health: " + health;
        researchText.text = "Research Points: " + cashMoney;
    }

    void LoseState() 
    {
        if (health <= 0) 
        {
            enemyParent.SetActive(false);
            spawner.gameObject.SetActive(false);
            bS.gameObject.SetActive(false);
            loseObjects.SetActive(true);
            
        }
    }

    public void PauseGame() 
    {
        //enemyParent.SetActive(false);
        spawner.gameObject.SetActive(false);
        bS.gameObject.SetActive(false);
        pause.SetActive(true);
        canMove = false;
    }

    public void UnPauseGame() 
    {
        //enemyParent.SetActive(true);
        spawner.gameObject.SetActive(true);
        bS.gameObject.SetActive(true);
        pause.SetActive(false);
        canMove = true;
    }

    public void AdWatched()
    {
        health += 5;
        enemyParent.SetActive(true);
        spawner.gameObject.SetActive(true);
        bS.gameObject.SetActive(true);
        loseObjects.SetActive(false);
    }

    public void Win() 
    {
        WinButtons.SetActive(true);
        bS.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
    }

   


}
