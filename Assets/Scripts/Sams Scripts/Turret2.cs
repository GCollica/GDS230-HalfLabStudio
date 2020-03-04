using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret2 : MonoBehaviour
{

    public GameObject[] upgradeWindows;
    public Text[] upgradeText;
    
    public Transform enemy;

    public float damage = 0.3f;

    public GameController gC;

    public CapsuleCollider2D col;

    public CircleCollider2D cCol;

    int upgradeDamage = 150;
    int upgradeRange = 0;

    // Start is called before the first frame update
    void Start()
    {
        gC = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        
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
        damage += 0.2f;
        gC.cashMoney -= upgradeDamage;
        upgradeDamage += 100;
    }


    public void UpgradeRange()
    {
        cCol.radius += 0.05f;
        col.size += new Vector2(0.5f, 0.5f);
    }


    public void DestoyTurret()
    {

    }


    public void CloseUpgradeWindow()
    {
        upgradeWindows[0].SetActive(false);
        upgradeWindows[1].SetActive(false);
        upgradeWindows[2].SetActive(false);
        upgradeWindows[3].SetActive(false);
        upgradeWindows[4].SetActive(false);
        gC.upgradeWindow = true;

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
