using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Left2Enemies : MonoBehaviour
{
    public float health = 2f;
    public bool showHealth;
    public Slider slides;
    public GameObject healthBar;

    public SpriteRenderer spriteRenderer;
    public bool getHit;
    private float colourCountdown = 0.1f;

    public float speed = 1f;

    private Transform target;
    private int leftWaypointIndex = 0;

    public GameObject source;

    public Turret turret;
    public Turret2 turret2;
    public GameController gC;
    public AdvancedWaveSpawner spawner;

    public DamageNumbersSpawner damageNumbersSpawnerScript;

    


    void Start()
    {
        source.transform.parent = null;
        target = LeftWaypoints.leftWaypoints[0];
        gC = GameObject.Find("GameController").GetComponent<GameController>();
        spawner = gC.spawner;
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
            source.SetActive(true);
            Destroy(gameObject);
            AdvancedWaveSpawner.EnemiesAlive--;
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
        if (spawner.waveIndex == 1) { health += 0.5f; }
        if (spawner.waveIndex == 2) { health += 1f; }
        if (spawner.waveIndex == 3) { health += 1.5f; }
        if (spawner.waveIndex == 4) { health += 2f; }
        if (spawner.waveIndex == 5) { health += 2.5f; }
        if (spawner.waveIndex == 6) { health += 3f; }
        if (spawner.waveIndex == 7) { health += 3.5f; }
        if (spawner.waveIndex == 8) { health += 4f; }
        if (spawner.waveIndex == 9) { health += 4.5f; }
        if (spawner.waveIndex == 10) { health += 5.5f; }
        if (spawner.waveIndex == 11) { health += 6.5f; }
        if (spawner.waveIndex == 12) { health += 7.5f; }
        if (spawner.waveIndex == 13) { health += 8.5f; }
        if (spawner.waveIndex == 14) { health += 9.5f; }
        if (spawner.waveIndex == 15) { health += 10.5f; }
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
        if (collision.gameObject.name == "KillLeftEnemies")
        {
            Destroy(gameObject);
            AdvancedWaveSpawner.EnemiesAlive--;
        }


        if (collision.tag == "EnemyExit")
        {
            gC.updateHealthAudio = true;
            gC.health -= 1;
            Destroy(gameObject);
            AdvancedWaveSpawner.EnemiesAlive--;
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
            damageNumbersSpawnerScript.SpawnDamageNumber(Mathf.RoundToInt(turret.damage));

            Destroy(collision.gameObject);


        }

        if (collision.gameObject.name == "T2Projectile(Clone)")
        {
            health -= turret2.damage;
            showHealth = true;
            getHit = true;
            damageNumbersSpawnerScript.SpawnDamageNumber(Mathf.RoundToInt(turret2.damage));

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "T3Projectile(Clone)")
        {
            speed = 0.5f;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "T3Projectile(Clone)")
        {
            speed = 1f;
        }
    }

}
