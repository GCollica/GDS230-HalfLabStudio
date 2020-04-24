using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileT2 : MonoBehaviour
{
    public float damage;
    private Turret2 turret2Script;

    public Rigidbody2D rb;
    private float thrust = 10f;
    public float deathCountDown = 0.1f;

    void Awake()
    {
        turret2Script = gameObject.GetComponentInParent<Turret2>();
        damage = turret2Script.damage;
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
