using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumbersSpawner : MonoBehaviour
{
    public GameObject textAsset;

    public void SpawnDamageNumber(int damage)
    {
        GameObject spawnedTextAsset = Instantiate(textAsset, this.gameObject.transform);
        DamageNumbersUI damageNumbersUIScript = spawnedTextAsset.GetComponent<DamageNumbersUI>();
        damageNumbersUIScript.SetNumber(damage);
    }
}
