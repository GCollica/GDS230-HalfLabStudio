using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileT3 : MonoBehaviour
{

    public Rigidbody2D rb;
    private float thrust = 10f;
    private float deathCountDown = 5f;

    public Animator projectileAnimator;


    private void Awake()
    {
        projectileAnimator = GetComponentInChildren<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

        rb.AddRelativeForce(Vector2.right * thrust, ForceMode2D.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        deathCountDown -= 1f * Time.deltaTime;
        if (deathCountDown <= 0) 
        {
            Destroy(gameObject);
        }

            
        
    }

    public void ChangeAnimState(int state)
    {
        projectileAnimator.SetInteger("AnimState", state);
    }
    

}
