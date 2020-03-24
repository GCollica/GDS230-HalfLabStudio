using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BasicWaveSpawner : MonoBehaviour
{
    public Text waveCountdownText;

    public GameController gC;

    public GameObject enemyParent;
 
    [Header("Enemy Attributes")]
    public Transform leftEnemyPrefab;
    public Transform rightEnemyPrefab;
    public Vector3 rightEnemyOffset;
    public Transform spawnPoint;

    [Header("Wave Attributes")]
    public float waveCountdown;
    public float gameStartTimer;
    public int waveIndex = 0;
    public Text waveUpdate;
    public int waveNumber;
    public float timeBetweenSpawns;

    void Update()
    {
        
        
        if (gameStartTimer <= 0f)
        {
            StartCoroutine(WaveSpawn());
            gameStartTimer = waveCountdown;
        }

        if (gC.canMove == true && waveIndex < waveNumber) 
        {
            gameStartTimer -= Time.deltaTime;
        }

        gameStartTimer = Mathf.Clamp(gameStartTimer, 0f, Mathf.Infinity);

        waveCountdownText.text = gameStartTimer.ToString("F0") + " Wave Count: " + waveIndex;
    }

    IEnumerator WaveSpawn()
    {
        if (waveIndex < waveNumber)
        {
            waveIndex++;

            for (int i = 0; i < waveIndex; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(timeBetweenSpawns);
            }
        }
    }

    void SpawnEnemy()
    {
        //canMove sets the speed for the enemies to 0, and pauses their spawning
        if (gC.canMove == true)
        {
            Instantiate(leftEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
            Instantiate(rightEnemyPrefab, spawnPoint.position + rightEnemyOffset, spawnPoint.rotation);
        }
    }
}
