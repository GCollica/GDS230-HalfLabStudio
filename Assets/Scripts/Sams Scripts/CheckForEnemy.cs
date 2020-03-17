using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForEnemy : MonoBehaviour
{

    public GameController gC;
    public BasicWaveSpawner spawner;
    public GameObject enemy;


    private void Update()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy == null && gC.health >= 0 && spawner.waveIndex >= 15)
        {
            gC.Win();
        }
    }


}
