using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int health = 10;
    public GameObject enemyPlacer;
    public Vector3 mouse;
    public int cashMoney;
    public GameObject turret1;
    public Transform[] waypoints;
    public bool upgradeWindow = false;
    public bool purchaseTurretWindow = false;
    public GameObject pol;

    // Start is called before the first frame update
    void Start()
    {
        mouse = new Vector3(transform.position.x, transform.position.y, 10);
        cashMoney = 4000000;
    }

   

   /* public void SpawningTurretsGC()
    {
        if (turret1 == null) 
        { 
            Instantiate(enemyPlacer, gameObject.transform.position + mouse, transform.rotation);
            turret1 = enemyPlacer;
        }
        
        
    }*/

   


}
