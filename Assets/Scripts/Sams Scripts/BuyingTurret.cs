using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyingTurret : MonoBehaviour
{
    public GameObject[] purchaseTurretsButton;
    public GameController gC;
    
    
    public GameObject[] turret;

    //reset the turret1 gameObject so you can spawn a new turret icon
    public bool newTurret;
    //bool to make sure you can only place on this turret placement
    public bool placeOnTurret = false;



    void Start()
    {
        
        gC = FindObjectOfType<GameController>();
        purchaseTurretsButton[0].transform.position = new Vector3(-7.5f, 4.3f, -1);
        purchaseTurretsButton[1].transform.position = new Vector3(-5f, 4.31f, -1);
        purchaseTurretsButton[2].transform.position = new Vector3(-2.5f, 4.31f, -1);
        purchaseTurretsButton[3].transform.position = new Vector3(0, 4.31f, -1);
    }

    void Update()
    {
        resetTurretTypes();
    }

    void resetTurretTypes() 
    {
        if (Input.GetMouseButtonUp(0)) 
        {
            newTurret = true;
        }
        if (newTurret == true) 
        {
            //turret1 = null;
            newTurret = false;
        }

    }

    //open the turret menu to purchase at one point
    public void OpenTurretMenu()
    {
        Debug.Log("test");
        if (gC.purchaseTurretWindow == false)
        {
            purchaseTurretsButton[0].SetActive(true);
            purchaseTurretsButton[1].SetActive(true);
            purchaseTurretsButton[2].SetActive(true);
            purchaseTurretsButton[3].SetActive(true);
            purchaseTurretsButton[4].SetActive(true);
            placeOnTurret = true;
            gC.purchaseTurretWindow = true;
        }
    }

    //spawn the turret type 1 to follow the player mouse/finger
    public void BuyTurret1()
    {
     

            Instantiate(turret[0], gameObject.transform.position, transform.rotation);
            gC.purchaseTurretWindow = false;
            gC.cashMoney -= 150;
            Destroy(gameObject);


            /*Instantiate(enemyPlacer, gameObject.transform.position + mouse, transform.rotation);
            turret1 = enemyPlacer;*/
            
    }
    

    public void BuyTurret2()
    {
        Instantiate(turret[1], gameObject.transform.position, transform.rotation);
        gC.purchaseTurretWindow = false;
        gC.cashMoney -= 400;
        Destroy(gameObject);
    }
    public void BuyTurret3()
    {
        Instantiate(turret[2], gameObject.transform.position, transform.rotation);
        gC.purchaseTurretWindow = false;
        gC.cashMoney -= 200;
        Destroy(gameObject);
    }
    public void CloseTurretMenu()
    {
        purchaseTurretsButton[0].SetActive(false);
        purchaseTurretsButton[1].SetActive(false);
        purchaseTurretsButton[2].SetActive(false);
        purchaseTurretsButton[3].SetActive(false);
        purchaseTurretsButton[4].SetActive(false);
        gC.purchaseTurretWindow = false;
        placeOnTurret = false;
    }

}
