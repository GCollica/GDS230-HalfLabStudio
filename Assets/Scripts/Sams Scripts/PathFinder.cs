using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathFinder : MonoBehaviour
{
    //Array of waypoints ie. the path to follow
    [SerializeField]
    Transform[] waypoints;
    //enemy health
    public float health;
    //the speed at which the enemy moves
    public float moveSpeed;
    //the next targeted waypoint for the enemy to move towards
    public int waypointIndex = 0;

    //the targeted turret so it doesnt take the wrong amount of damage
    public Turret turret;   
    //the targeted turret2 so it doesnt take the wrong amount of damage
    public Turret2 turret2;

    public GameController gC;

    // Start is called before the first frame update
    void Start()
    {
        gC = FindObjectOfType<GameController>();

        
    }

    // Update is called once per frame
    void Update()
    {
       // Move();
    }

    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Turret")
        {
            //reset the turret to the one youre entering
            turret = collision.gameObject.GetComponent<Turret>();
            

            //check if the turrets current enemy is this gameobject
            //if it is take away health
            if (turret.enemy == this.gameObject.transform)
            {
                health -= turret.damage * Time.deltaTime;
            }
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

    void Move()
    {
        //if enemy reaches final waypoint stop
        //if enemy isnt at final waypoint continue
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

            //if enemy reaches waypoint position, waypoint will increase by one 
            //and enemy will move towards that
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
        //if enemy health reaches 0 destroy enemy and add 50 gold
        if (health <= 0)
        {
            Destroy(this.gameObject);
            gC.cashMoney += 50;
        }

    }

}
