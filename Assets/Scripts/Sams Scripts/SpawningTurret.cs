using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningTurret : MonoBehaviour
{
    //get this to follow mouse point, then click when in certain area and if placed in area charge money   
    //the turret gameObject
    public GameObject realTurret;
    //game controller to control money 
    GameController gC;
    public BuyingTurret bT;
    
    void Start()
    {
        gC = FindObjectOfType<GameController>();
        
    }

    //follow mouse
    void FixedUpdate()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = transform.position.z - Camera.main.transform.position.z;
        transform.position = Camera.main.ScreenToWorldPoint(pos);
    }

    private void Update()
    {
        DontSpawn();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    //Spawn turret on set point, remove #CashMoney when spawned
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "TurretZone") 
        {
            bT = collision.gameObject.GetComponent<BuyingTurret>();
            Debug.Log("In turret zone");
            if (gC.cashMoney >= 150)
            {
                Debug.Log("enough cash");
                if (Input.GetMouseButtonUp(0) && bT.placeOnTurret == true)
                {
                    Instantiate(realTurret, collision.transform.position, Quaternion.identity);
                    gC.cashMoney -= 150;
                    gC.turret1 = null;
                    gC.purchaseTurretWindow = false;
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                }
            }
        }
    }

    //if attempting to spawn turret while not over spawn point, dont.
    void DontSpawn() 
    {
        if (Input.GetMouseButtonUp(0))
        {
            
            gC.turret1 = null;
            Destroy(gameObject);
        }
    }

}
