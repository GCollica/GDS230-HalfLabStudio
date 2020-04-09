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
    public int enemies;
    //public Text enemiesAliveText;

    [Header("Wave Attributes")]
    public float waveCountdown;
    public float gameStartTimer;
    public int waveIndex = 0;
    public Text waveUpdate;

    private void Start()
    {
        ResetEnemiesAlive();
    }

    public void ResetEnemiesAlive() 
    {
        EnemiesAlive = 0; 
        enemies = 0;
    }

    // Update is called once per frame
    void Update()
    {
        enemies = EnemiesAlive;
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (gameStartTimer <= 0f)
        {
            StartCoroutine(WaveSpawn());
            gameStartTimer = waveCountdown;
        }
        if (gC.canMove)
        {
            gameStartTimer -= Time.deltaTime;
        }

        gameStartTimer = Mathf.Clamp(gameStartTimer, 0f, Mathf.Infinity);

        waveCountdownText.text = "Next Wave In: " + gameStartTimer.ToString("F0");
        waveUpdate.text = "Wave Count: " + waveIndex.ToString();
        //enemiesAliveText.text = "Enemies: " + EnemiesAlive.ToString();
    }

    IEnumerator WaveSpawn()
    {
        Waves wave = waves[waveIndex];
        waveIndex++;

        for (int i = 0; i < wave.count; i++)
        {
            if (wave.enemyPrefabs[0]) { SpawnEnemy(wave.enemyPrefabs[0]); }
            if (wave.enemyPrefabs[1]) { SpawnEnemy(wave.enemyPrefabs[1]); }
            if (wave.enemyPrefabs[2]) { SpawnEnemy(wave.enemyPrefabs[2]); }
            if (wave.enemyPrefabs[3]) { SpawnEnemy(wave.enemyPrefabs[3]); }

            yield return new WaitForSeconds(1f / wave.rate);
        }

        if (waveIndex >= waves.Length)
        {
            Debug.Log("You Win!");
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
