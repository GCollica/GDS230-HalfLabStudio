using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret3AC : MonoBehaviour
{
    public Turret3 turret3Script;

    public void SpawnProjectile()
    {
        turret3Script.SpawnProjectile();
    }

    public void SetAnimState(int state)
    {
        this.gameObject.GetComponent<Animator>().SetInteger("AnimState", state);
    }
}
