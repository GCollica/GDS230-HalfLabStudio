using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret2 : MonoBehaviour
{
    //all the upgrade windows and the spawnpoint turret
    public GameObject[] upgradeWindows;
    public Text[] upgradeText;
    
    public GameObject enemy;

    public float damage = 0.1f;
    public int damageUpgradedTimes;

    public GameObject projectile;
    public GameObject[] firepoints;
    private float fireTimer = 0f;

    public GameController gC;

    public int rangeUpgradedTimes;

    public CircleCollider2D cCol;
    public SpriteRenderer rangeSprite;
    public Vector3 temp;

    public int upgradeDamage = 250;
    public int upgradeRange = 150;
    public int sellTurret = 30;

    public Animator anim;

    public bool fireCountDown;

    // Start is called before the first frame update
    void Start()
    {
        gC = FindObjectOfType<GameController>();
        rangeSprite.gameObject.transform.parent = null;

    }

    private void Update()
    {
        if (fireCountDown == true && gC.canMove == true)
        {
            fireTimer -= 1f * Time.deltaTime;
        }

        Fire();
    }

    public void OpenUpgradeWindow()
    {
        if (gC.upgradeWindow == false)
        {
            upgradeWindows[0].SetActive(true);
            upgradeWindows[1].SetActive(true);
            upgradeWindows[2].SetActive(true);
            upgradeWindows[3].SetActive(true);
            upgradeWindows[4].SetActive(true);
            gC.upgradeWindow = true;
        }
    }

    public void UpgradeDamage()
    {
        damageUpgradedTimes += 1;
        damage += 0.25f;
        gC.researchPoints -= upgradeDamage;
        upgradeDamage += 200;
        sellTurret += 10;
    }


    public void UpgradeRange()
    {
        rangeUpgradedTimes += 1;
        cCol.radius += 0.5f;
        temp = rangeSprite.transform.localScale;
        temp.x += 4f;
        temp.y += 4f;
        rangeSprite.transform.localScale = temp;
      //  gC.researchPoints -= upgradeRange;
       // upgradeRange += 150;
       
        sellTurret += 15;
    }


    public void DestoyTurret()
    {

        Destroy(upgradeWindows[1]);
        Destroy(upgradeWindows[2]);
        Destroy(upgradeWindows[3]);
        Destroy(upgradeWindows[4]);
        gC.upgradeWindow = false;
        gC.researchPoints += sellTurret;
        Instantiate(upgradeWindows[5], transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void Fire() 
    {
        //if the enemy is being targeted play the fire animation
        /*if (enemy)
        {
            anim.SetBool("Fire", true);
        }
        //if the enemy is not targeted stop the fire animation
        else
        {
            anim.SetBool("Fire", false);
        }*/

        if (fireTimer <= 0f)
        {
            /*Instantiate(projectile, firepoints[0].transform.position, firepoints[0].transform.rotation);
            Instantiate(projectile, firepoints[0].transform.position, firepoints[0].transform.rotation);
            Instantiate(projectile, firepoints[1].transform.position, firepoints[1].transform.rotation);
            Instantiate(projectile, firepoints[1].transform.position, firepoints[1].transform.rotation);
            Instantiate(projectile, firepoints[2].transform.position, firepoints[2].transform.rotation);
            Instantiate(projectile, firepoints[2].transform.position, firepoints[2].transform.rotation);
            Instantiate(projectile, firepoints[3].transform.position, firepoints[3].transform.rotation);
            Instantiate(projectile, firepoints[3].transform.position, firepoints[3].transform.rotation);
            Instantiate(projectile, firepoints[4].transform.position, firepoints[4].transform.rotation);
            Instantiate(projectile, firepoints[4].transform.position, firepoints[4].transform.rotation);*/

            anim.SetInteger("AnimState", 1);
            fireTimer = 3f;
        }

    }

    public void CloseUpgradeWindow()
    {
        upgradeWindows[0].SetActive(false);
        upgradeWindows[1].SetActive(false);
        upgradeWindows[2].SetActive(false);
        upgradeWindows[3].SetActive(false);
        upgradeWindows[4].SetActive(false);
        gC.upgradeWindow = false;


    }

    void Turn()
    {
        Vector2 direction = enemy.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (!enemy)
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

    public void SpawnProjectile(int spawnPoint)
    {
        Instantiate(projectile, firepoints[spawnPoint].transform.position, firepoints[spawnPoint].transform.rotation);
    }

}
