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

    private bool endGame;

    public string sceneName;


    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        
        if (AdvancedWaveSpawner.EnemiesAlive <= 0 && gC.health >= 0 && spawner.waveIndex == 15 && sceneName == "Alpha")
        {
            gC.Win();
            skipCountDown.SetActive(false);
            endGame = true;
        }
        if (AdvancedWaveSpawner.EnemiesAlive <= 0 && gC.health >= 0 && spawner.waveIndex == 20 && sceneName == "Level2")
        {
            gC.Win();
            skipCountDown.SetActive(false);
            endGame = true;
        }

        if (AdvancedWaveSpawner.EnemiesAlive <= 0 && endGame == false) 
        {
            skipCountDown.SetActive(true);
            
        }
        else
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
