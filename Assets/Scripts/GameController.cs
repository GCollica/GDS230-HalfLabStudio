using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject enemyPlacer;
    public Vector3 mouse;
    public int cashMoney;
    // Start is called before the first frame update
    void Start()
    {
        mouse = new Vector3(transform.position.x, transform.position.y, 10);
        cashMoney = 400;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawningTurrets()
    {
        Instantiate(enemyPlacer, gameObject.transform.position + mouse, transform.rotation);
        
    }


}
