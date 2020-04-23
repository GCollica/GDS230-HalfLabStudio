using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class AdvancedWaveSpawner : MonoBehaviour
{
    public Text waveCountdownText;

    public GameController gC;

    public CheckForEnemy checkForEnemyClass;

    public GameObject enemyParent;

    public Waves[] waves;
    public int checkForEnemyCount;

    [Header("Enemy Attributes")]
    public Transform[] spawnPoint;
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
        checkForEnemyCount = EnemiesAlive;
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

        for (int i = 0; i < wave.count;)
        {
            if (checkForEnemyClass.sceneInt == 1 || checkForEnemyClass.sceneInt == 4) 
            {
                if (wave.enemyPrefabs[0] != null && wave.enemyPrefabs[1] == null && wave.enemyPrefabs[2] == null && wave.enemyPrefabs[3] == null) 
                { 
                    SpawnEnemy(wave.enemyPrefabs[ChooseEnemy(1)], spawnPoint[ChooseSpawnPoint()]);
                    i++;
                }
                if (wave.enemyPrefabs[0] != null && wave.enemyPrefabs[1] != null && wave.enemyPrefabs[2] == null && wave.enemyPrefabs[3] == null) 
                { 
                    SpawnEnemy(wave.enemyPrefabs[ChooseEnemy(2)], spawnPoint[ChooseSpawnPoint()]);
                    i++;
                }
                if (wave.enemyPrefabs[0] != null && wave.enemyPrefabs[1] != null && wave.enemyPrefabs[2] != null && wave.enemyPrefabs[3] == null) 
                { 
                    SpawnEnemy(wave.enemyPrefabs[ChooseEnemy(3)], spawnPoint[ChooseSpawnPoint()]);
                    i++;
                }
                if (wave.enemyPrefabs[0] != null && wave.enemyPrefabs[1] != null && wave.enemyPrefabs[2] != null && wave.enemyPrefabs[3] != null) 
                { 
                    SpawnEnemy(wave.enemyPrefabs[ChooseEnemy(4)], spawnPoint[ChooseSpawnPoint()]);
                    i++;
                }
            }

            if (checkForEnemyClass.sceneInt == 5)
            {
                if (wave.leftEnemyPrefabs[0] != null && wave.leftEnemyPrefabs[1] == null && wave.rightEnemyPrefabs[0] == null && wave.rightEnemyPrefabs[1] == null)
                {
                    SpawnEnemy(wave.leftEnemyPrefabs[ChooseEnemy1(1)], spawnPoint[ChooseSpawnPoint1()]);
                    i++;
                }
                if (wave.leftEnemyPrefabs[0] != null && wave.leftEnemyPrefabs[1] != null && wave.rightEnemyPrefabs[0] == null && wave.rightEnemyPrefabs[1] == null)
                {
                    SpawnEnemy(wave.leftEnemyPrefabs[ChooseEnemy1(2)], spawnPoint[ChooseSpawnPoint1()]);
                    i++;
                }
                if (wave.leftEnemyPrefabs[0] != null && wave.leftEnemyPrefabs[1] == null && wave.rightEnemyPrefabs[0] != null && wave.rightEnemyPrefabs[1] == null)
                {
                    SpawnEnemy(wave.leftEnemyPrefabs[ChooseEnemy1(1)], spawnPoint[ChooseSpawnPoint1()]);
                    SpawnEnemy(wave.rightEnemyPrefabs[ChooseEnemy2(1)], spawnPoint[ChooseSpawnPoint2()]);
                    i += 2;
                }               
                if (wave.leftEnemyPrefabs[0] != null && wave.leftEnemyPrefabs[1] != null && wave.rightEnemyPrefabs[0] != null && wave.rightEnemyPrefabs[1] == null)
                {
                    SpawnEnemy(wave.leftEnemyPrefabs[ChooseEnemy1(2)], spawnPoint[ChooseSpawnPoint1()]);
                    SpawnEnemy(wave.rightEnemyPrefabs[ChooseEnemy2(1)], spawnPoint[ChooseSpawnPoint2()]);
                    i += 2;
                }
                if (wave.leftEnemyPrefabs[0] != null && wave.leftEnemyPrefabs[1] != null && wave.rightEnemyPrefabs[0] != null && wave.rightEnemyPrefabs[1] != null)
                {
                    SpawnEnemy(wave.leftEnemyPrefabs[ChooseEnemy1(2)], spawnPoint[ChooseSpawnPoint1()]);
                    SpawnEnemy(wave.rightEnemyPrefabs[ChooseEnemy2(2)], spawnPoint[ChooseSpawnPoint2()]);
                    i += 2;
                }
            }

            yield return new WaitForSeconds(wave.rate);
        }

        if (waveIndex >= waves.Length)
        {
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemy, Transform spawnPoint)
    {
        if (gC.canMove == true)
        {
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            EnemiesAlive++;
        }
    }

    void SpawnMultipleEnemy(GameObject enemy1, GameObject enemy2, Transform spawnPoint1, Transform spawnPoint2)
    {
        if (gC.canMove == true)
        {
            Instantiate(enemy1, spawnPoint1.position, spawnPoint1.rotation);
            Instantiate(enemy2, spawnPoint2.position, spawnPoint2.rotation);
            EnemiesAlive += 2;
        }
    }

    private int ChooseSpawnPoint()
    {
        int chosenPoint = (Random.Range(1, 4) - 1);
        return chosenPoint;
    }

    private int ChooseEnemy(int amountOfEnemies)
    {
        int chosenEnemy = (Mathf.RoundToInt(Random.Range(1, amountOfEnemies)) - 1);
        return chosenEnemy;
    }

    private int ChooseSpawnPoint1()
    {
        int chosenPoint1 = (Random.Range(1, 4) - 1);
        return chosenPoint1;
    }

    private int ChooseSpawnPoint2()
    {
        int chosenPoint2 = (Random.Range(5, 8) - 1);
        return chosenPoint2;
    }

    private int ChooseEnemy1(int amountOfEnemies)
    {
        int chosenEnemy = (Mathf.RoundToInt(Random.Range(1, amountOfEnemies)) - 1);
        return chosenEnemy;
    }

    private int ChooseEnemy2(int amountOfEnemies)
    {
        int chosenEnemy = (Mathf.RoundToInt(Random.Range(1, amountOfEnemies)) - 1);
        return chosenEnemy;
    }
}
