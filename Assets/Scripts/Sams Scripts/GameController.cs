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



    //these two scripts are stored for the end game scenario
    public BasicWaveSpawner spawner;
    public ButtonScript bS;

    // Start is called before the first frame update
    void Start()
    {
        mouse = new Vector3(transform.position.x, transform.position.y, 10);
        cashMoney = 4000000;
        health = 10000;
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
            Destroy(enemyParent);
            spawner.gameObject.SetActive(false);
            bS.gameObject.SetActive(false);
        }
    }

   

   


}
