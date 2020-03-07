using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    
    public GameObject[] upgradeButtons;
    public Text[] upgradeText;

    public CircleCollider2D cC2D;
    public int rangeIncreaseCost = 200;

    public GameController gC;

    public GameObject towerSpawnPoint;
    
    //the transform of the enemy within range
    public Transform enemy;

    public float damage = 0.75f;
    public int damageIncreaseCost = 100;

    public int sellTurret = 50;
    
    //the speed that the turret turns towards the enemy in range
    public float turnSpeed = 10f;

    


    // Start is called before the first frame update
    void Start()
    {
        
        gC = FindObjectOfType<GameController>();
      
        

    }

    // Update is called once per frame
   

    
    
    //only deal damage to enemy objects if they are your target
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //if enemy is not yet set, set it to the one that is currently inside your collider
            if (!enemy)
            {
                enemy = collision.gameObject.transform;
            }
            
           
            Turn();
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if enemy leaves your range stop targeting them
        if (collision.tag == "Enemy")
        {
            enemy = null;
        }
    }

    //follow the enemy target
    void Turn()
    {
        Vector2 direction = enemy.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
    }

    public void OpenUpgradeWindow()
    {
        if (gC.upgradeWindow == false)
        {
            upgradeButtons[0].SetActive(true);
            upgradeButtons[1].SetActive(true);
            upgradeButtons[2].SetActive(true);
            upgradeButtons[3].SetActive(true);
            upgradeButtons[4].SetActive(true);
            gC.upgradeWindow = true;
        }
        
    }
    public void CloseUpgradeWindow() 
    {
        upgradeButtons[0].SetActive(false);
        upgradeButtons[1].SetActive(false);
        upgradeButtons[2].SetActive(false);
        upgradeButtons[3].SetActive(false);
        upgradeButtons[4].SetActive(false);
        gC.upgradeWindow = false;
    }

    public void IncreaseDamage() 
    { 
            damage += 0.25f;
            gC.cashMoney -= damageIncreaseCost;
            damageIncreaseCost += 100;
            sellTurret += 5;
        
    }

    public void IncreaseRange() 
    {
        
            cC2D.radius += 0.05f;
            gC.cashMoney -= rangeIncreaseCost;
            rangeIncreaseCost += 200;
            sellTurret += 10;
        
    }

    public void DestroyTower() 
    {
        Instantiate(towerSpawnPoint, new Vector3(transform.position.x, transform.position.y, 40), Quaternion.identity);
        gC.cashMoney += sellTurret;
        Destroy(upgradeButtons[0]);
        Destroy(upgradeButtons[1]);
        Destroy(upgradeButtons[2]);
        Destroy(upgradeButtons[3]);
        gC.upgradeWindow = false;
        Destroy(gameObject);
    }

    

}
