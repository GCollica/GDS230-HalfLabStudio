using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{

    public Turret turretScript;
    public Turret2 turret2Script;
    public Turret3 turret3Script;

    public BuyingTurret buyingTurretScript;
    public GameController gC;

    public GameObject[] UpgradingTurretsObjects;
    public Text[] upgradesText;

    public GameObject[] purchaseTurretButtons;

    public GameObject[] turrets;

    public bool upgradingTurretsBool;

    public bool openWindow;
    public float windowTimer = 0.2f;

    //this bool helps to reset the buttonscript object so when the player taps the screen again the trigger is exiting
    public bool pauseMovement;
   
   

    // Update is called once per frame
    void Update()
    {
        if (pauseMovement == false)
        {
            OnClickEvent();

        }
        if (openWindow == false) 
        {
            windowTimer -= Time.deltaTime;
            if (windowTimer <= 0) { openWindow = true; windowTimer = 0.2f; }
        }

        if (turretScript)
        {
            if (turretScript.damageUpgradedAmount == 5)
            {
                upgradesText[0].text = " Upgrades at Max";
            }
            else 
            {
                upgradesText[0].text = "Upgrade Tower: - " + turretScript.damageIncreaseCost + " Research Points";
            }

            //     upgradesText[1].text = "Upgrade Range  - " + turretScript.rangeIncreaseCost + " Research Points";
            upgradesText[2].text = "Destroy Tower: + " + turretScript.sellTurret + " Research Points";
        }

        if (turret2Script)
        {
            if (turret2Script.damageUpgradedTimes == 3)
            {
                upgradesText[3].text = "Upgrades at Max";
            }
            else 
            {
                upgradesText[3].text = "Upgrade Tower: - " + turret2Script.upgradeDamage + " Research Points";
            }
          
      //      upgradesText[4].text = "Upgrade Range - " + turret2Script.upgradeRange + " Research Points";
            upgradesText[5].text = "Destroy Tower: + " + turret2Script.sellTurret + " Research Points";
        }

  

    }


    public void OnClickEvent()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = transform.position.z - Camera.main.transform.position.z;
            transform.position = Camera.main.ScreenToWorldPoint(pos);
            
        }
    }

    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Turret1Check" && upgradingTurretsBool == false)
        {
            turretScript = collision.gameObject.GetComponentInParent<Turret>();

            openWindow = true;
            UpgradingTurretsObjects[0] = turretScript.upgradeButtons[0];
            UpgradingTurretsObjects[1] = turretScript.upgradeButtons[1];
            UpgradingTurretsObjects[0].SetActive(true);
            UpgradingTurretsObjects[1].SetActive(true);
            UpgradingTurretsObjects[2].SetActive(true);

            upgradingTurretsBool = true;


        }

        // this if statement is only used to reset test to false so that OnClickEvent() starts being called again
        if (collision.gameObject.name == "Turret1Check") 
        {
            if (pauseMovement == true) { pauseMovement = false; }
        }

        //using turret2check so the range collider doesnt trigger
        if (collision.gameObject.name == "Turret2Check" && upgradingTurretsBool == false)
        {
            turret2Script = collision.gameObject.GetComponentInParent<Turret2>();

            UpgradingTurretsObjects[3] = turret2Script.upgradeWindows[0];
            UpgradingTurretsObjects[4] = turret2Script.upgradeWindows[1];
            openWindow = true;

            UpgradingTurretsObjects[3].SetActive(true);
            UpgradingTurretsObjects[4].SetActive(true);
            UpgradingTurretsObjects[5].SetActive(true);

            upgradingTurretsBool = true;
        }

        // this if statement is only used to reset test to false so that OnClickEvent() starts being called again
        if (collision.gameObject.name == "Turret2Check")
        {
            if (pauseMovement == true) { pauseMovement = false; }
        }

        if (collision.gameObject.name == "Turret3Check" && upgradingTurretsBool == false)
        {
            turret3Script = collision.gameObject.GetComponentInParent<Turret3>();
            UpgradingTurretsObjects[6] = turret3Script.upgradeWindows[0];
            UpgradingTurretsObjects[8] = turret3Script.upgradeWindows[1];
            openWindow = true;

            UpgradingTurretsObjects[6].SetActive(true);
       
            UpgradingTurretsObjects[7].SetActive(true);

            UpgradingTurretsObjects[8].SetActive(true);

            upgradingTurretsBool = true;
        }

        // this if statement is only used to reset test to false so that OnClickEvent() starts being called again
        if (collision.gameObject.name == "Turret3Check")
        {
            if (pauseMovement == true) { pauseMovement = false; }
        }

        if (collision.gameObject.tag == "TurretZone" && gC.purchaseTurretWindow == false)
        {
            buyingTurretScript = collision.gameObject.GetComponent<BuyingTurret>();
            if (buyingTurretScript.turretSpawned == false)
            {
                purchaseTurretButtons[0] = buyingTurretScript.purchaseTurretsButton[0];
                purchaseTurretButtons[0].SetActive(true);
                purchaseTurretButtons[1].SetActive(true);

                openWindow = true;

                gC.purchaseTurretWindow = true;
            }
        }
    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        //this if statement is used to close the turretWindow & the upgradeWindow so the player doesnt need to use the button
        if (collision.gameObject.name == "Turret1Check")
        {
            if (openWindow == true) CloseTurretWindow();
            if (openWindow == true) CloseUpgradeWindow();

        }
        
        //this if statement is used to close the turretWindow & the upgradeWindow so the player doesnt need to use the button
        if (collision.gameObject.name == "Turret2Check")
        {
            if (openWindow == true) CloseTurretWindow();
            if (openWindow == true) CloseUpgradeWindow();

        }

        //this if statement is used to close the turretWindow & the upgradeWindow so the player doesnt need to use the button
        if (collision.gameObject.name == "Turret3Check")
        {
            if (openWindow == true) CloseTurretWindow();
            if (openWindow == true) CloseUpgradeWindow();

        }

        //this if statement is used to close the turretWindow & the upgradeWindow so the player doesnt need to use the button
        if (collision.gameObject.tag == "TurretZone")
        {
             if (openWindow == true) CloseTurretWindow(); 
             if (openWindow == true) CloseUpgradeWindow(); 

        }

    }

    public void SpawnTurret1() 
    {
        
        if (gC.researchPoints >= 150)
        {
           
            Instantiate(turrets[0], new Vector3(buyingTurretScript.transform.position.x, buyingTurretScript.transform.position.y, buyingTurretScript.transform.position.z -0.05f), Quaternion.identity);
            gC.researchPoints -= 150;
            purchaseTurretButtons[0].SetActive(false);
            purchaseTurretButtons[1].SetActive(false);
            gC.purchaseTurretWindow = false;
            buyingTurretScript.turretSpawned = true;
        }
    }

    public void SpawnTurret2() 
    {
        
        if (gC.researchPoints >= 300) 
        {
         
            Instantiate(turrets[1], new Vector3(buyingTurretScript.transform.position.x, buyingTurretScript.transform.position.y, buyingTurretScript.transform.position.z - 0.05f), Quaternion.identity);
            gC.researchPoints -= 300;
            purchaseTurretButtons[0].SetActive(false);
            purchaseTurretButtons[1].SetActive(false);
            gC.purchaseTurretWindow = false;
            buyingTurretScript.turretSpawned = true;
        }
    }

    public void SpawnTurret3()
    {
        
        if (gC.researchPoints >= 225) 
        {
     
            Instantiate(turrets[2], new Vector3(buyingTurretScript.transform.position.x, buyingTurretScript.transform.position.y, buyingTurretScript.transform.position.z - 0.05f), Quaternion.identity);
            gC.researchPoints -= 225;
            purchaseTurretButtons[0].SetActive(false);
            purchaseTurretButtons[1].SetActive(false);
            gC.purchaseTurretWindow = false;
            buyingTurretScript.turretSpawned = true;
        }
    }

    public void CloseTurretWindow() 
    {
        if (purchaseTurretButtons[0]) {purchaseTurretButtons[0].SetActive(false); }

        purchaseTurretButtons[1].SetActive(false);
        gC.purchaseTurretWindow = false;
        
    }

    public void CloseUpgradeWindow()
    {
        if (UpgradingTurretsObjects[0]) 
        {
            UpgradingTurretsObjects[0].SetActive(false);
            UpgradingTurretsObjects[1].SetActive(false);
        }
        UpgradingTurretsObjects[2].SetActive(false);
        if (UpgradingTurretsObjects[3]) 
        {
            UpgradingTurretsObjects[3].SetActive(false);
            UpgradingTurretsObjects[4].SetActive(false);
        }
        UpgradingTurretsObjects[5].SetActive(false);
        if (UpgradingTurretsObjects[6]) 
        {
            UpgradingTurretsObjects[6].SetActive(false);
            UpgradingTurretsObjects[8].SetActive(false);
        }
        UpgradingTurretsObjects[7].SetActive(false);
        upgradingTurretsBool = false;
        
    }

    public void IncreaseTurret1Damage()
    {

        if (gC.researchPoints >= turretScript.damageIncreaseCost && turretScript.damageUpgradedAmount <= 4)
        {
            turretScript.IncreaseDamage();
            turretScript.IncreaseRange();
        }
        openWindow = false;
        pauseMovement = true;
        transform.position = turretScript.gameObject.transform.position;
    }

    public void IncreaseTurret1Range() 
    {
      
        if (gC.researchPoints >= turretScript.rangeIncreaseCost && turretScript.rangeUpgradedAmount <= 3) 
        {
            turretScript.IncreaseRange();
            
        }
        openWindow = false;
        pauseMovement = true;
        transform.position = turretScript.gameObject.transform.position;
    }

    public void DestroyTurret1() 
    {
        gC.researchPoints += turretScript.sellTurret;
        CloseUpgradeWindow();
        upgradingTurretsBool = false;
        buyingTurretScript.turretSpawned = false;
        Destroy(turretScript.rangeSprite.gameObject);
        Destroy(turretScript.gameObject);
    }

    public void IncreaseTurret2Damage() 
    {

        
        if (gC.researchPoints >= turret2Script.upgradeDamage && turret2Script.damageUpgradedTimes <= 2) 
        {
            turret2Script.UpgradeDamage();
            turret2Script.UpgradeRange();
        }
        openWindow = false;
        pauseMovement = true;
        transform.position = turret2Script.gameObject.transform.position;

    }

    public void IncreaseTurret2Range() 
    {

        if (gC.researchPoints >= turret2Script.upgradeRange && turret2Script.rangeUpgradedTimes <= 3) 
        {
            turret2Script.UpgradeRange();
        }
        openWindow = false;
        pauseMovement = true;
        transform.position = turret2Script.gameObject.transform.position;

    }

    public void DestroyTurret2() 
    {
        gC.researchPoints += turret2Script.sellTurret;
        CloseUpgradeWindow();
        upgradingTurretsBool = false;
        buyingTurretScript.turretSpawned = false;
        Destroy(turret2Script.gameObject);
        Destroy(turret2Script.rangeSprite.gameObject);
    }

    public void DestroyTurret3()
    {
        gC.researchPoints += 100;
        CloseUpgradeWindow();
        upgradingTurretsBool = false;
        buyingTurretScript.turretSpawned = false;
        Destroy(turret3Script.gameObject);
        Destroy(turret3Script.upgradeWindows[1]);
    }

}
