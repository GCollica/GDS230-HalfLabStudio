using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileT3Check : MonoBehaviour
{
    //this script sits on the projectile 3s body and stops it with a smaller collider 
    //on collision with an enemy so the projectile can get close to the enemy

    public Rigidbody2D rb;

    private ProjectileT3 parentProjectileScript;

    private void Awake()
    {
        parentProjectileScript = GetComponentInParent<ProjectileT3>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            parentProjectileScript.ChangeAnimState(1);
            Invoke("StopMovement", 0.075f);           
        }
    }

    private void StopMovement()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0.0f;
    }


}
