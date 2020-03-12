using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BasicWaveSpawner : MonoBehaviour
{
    public Text waveCountdownText;

    public GameController gC;

    List<GameObject> Enemies;

    [Header("Enemy Attributes")]
    public Transform leftEnemyPrefab;
    public Transform rightEnemyPrefab;
    public Vector3 rightEnemyOffset;
    public Transform spawnPoint;

    [Header("Wave Attributes")]
    public float waveCountdown;
    public float gameStartTimer;
    public int waveIndex = 0;
    public int waveNumber;
    public float timeBetweenSpawns;

    void Update()
    {
        if (gameStartTimer <= 0f)
        {
            StartCoroutine(WaveSpawn());
            gameStartTimer = waveCountdown;
        }

        gameStartTimer -= Time.deltaTime;

        gameStartTimer = Mathf.Clamp(gameStartTimer, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", gameStartTimer);
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
        Enemies.Add((GameObject)Instantiate(leftEnemyPrefab, spawnPoint.position, spawnPoint.rotation);

        Instantiate(leftEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
        Instantiate(rightEnemyPrefab, spawnPoint.position + rightEnemyOffset, spawnPoint.rotation);
    }
}
