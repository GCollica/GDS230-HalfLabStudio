using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret3Check : MonoBehaviour
{
    //this script sets the turret3 projectile spawned to the correct thing
    //so that multiple turrets dont call the same object as the fired projectile

    public Turret3 turret3;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "T3Projectile(Clone)" && !turret3.projectileSpawned)
        {
            turret3.projectileSpawned = collision.gameObject;
        }
    }


}
