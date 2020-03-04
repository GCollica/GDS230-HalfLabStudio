using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform target;
    public Turret turretScript;

    // Start is called before the first frame update
    void Start()
    {
        //rb.AddForce(Vector2.up * 30f, ForceMode2D.Force);
        



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
