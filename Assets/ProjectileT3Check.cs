using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileT3Check : MonoBehaviour
{

    public Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0.0f;
        }
    }


}
