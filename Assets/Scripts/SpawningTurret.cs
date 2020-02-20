using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningTurret : MonoBehaviour
{
    //get this to follow mouse point, then click when in certain area and if placed in area charge money
    private Vector3 mousePos;
    Rigidbody2D rb;
    Vector2 direction;
    float moveSpeed = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        direction = (mousePos - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
