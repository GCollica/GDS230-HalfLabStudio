using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1Spinner : MonoBehaviour
{

    public Transform target;

    public float turnSpeed = 20;

    public Turret turret;

    public GameController gC;

    // Start is called before the first frame update
    void Start()
    {
        gC = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turret.enemy && gC.targetFirst == true) 
        {
            turret.fireCountDown = true;
            target.position = transform.position;

        }
        if (!turret.enemy) 
        {
            target.position = new Vector2(1, 1);
        }

    }


    private void FixedUpdate()
    {
        if (gC.targetFirst == true)
        {
            Vector2 direction = target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") 
        {
            if (turret.enemy == null && gC.targetFirst == true)
            {
                turret.enemy = collision.gameObject;
                
            }

        }
    }
}
