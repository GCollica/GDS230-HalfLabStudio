using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckForEnemy : MonoBehaviour
{

    public GameController gC;
    public AdvancedWaveSpawner spawner;
    public GameObject enemy;

    public GameObject skipCountDown;

    public string sceneName;


   
    private void Update()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy == null && gC.health >= 0 && spawner.waveIndex >= 15 && sceneName == "Alpha")
        {
            gC.Win();
        }
        if (enemy == null && gC.health >= 0 && spawner.waveIndex >= 25 && sceneName == "Level2")
        {
            gC.Win();
        }

        if (enemy == null && spawner.gameStartTimer >= 0.5 && spawner.waveIndex >= 1) 
        {
            skipCountDown.SetActive(true);
        }

        if (enemy) 
        {
            skipCountDown.SetActive(false);
        }
        
    }

    public void NextWave() 
    {
        skipCountDown.SetActive(false);
        spawner.gameStartTimer = 0;
        gC.researchPoints += 50;
        
    }


}
