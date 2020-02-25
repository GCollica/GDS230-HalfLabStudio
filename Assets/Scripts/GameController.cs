using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject enemyPlacer;
    public Vector3 mouse;
    public int cashMoney;
    public GameObject turret1;
    public Transform[] waypoints;
    // Start is called before the first frame update
    void Start()
    {
        mouse = new Vector3(transform.position.x, transform.position.y, 10);
        cashMoney = 400;
    }

    // Update is called once per frame
    void Update()
    {
        CheckClick();   
    }

    public void SpawningTurrets()
    {
        if (turret1 == null) 
        { 
            Instantiate(enemyPlacer, gameObject.transform.position + mouse, transform.rotation);
            turret1 = enemyPlacer;
        }
        
        
    }

    public void CheckClick()
    {
       /* if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("mouse was hit");
            
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                Debug.Log("Hit" + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.tag == "Turret")
                {
                    Debug.Log("Upgrade Window");
                }
                else
                {
                    Debug.Log("Not Working");
                }
            }
            else
            {
                Debug.Log("No Hit");
            }
        }*/
    }


}
