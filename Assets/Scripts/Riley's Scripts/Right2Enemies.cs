﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Right2Enemies : MonoBehaviour
{
    //this float/bool is used to controll the offset of the right enemies so they dont sit ontop of the left enemies
    float moveCountDown = 0.5f;
    bool startMoving;

    public float health = 4.7f;
    public bool showHealth;
    public Slider slides;
    public GameObject healthBar;

    public SpriteRenderer spriteRenderer;
    public bool getHit;
    private float colourCountdown = 0.1f;


    public float speed = 1f;

    private Transform target;
    private int rightWaypointIndex = 0;

    public AdvancedWaveSpawner spawner;

    public Turret turret;
    public Turret2 turret2;
    public GameController gC;

    public DamageNumbersSpawner damageNumbersSpawnerScript;
    public GameObject source;
  


    void Start()
    {
        source.transform.parent = null;
        target = RightWaypoints.rightWaypoints[0];
        gC = GameObject.Find("GameController").GetComponent<GameController>();
        spawner = gC.spawner;
        gameObject.transform.SetParent(GameObject.Find("EnemyParent").transform);
        healthBar.SetActive(false);
        //IncreaseHealthPerWave();
    }


    void FixedUpdate()
    {
        if (gC.canMove == true && startMoving == true)
        {
            Vector2 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        }

        StartMoving();
    }

    void StartMoving()
    {
        if (startMoving == false)
        {
            moveCountDown -= Time.deltaTime;
            gameObject.layer = 9;
        }
        if (moveCountDown <= 0f)
        {
            gameObject.layer = 0;
            startMoving = true;
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
            source.SetActive(true);
            Destroy(gameObject);
            AdvancedWaveSpawner.EnemiesAlive--;
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

    /*void IncreaseHealthPerWave()
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
    }*/

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

        if (collision.gameObject.name == "KillRightEnemies")
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
            health -= collision.gameObject.GetComponent<ProjectileT1>().damage;
            showHealth = true;
            getHit = true;
            damageNumbersSpawnerScript.SpawnDamageNumber(Mathf.RoundToInt(collision.gameObject.GetComponent<ProjectileT1>().damage));

            Destroy(collision.gameObject);


        }

        if (collision.gameObject.name == "T2Projectile(Clone)")
        {
            health -= collision.gameObject.GetComponent<ProjectileT2>().damage;
            showHealth = true;
            getHit = true;
            damageNumbersSpawnerScript.SpawnDamageNumber(Mathf.RoundToInt(collision.gameObject.GetComponent<ProjectileT2>().damage));

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "T3Projectile(Clone)")
        {
            speed = 0.25f;
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
