using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftEnemies : MonoBehaviour
{
    public float health = 5f;

    public float speed = 5f;

    private Transform target;
    private int leftWaypointIndex = 0;

    public Turret turret;
    public Turret2 turret2;
    public GameController gC;
    

    void Start()
    {
        target = LeftWaypoints.leftWaypoints[0];
        //gC = GameObject.Find("GameController").GetComponent<GameController>();
        
    }

    void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        if (health <= 0f) 
        {
            gC.cashMoney += 25;
            Destroy(gameObject);
        }
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
        if (collision.tag == "GameController") 
        {
            gC = collision.gameObject.GetComponent<GameController>();
        }
        if (collision.tag == "Turret")
        {
            //gameobject set parent as collider hit
            
            //reset the turret to the one youre entering
            turret = collision.gameObject.GetComponent<Turret>();


            //check if the turrets current enemy is this gameobject
            //if it is take away health
            if (turret.enemy == this.gameObject.transform)
            {
                health -= turret.damage * Time.deltaTime;
            }
        }
        if (collision.tag == "EnemySpawn") 
        {
            gameObject.transform.SetParent(collision.transform);
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

        if (collision.gameObject.name == "SecondCollider")
        {

            health -= turret2.damage * Time.deltaTime;
        }
    }


}
