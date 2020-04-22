using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileT2 : MonoBehaviour
{
    public Rigidbody2D rb;
    private float thrust = 10f;
    public float deathCountDown = 0.1f;

    void Start()
    {  
        rb.AddRelativeForce(Vector2.right * thrust, ForceMode2D.Impulse);
    }
    private void Update()
    {
        deathCountDown -= 0.2f * Time.deltaTime;
        if (deathCountDown <= 0) 
        {
            Destroy(gameObject);
        }
    }

}
