using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileT1 : MonoBehaviour
{
    public float damage;

    private Turret turret1Script;

    public Rigidbody2D rb;
    private float thrust = 10f;
    public float deathCountDown = 0.1f;
    private void Awake()
    {
        turret1Script = this.gameObject.GetComponentInParent<Turret>();
        damage = turret1Script.damage;

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
