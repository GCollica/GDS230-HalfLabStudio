using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileT1 : MonoBehaviour
{

    public Rigidbody2D rb;
    private float thrust = 10f;
    private void Start()
    {
        rb.AddRelativeForce(Vector2.right * thrust, ForceMode2D.Impulse);

    }


    



}
