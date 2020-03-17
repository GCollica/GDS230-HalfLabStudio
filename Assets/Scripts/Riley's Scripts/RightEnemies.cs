using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RightEnemies : MonoBehaviour
{
    public float health = 5f;
    public bool showHealth;
    public Slider slides;
    public GameObject healthBar;

    public float speed = 5f;

    private Transform target;
    private int rightWaypointIndex = 0;

    public BasicWaveSpawner spawner;

    public Turret turret;
    public Turret2 turret2;
    public GameController gC;
    

    void Start()
    {
        
        target = RightWaypoints.rightWaypoints[0];
        gC = GameObject.Find("GameController").GetComponent<GameController>();
        spawner = GameObject.Find("Spawner").GetComponent<BasicWaveSpawner>();
        gameObject.transform.SetParent(GameObject.Find("EnemyParent").transform);
        healthBar.SetActive(false);
    }


    void FixedUpdate()
    {
        if (gC.canMove == true)
        {
            Vector2 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        }
    }
    void Update()
    {
        

        if (Vector2.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        if (health <= 0) 
        {
            gC.researchPoints += 25;
            Destroy(gameObject);
        }

        UpdateHealth();
    }

    public void UpdateHealth()
    {
        if (showHealth == true)
        {
            healthBar.SetActive(true);
        }


        slides.value = health;
    }

    void GetNextWaypoint()
    {
        if (rightWaypointIndex >= RightWaypoints.rightWaypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        rightWaypointIndex++;
        target = RightWaypoints.rightWaypoints[rightWaypointIndex];
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.tag == "Turret")
        {
            //reset the turret to the one youre entering
            turret = collision.gameObject.GetComponent<Turret>();


            
        }
        
        if (collision.tag == "EnemyExit")
        {
            gC.health -= 1;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Turret2")
        {
            turret2 = collision.gameObject.GetComponent<Turret2>();
        }

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "T1Projectile(Clone)")
        {
            health -= turret.damage;
            showHealth = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "T2Projectile(Clone)")
        {
            health -= turret2.damage;
            showHealth = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Turret3")
        {
            speed = 0.25f;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        speed = 0.5f;
    }


}
