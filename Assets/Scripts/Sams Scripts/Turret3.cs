using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret3 : MonoBehaviour
{
    public GameController gC;

    //Creating Animator Reference - Gian
    private Animator towerAnimator;

    public GameObject[] upgradeWindows;
    public GameObject enemy;


    public GameObject projectilePrefab;
    public GameObject projectileSpawned;
    public GameObject firePoint;
    private float fireTimer = 0f;
    public ProjectileT3 pT3;


    public bool fireCountDown;
    public AudioSource source;

    private void Awake()
    {
        gC = FindObjectOfType<GameController>();
        upgradeWindows[1].transform.parent = null;
        //Referencing this game objects Animator - Gian
        towerAnimator = this.gameObject.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (fireCountDown == true && gC.canMove == true) //Removed "&& !projectileSpawned" as logic isn't correct - Gian 
        {
            fireTimer -= 1.0f * Time.deltaTime;
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
            //See below - Gian
            //Instantiate(projectilePrefab, firePoint.transform.position, firePoint.transform.rotation);

            //Reworked how firing works, this now just starts the animation, the animation has events which do the rest - Gian
            
            if(enemy != null)
            {
                towerAnimator.SetInteger("AnimState", 1);
                source.Play();
            }

            fireTimer = 7.5f;
        }
    }

    public void SpawnProjectile()
    {
        Instantiate(projectilePrefab, firePoint.transform.position, firePoint.transform.rotation, this.gameObject.transform);
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

        /*if (collision.gameObject == projectileSpawned) //Removed for the same reason mentioned above where it was used - Gian
        {
            projectileSpawned = null;

        }*/

    }

}
