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
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = transform.position.z - Camera.main.transform.position.z;
            transform.position = Camera.main.ScreenToWorldPoint(pos);

        }

        if (Input.GetMouseButtonUp(0))
        {
            if (openWindow == true) { CloseTurretWindow(); }
            if(openWindow == true) { CloseUpgradeWindow(); }
            openWindow = true;
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

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Turret1Check" && upgradingTurretsBool == false)
        {
            turretScript = collider.gameObject.GetComponentInParent<Turret>();

            //openWindow = true;
            UpgradingTurretsObjects[0] = turretScript.upgradeButtons[0];
            UpgradingTurretsObjects[0].SetActive(true);
            UpgradingTurretsObjects[1].SetActive(true);

            upgradingTurretsBool = true;

        }

        //using turret2check so the range collider doesnt trigger
        if (collider.gameObject.name == "Turret2Check" && upgradingTurretsBool == false)
        {
            turret2Script = collider.gameObject.GetComponentInParent<Turret2>();

            UpgradingTurretsObjects[2] = turret2Script.upgradeWindows[0];

            //openWindow = true;

            UpgradingTurretsObjects[2].SetActive(true);
            UpgradingTurretsObjects[3].SetActive(true);

            upgradingTurretsBool = true;
        }
        if (collider.gameObject.name == "Turret3Check" && upgradingTurretsBool == false)
        {
            turret3Script = collider.gameObject.GetComponentInParent<Turret3>();
            UpgradingTurretsObjects[4] = turret3Script.upgradeWindows;

            //openWindow = true;

            UpgradingTurretsObjects[4].SetActive(true);
            UpgradingTurretsObjects[5].SetActive(true);

            upgradingTurretsBool = true;
        }

        if (collider.gameObject.tag == "TurretZone" && gC.purchaseTurretWindow == false) 
        {
            buyingTurretScript = collider.gameObject.GetComponent<BuyingTurret>();
            if (buyingTurretScript.turretSpawned == false)
            {
                purchaseTurretButtons[0] = buyingTurretScript.purchaseTurretsButton[0];
                purchaseTurretButtons[0].SetActive(true);
                purchaseTurretButtons[1].SetActive(true);

                //openWindow = true;

                gC.purchaseTurretWindow = true;
            }

        }

    }

    public void SpawnTurret1() 
    {
        openWindow = false;
        if (gC.cashMoney >= 150)
        {

            Instantiate(turrets[0], new Vector3(buyingTurretScript.transform.position.x, buyingTurretScript.transform.position.y, buyingTurretScript.transform.position.z -0.05f), Quaternion.identity);
            gC.cashMoney -= 150;
            purchaseTurretButtons[0].SetActive(false);
            purchaseTurretButtons[1].SetActive(false);
            gC.purchaseTurretWindow = false;
            buyingTurretScript.turretSpawned = true;
        }
    }

    public void SpawnTurret2() 
    {
        openWindow = false;
        if (gC.cashMoney >= 300) 
        {
            Instantiate(turrets[1], new Vector3(buyingTurretScript.transform.position.x, buyingTurretScript.transform.position.y, buyingTurretScript.transform.position.z - 0.05f), Quaternion.identity);
            gC.cashMoney -= 300;
            purchaseTurretButtons[0].SetActive(false);
            purchaseTurretButtons[1].SetActive(false);
            gC.purchaseTurretWindow = false;
            buyingTurretScript.turretSpawned = true;
        }
    }

    public void SpawnTurret3()
    {
        openWindow = false;
        if (gC.cashMoney >= 500) 
        {
            Instantiate(turrets[2], new Vector3(buyingTurretScript.transform.position.x, buyingTurretScript.transform.position.y, buyingTurretScript.transform.position.z - 0.05f), Quaternion.identity);
            gC.cashMoney -= 500;
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
        }
        UpgradingTurretsObjects[1].SetActive(false);
        if (UpgradingTurretsObjects[2]) 
        {

            UpgradingTurretsObjects[2].SetActive(false);
        }
        UpgradingTurretsObjects[3].SetActive(false);
        if (UpgradingTurretsObjects[4]) 
        {
            UpgradingTurretsObjects[4].SetActive(false);
        }
        UpgradingTurretsObjects[5].SetActive(false);
        upgradingTurretsBool = false;
    }

    public void IncreaseTurret1Damage()
    {
        openWindow = false;
        if (gC.cashMoney >= turretScript.damageIncreaseCost)
        {
            
            turretScript.IncreaseDamage();
            
        }
    }

    public void IncreaseTurret1Range() 
    {
        openWindow = false;
        if (gC.cashMoney >= turretScript.rangeIncreaseCost) 
        {
            turretScript.IncreaseRange();
            
        }
    }

    public void DestroyTurret1() 
    {
        gC.cashMoney += turretScript.sellTurret;
        CloseUpgradeWindow();
        upgradingTurretsBool = false;
        buyingTurretScript.turretSpawned = false;
        Destroy(turretScript.gameObject);
    }

    public void IncreaseTurret2Damage() 
    {

        openWindow = false;
        if (gC.cashMoney >= turret2Script.upgradeDamage) 
        {
            turret2Script.UpgradeDamage();
            
        }
    }

    public void IncreaseTurret2Range() 
    {

        openWindow = false;
        if (gC.cashMoney >= turret2Script.upgradeRange) 
        {
            turret2Script.UpgradeRange();
            
        }
    }

    public void DestroyTurret2() 
    {
        gC.cashMoney += turret2Script.sellTurret;
        CloseUpgradeWindow();
        upgradingTurretsBool = false;
        buyingTurretScript.turretSpawned = false;
        Destroy(turret2Script.gameObject);
    }

    public void DestroyTurret3()
    {
        gC.cashMoney += 250;
        CloseUpgradeWindow();
        upgradingTurretsBool = false;
        buyingTurretScript.turretSpawned = false;
        Destroy(turret3Script.gameObject);
    }

}
