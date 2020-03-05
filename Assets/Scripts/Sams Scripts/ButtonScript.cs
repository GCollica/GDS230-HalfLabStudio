using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    public Turret turretScript;
    public GameController gC;

    public float damage;

    public int sellAmount;

    public CapsuleCollider2D capCol;
    public CircleCollider2D cirCol;

    public int upgradeDamage;

    public int upgradeRange;

    public GameObject[] UpgradingTurretsObjects;

    public bool upgradingTurretsBool;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.name == "TurretCheck" && upgradingTurretsBool == false)
        {
            turretScript = collider.gameObject.GetComponentInParent<Turret>();
            damage = turretScript.damage;
            sellAmount = turretScript.sellTurret;
            upgradeDamage = turretScript.damageIncreaseCost;
            upgradeRange = turretScript.rangeIncreaseCost;
            cirCol = turretScript.cC2D;
            UpgradingTurretsObjects[0] = turretScript.upgradeButtons[4];
            UpgradingTurretsObjects[0].SetActive(true);
            UpgradingTurretsObjects[1].SetActive(true);
            UpgradingTurretsObjects[2].SetActive(true);
            UpgradingTurretsObjects[3].SetActive(true);
            UpgradingTurretsObjects[4].SetActive(true);
            upgradingTurretsBool = true;

        }
    }


    public void CloseUpgradeWindow()
    {

        UpgradingTurretsObjects[0].SetActive(false);
        UpgradingTurretsObjects[1].SetActive(false);
        UpgradingTurretsObjects[2].SetActive(false);
        UpgradingTurretsObjects[3].SetActive(false);
        UpgradingTurretsObjects[4].SetActive(false);
        UpgradingTurretsObjects[5].SetActive(false);
        UpgradingTurretsObjects[6].SetActive(false);
        UpgradingTurretsObjects[7].SetActive(false);
        UpgradingTurretsObjects[8].SetActive(false);
        UpgradingTurretsObjects[9].SetActive(false);
        upgradingTurretsBool = false;
    }

    public void IncreaseTurret1Damage()
    {
        if (gC.cashMoney >= upgradeDamage)
        {
            turretScript.damage += 0.25f;
            gC.cashMoney -= upgradeDamage;
            upgradeDamage += 100;
            sellAmount += 5;
        }
    }
    

}
