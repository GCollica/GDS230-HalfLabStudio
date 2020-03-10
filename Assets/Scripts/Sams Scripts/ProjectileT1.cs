using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileT1 : MonoBehaviour
{
    public Rigidbody2D rb;


    private void Start()
    {
        rb.AddForce(Vector2.right, ForceMode2D.Impulse);
    }


    private void FixedUpdate()
    {
        
    }
}
