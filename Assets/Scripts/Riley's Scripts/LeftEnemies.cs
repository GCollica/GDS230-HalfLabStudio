using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftEnemies : MonoBehaviour
{
    public float health = 4.7f;
    public bool showHealth;
    public Slider slides;
    public GameObject healthBar;

    public SpriteRenderer spriteRenderer;
    public bool getHit;
    private float colourCountdown = 0.1f;

    public float speed = 5f;

    private Transform target;
    private int leftWaypointIndex = 0;

   

    public Turret turret;
    public Turret2 turret2;
    public GameController gC;
    public BasicWaveSpawner spawner;


    void Start()
    {
        target = LeftWaypoints.leftWaypoints[0];
        gC = GameObject.Find("GameController").GetComponent<GameController>();
        spawner = GameObject.Find("Spawner").GetComponent<BasicWaveSpawner>();
        gameObject.transform.SetParent(GameObject.Find("EnemyParent").transform);
        healthBar.SetActive(false);
        IncreaseHealthPerWave();
    }

    

    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        if (health <= 0f) 
        {
            gC.researchPoints += 25;
            Destroy(gameObject);
        }

        UpdateHealth();
    }


    void FixedUpdate()
    {
        if (gC.canMove == true)
        {
            Vector2 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        }
    }

    public void UpdateHealth()
    {
        if (showHealth == true)
        {
            healthBar.SetActive(true);
        }


        slides.value = health;

        if (getHit == true)
        {
            spriteRenderer.color = Color.red;
            colourCountdown -= Time.deltaTime;
        }
        if (colourCountdown <= 0)
        {
            spriteRenderer.color = Color.white;
            getHit = false;
            colourCountdown = 0.1f;
        }

    }

    void IncreaseHealthPerWave()
    {
        if (spawner.waveIndex == 1) { health += 0.05f; }
        if (spawner.waveIndex == 2) { health += 0.1f; }
        if (spawner.waveIndex == 3) { health += 0.15f; }
        if (spawner.waveIndex == 4) { health += 0.2f; }
        if (spawner.waveIndex == 5) { health += 0.25f; }
        if (spawner.waveIndex == 6) { health += 0.3f; }
        if (spawner.waveIndex == 7) { health += 0.35f; }
        if (spawner.waveIndex == 8) { health += 0.4f; }
        if (spawner.waveIndex == 9) { health += 0.45f; }
        if (spawner.waveIndex == 10) { health += 1f; }
        if (spawner.waveIndex == 11) { health += 2f; }
        if (spawner.waveIndex == 12) { health += 3f; }
        if (spawner.waveIndex == 13) { health += 4f; }
        if (spawner.waveIndex == 14) { health += 5f; }
        if (spawner.waveIndex == 15) { health += 6f; }
    }


    void GetNextWaypoint()
    {
        if (leftWaypointIndex >= LeftWaypoints.leftWaypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        leftWaypointIndex++;
        target = LeftWaypoints.leftWaypoints[leftWaypointIndex];
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.tag == "Turret")
        {
            //gameobject set parent as collider hit
            
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
            getHit = true;
            
            Destroy(collision.gameObject);

            
        }

        if (collision.gameObject.name == "T2Projectile(Clone)")
        {
            health -= turret2.damage;
            showHealth = true;
            getHit = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "T3Projectile(Clone)")
        {
            speed = 0.25f;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Turret3")
        {
            speed = 0.5f;
        }
        if (collision.gameObject.name == "T3Projectile(Clone)") 
        {
            speed = 0.5f;
        }
    }

}
