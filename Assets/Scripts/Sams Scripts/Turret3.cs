using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret3 : MonoBehaviour
{
    public GameController gC;

    public GameObject[] upgradeWindows;
    public GameObject enemy;


    public GameObject projectilePrefab;
    public GameObject projectileSpawned;
    public GameObject firePoint;
    public float fireTimer = 1.5f;
    public ProjectileT3 pT3;


    public bool fireCountDown;

    private void Start()
    {
        gC = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        if (fireCountDown == true && gC.canMove == true && !projectileSpawned) 
        {
            fireTimer -= 0.8f * Time.deltaTime;
        }
    }

    void Turn()
    {
        Vector2 direction = enemy.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
    }

    void Fire() 
    {
        if (fireTimer <= 0f) 
        {
            Instantiate(projectilePrefab, firePoint.transform.position, firePoint.transform.rotation);
            
            fireTimer = 3f;
        }
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
            Fire();
        }
        //if (collision.name == "T3Projectile(Clone)") 
        //{
        //    if (!projectileSpawned) 
        //    {
        //        projectileSpawned = collision.gameObject;
                
        //    }
        //}

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == enemy) 
        {
            enemy = null;
            fireCountDown = false;
        }

        if (collision.gameObject == projectileSpawned)
        {
            projectileSpawned = null;

        }

    }

}
