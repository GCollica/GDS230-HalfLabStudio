using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumbersSpawner : MonoBehaviour
{
    public GameObject textAsset;
    public GameObject[] spawnPoints;

    public void SpawnDamageNumber(int damage)
    {
        GameObject spawnedTextAsset = Instantiate(textAsset, ChoseSpawnPoint().transform);
        DamageNumbersUI damageNumbersUIScript = spawnedTextAsset.GetComponent<DamageNumbersUI>();
        damageNumbersUIScript.SetNumber(damage);
    }

    private GameObject ChoseSpawnPoint()
    {
        GameObject chosenSpawnPoint;

        int randomInt = Mathf.RoundToInt(Random.Range(0f, spawnPoints.Length));
        chosenSpawnPoint = spawnPoints[(randomInt - 1)];

        return chosenSpawnPoint;
    }
}
