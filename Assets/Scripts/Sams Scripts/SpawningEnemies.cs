using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemies : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject startWaves;
    public Transform spawnPoint;
    public int waveCount = 0;
    public int enemyCount = 5;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void Waves()
    {
        waveCount += 1;
        Instantiate(enemy[0], spawnPoint.position, transform.rotation);
    }

   
}
