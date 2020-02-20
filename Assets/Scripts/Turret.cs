using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

  //  public GameObject bullet;
    
    //the transform of the enemy within range
    public Transform enemy;


    public Transform firePoint;
    
    //the speed that the turret turns towards the enemy in range
    public float turnSpeed = 10f;


    public float[] fireGunFloat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (!enemy)
            {
                enemy = collision.gameObject.transform;
            }
            
           // Fire();
            Turn();
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemy = null;
        }
    }

    void Turn()
    {
        Vector2 direction = enemy.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
    }

    /*void Fire()
    {
        fireGunFloat[0] -= Time.deltaTime;
        if (fireGunFloat[0] < 0f)
        {
            Instantiate(bullet, firePoint.position, transform.rotation);
            fireGunFloat[0] = 5f;

        }


    }*/

}
