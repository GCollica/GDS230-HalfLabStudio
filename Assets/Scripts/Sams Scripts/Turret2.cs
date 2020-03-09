using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret2 : MonoBehaviour
{
    //all the upgrade windows and the spawnpoint turret
    public GameObject[] upgradeWindows;
    public Text[] upgradeText;
    
    public Transform enemy;

    public float damage = 0.5f;

    public GameController gC;

    public CapsuleCollider2D col;

    public CircleCollider2D cCol;

    public int upgradeDamage = 150;
    public int upgradeRange = 150;
    public int sellTurret = 30;

    // Start is called before the first frame update
    void Start()
    {
        gC = FindObjectOfType<GameController>();

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
        damage += 0.5f;
        gC.cashMoney -= upgradeDamage;
        upgradeDamage += 100;
        sellTurret += 10;
    }


    public void UpgradeRange()
    {
        cCol.radius += 0.05f;
        gC.cashMoney -= upgradeRange;
        upgradeRange += 150;
        col.size += new Vector2(0.5f, 0.5f);
        sellTurret += 15;
    }


    public void DestoyTurret()
    {

        Destroy(upgradeWindows[1]);
        Destroy(upgradeWindows[2]);
        Destroy(upgradeWindows[3]);
        Destroy(upgradeWindows[4]);
        gC.upgradeWindow = false;
        gC.cashMoney += sellTurret;
        Instantiate(upgradeWindows[5], transform.position, Quaternion.identity);
        Destroy(gameObject);
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
        Vector2 direction = enemy.position - transform.position;
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

}
