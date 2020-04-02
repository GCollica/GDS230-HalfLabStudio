using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AdvancedWaveSpawner : MonoBehaviour
{
    public Text waveCountdownText;

    public GameController gC;

    public GameObject enemyParent;

    public Waves[] waves;

    [Header("Enemy Attributes")]
    public Transform spawnPoint;
    public static int EnemiesAlive = 0;
    public Text enemiesAliveText;

    [Header("Wave Attributes")]
    public float waveCountdown;
    public float gameStartTimer;
    public float timeBetweenSpawns;
    public int waveIndex = 0;
    public Text waveUpdate;
    public int waveNumber;

    // Update is called once per frame
    void Update()
    {
        if (gameStartTimer <= 0f)
        {
            StartCoroutine(WaveSpawn());
            gameStartTimer = waveCountdown;
        }

        gameStartTimer -= Time.deltaTime;

        gameStartTimer = Mathf.Clamp(gameStartTimer, 0f, Mathf.Infinity);

        waveCountdownText.text = "Next Wave In: " + gameStartTimer.ToString("F0");
        waveUpdate.text = "Wave Count: " + waveIndex.ToString();
        enemiesAliveText.text = "Enemies: " + EnemiesAlive.ToString();
    }

    IEnumerator WaveSpawn()
    {
        Waves wave = waves[waveIndex];

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        if (waveIndex < 5)
        {
            waveIndex++;
        }
        else
        {
            Debug.Log("You Win!");
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
