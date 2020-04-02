using System.Collections;
using System.Collections.Generic;
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
    
    
   
   

    // Update is called once per frame
    void Update()
    {
        OnClickEvent();

    }

    public void OnClickEvent()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = transform.position.z - Camera.main.transform.position.z;
            transform.position = Camera.main.ScreenToWorldPoint(pos);
            
        }

        
        

        if (turretScript) 
        { 
            upgradesText[0].text = "Upgrade Damage - " + turretScript.damageIncreaseCost + " Research Points";
            upgradesText[1].text = "Upgrade Range  - " + turretScript.rangeIncreaseCost + " Research Points";
            upgradesText[2].text = "Destroy Tower   + " + turretScript.sellTurret + " Research Points";
        }

        if (turret2Script) 
        {
            upgradesText[3].text = "Upgrade Damage - " + turret2Script.upgradeDamage + " Research Points";
            upgradesText[4].text = "Upgrade Range - " + turret2Script.upgradeRange + " Research Points";
            upgradesText[5].text = "Destroy Tower + " + turret2Script.sellTurret + " Research Points";
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
        if (collision.gameObject.name == "Turret3Check" && upgradingTurretsBool == false)
        {
            turret3Script = collision.gameObject.GetComponentInParent<Turret3>();
            UpgradingTurretsObjects[6] = turret3Script.upgradeWindows[0];
            openWindow = true;

            UpgradingTurretsObjects[6].SetActive(true);
       
            UpgradingTurretsObjects[7].SetActive(true);

            upgradingTurretsBool = true;
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
        if (collision.gameObject.name == "Turret1Check")
        {
            if (openWindow == true) CloseTurretWindow();
            if (openWindow == true) CloseUpgradeWindow();

        }
        if (collision.gameObject.name == "Turret2Check")
        {
            if (openWindow == true) CloseTurretWindow();
            if (openWindow == true) CloseUpgradeWindow();

        }
        if (collision.gameObject.name == "Turret3Check")
        {
            if (openWindow == true) CloseTurretWindow();
            if (openWindow == true) CloseUpgradeWindow();

        }
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
            openWindow = false;
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
            openWindow = false;
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
        
        if (gC.researchPoints >= 750) 
        {
            openWindow = false;
            Instantiate(turrets[2], new Vector3(buyingTurretScript.transform.position.x, buyingTurretScript.transform.position.y, buyingTurretScript.transform.position.z - 0.05f), Quaternion.identity);
            gC.researchPoints -= 750;
            purchaseTurretButtons[0].SetActive(false);
            purchaseTurretButtons[1].SetActive(false);
            gC.purchaseTurretWindow = false;
            buyingTurretScript.turretSpawned = true;
        }
    }

    public void CloseTurretWindow() 
    {
        purchaseTurretButtons[0].SetActive(false);
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
           // UpgradingTurretsObjects[7].SetActive(false);
        }
        UpgradingTurretsObjects[7].SetActive(false);
        upgradingTurretsBool = false;
        
    }

    public void IncreaseTurret1Damage()
    {
        
        if (gC.researchPoints >= turretScript.damageIncreaseCost && turretScript.damageUpgradedAmount <= 4)
        {
            openWindow = false;
            turretScript.IncreaseDamage();

        }
        if (gC.researchPoints <= turretScript.damageIncreaseCost) { openWindow = true; }
    }

    public void IncreaseTurret1Range() 
    {
      
        if (gC.researchPoints >= turretScript.rangeIncreaseCost && turretScript.rangeUpgradedAmount <= 3) 
        {
            openWindow = false;
            turretScript.IncreaseRange();

        }
        if (gC.researchPoints <= turretScript.rangeIncreaseCost) { openWindow = true; }
    }

    public void DestroyTurret1() 
    {
        gC.researchPoints += turretScript.sellTurret;
        CloseUpgradeWindow();
        upgradingTurretsBool = false;
        buyingTurretScript.turretSpawned = false;
        Destroy(turretScript.gameObject);
    }

    public void IncreaseTurret2Damage() 
    {

        
        if (gC.researchPoints >= turret2Script.upgradeDamage && turret2Script.damageUpgradedTimes <= 2) 
        {
            turret2Script.UpgradeDamage();
            openWindow = false;
        }

        if (gC.researchPoints <= turret2Script.upgradeDamage) { openWindow = true; }
    }

    public void IncreaseTurret2Range() 
    {

        if (gC.researchPoints >= turret2Script.upgradeRange && turret2Script.rangeUpgradedTimes <= 3) 
        {
            openWindow = false;
            turret2Script.UpgradeRange();
            
        }
        if (gC.researchPoints <= turret2Script.upgradeRange) { openWindow = true; }
    }

    public void DestroyTurret2() 
    {
        gC.researchPoints += turret2Script.sellTurret;
        CloseUpgradeWindow();
        upgradingTurretsBool = false;
        buyingTurretScript.turretSpawned = false;
        Destroy(turret2Script.gameObject);
    }

    public void DestroyTurret3()
    {
        gC.researchPoints += 250;
        CloseUpgradeWindow();
        upgradingTurretsBool = false;
        buyingTurretScript.turretSpawned = false;
        Destroy(turret3Script.gameObject);
    }

}
