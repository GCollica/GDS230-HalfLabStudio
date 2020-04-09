using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret2AC : MonoBehaviour
{
    public Turret2 turret2Script;

    public void SpawnProjectile(int spawnPoint)
    {
        turret2Script.SpawnProjectile(spawnPoint);
    }

    public void SetAnimState(int state)
    {
        this.gameObject.GetComponent<Animator>().SetInteger("AnimState", state);
    }
}
