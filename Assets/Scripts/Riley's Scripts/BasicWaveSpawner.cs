using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BasicWaveSpawner : MonoBehaviour
{
    public Transform leftEnemyPrefab;
    public Transform rightEnemyPrefab;

    public Transform spawnPoint;

    public float waveCountdown = 5f;
    private float gameStartTimer = 2f;

    public Text waveCountdownText;

    private int waveIndex = 0;

    void Update()
    {
        if (gameStartTimer <= 0f)
        {
            StartCoroutine(WaveSpawn());
            gameStartTimer = waveCountdown;
        }

        gameStartTimer -= Time.deltaTime;

        gameStartTimer -= Mathf.Clamp(gameStartTimer, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", gameStartTimer);
    }

    IEnumerator WaveSpawn()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(leftEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
        //Instantiate(rightEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
