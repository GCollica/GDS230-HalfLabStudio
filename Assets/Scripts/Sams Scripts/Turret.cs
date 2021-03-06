﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    
    public GameObject[] upgradeButtons;
    public Text[] upgradeText;

    public CircleCollider2D cC2D;
    public SpriteRenderer rangeSprite;
    public SpriteRenderer[] thisSprite;
    public Vector3 temp;
    public int rangeIncreaseCost = 200;
    public int rangeUpgradedAmount = 0;

    public GameController gC;

    //bool to check if the enemy target is set currently if not resets the target
    public bool enemySet;
    public GameObject towerSpawnPoint;

    public GameObject projectile;
    public GameObject firePoint;
    private float fireTimer = 0f;

    //the transform of the enemy within range
    public GameObject enemy;

    public float damage = 16f;
    public int damageIncreaseCost = 150;
    public int damageUpgradedAmount = 0;

    public int sellTurret = 50;

    public Animator anim;

    public bool fireCountDown;

    //the speed that the turret turns towards the enemy in range
    public float turnSpeed = 10f;

    public AudioSource source;


    // Start is called before the first frame update
    void Start()
    {
        
        gC = FindObjectOfType<GameController>();
        rangeSprite.gameObject.transform.parent = null;
        if (gC.checkForEnemyScript.sceneInt == 5)
        {
            thisSprite[0].sortingOrder = -2;
            thisSprite[1].sortingOrder = -2;
            thisSprite[2].sortingOrder = -2;
        }
    }

    void Update()
    {

        if (fireCountDown == true && gC.canMove == true) 
        {
            fireTimer -= 0.8f * Time.deltaTime;
        }

        Fire();


    }



    //only deal damage to enemy objects if they are your target
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //if enemy is not yet set, set it to the one that is currently inside your collider
            if (enemy == null && gC.targetFirst == false)
            {
                enemy = collision.gameObject;
                
            }
            fireCountDown = true;

            Turn();
            
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if enemy leaves your range stop targeting them
        if (collision.gameObject == enemy)
        {

            enemy = null;
            
            fireCountDown = false;
        }
    }



    //follow the enemy target
    void Turn()
    {
        Vector2 direction = enemy.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
    }

    void Fire()
    {
        if (fireTimer <= 0f)
        {
            if(enemy != null)
            {
                anim.SetInteger("AnimState", 1);
                source.Play();
            }
            fireTimer = 1.5f;
        }
    }

    public void SpawnProjectile()
    {
        Instantiate(projectile, firePoint.transform.position, transform.rotation, this.gameObject.transform);
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
        damageUpgradedAmount += 1;
        damage += 2.5f;
        gC.researchPoints -= damageIncreaseCost;
        damageIncreaseCost += 200;
        sellTurret += 5;
    }

    public void IncreaseRange() 
    {
        rangeUpgradedAmount += 1;
        cC2D.radius += 0.5f;
        temp = rangeSprite.transform.localScale;
        temp.x += 4f;
        temp.y += 4f;
        rangeSprite.transform.localScale = temp;
      //  gC.researchPoints -= rangeIncreaseCost;
       // rangeIncreaseCost += 200;
        sellTurret += 10;
    }
    

    public void DestroyTower() 
    {
        Instantiate(towerSpawnPoint, new Vector3(transform.position.x, transform.position.y, 40), Quaternion.identity);
        gC.researchPoints += sellTurret;
        Destroy(rangeSprite.gameObject);
        Destroy(upgradeButtons[0]);
        Destroy(upgradeButtons[1]);
        Destroy(upgradeButtons[2]);
        Destroy(upgradeButtons[3]);
        gC.upgradeWindow = false;
        Destroy(gameObject);
    }

    

}
