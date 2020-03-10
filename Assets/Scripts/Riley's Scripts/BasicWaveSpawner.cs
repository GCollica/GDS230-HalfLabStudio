using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BasicWaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Transform leftEnemyPrefab;
    public Transform rightEnemyPrefab;

    public Vector3 rightEnemyOffset;

    public Transform spawnPoint;

    public float waveCountdown = 1f;
    private float gameStartTimer = 1f;

    public Text waveCountdownText;

    public int waveIndex = 0;

    public GameController gC;

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
        if (waveIndex < 10)
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
        Instantiate(leftEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;

        Instantiate(rightEnemyPrefab, spawnPoint.position + rightEnemyOffset, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
