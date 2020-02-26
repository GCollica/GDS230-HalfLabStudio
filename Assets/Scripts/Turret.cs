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

  
    
    //the transform of the enemy within range
    public Transform enemy;

    public float damage = 0.75f;
    public int damageIncreaseCost = 100;

  
    
    //the speed that the turret turns towards the enemy in range
    public float turnSpeed = 10f;




    // Start is called before the first frame update
    void Start()
    {
        
        gC = FindObjectOfType<GameController>();
        //find main scene canvas
        upgradeButtons[5] = GameObject.Find("Canvas1");
        //unparent upgrade buttons from turret (so they dont follow rotation)
        upgradeButtons[0].transform.SetParent(null);
        upgradeButtons[1].transform.SetParent(null);
        upgradeButtons[2].transform.SetParent(null);
        upgradeButtons[3].transform.SetParent(null);
        //reparent upgrade buttons to main scene canvas
        upgradeButtons[0].transform.SetParent(upgradeButtons[5].transform);
        upgradeButtons[1].transform.SetParent(upgradeButtons[5].transform);
        upgradeButtons[2].transform.SetParent(upgradeButtons[5].transform);
        upgradeButtons[3].transform.SetParent(upgradeButtons[5].transform);
        //set upgrade buttons world location
        upgradeButtons[0].transform.position = new Vector3(3, 2.5f, -1);
        upgradeButtons[1].transform.position = new Vector3(6.5f, 2.5f, -1);
        upgradeButtons[2].transform.position = new Vector3(3, -1.4f, -1);
        upgradeButtons[3].transform.position = new Vector3(6.5f, -1.4f, -1);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
    
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
        if (gC.cashMoney >= damageIncreaseCost)
        {
            damage += 0.25f;
            gC.cashMoney -= damageIncreaseCost;
            damageIncreaseCost += 100;
        }
    }

    public void IncreaseRange() 
    {
        if (gC.cashMoney >= rangeIncreaseCost)
        {
            cC2D.radius += 0.05f;
            gC.cashMoney -= rangeIncreaseCost;
            rangeIncreaseCost += 200;
        }
    }


    

}
