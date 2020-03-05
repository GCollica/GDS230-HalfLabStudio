using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selecting : MonoBehaviour
{
    public int length = 100;
    


    void CheckClick()
    {

        
        Debug.DrawRay(transform.position, Vector2.right * length);
        if (Input.GetMouseButtonUp(0))
        {
            
            RaycastHit2D hit = new RaycastHit2D();
            Ray2D SelectingRay = new Ray2D(transform.position, Vector2.right);
            Debug.Log("Hit " + hit.transform.gameObject.name);
            if (Physics2D.Raycast(transform.position, Vector2.right, length))
            
            {
                if (hit.collider.tag == "Turret")
                {
                    Debug.Log("Upgrade");
                }
            }
        }
    }
}
