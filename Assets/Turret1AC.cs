using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret1AC : MonoBehaviour
{
    public Turret turret1Script;

    public void SpawnProjectile()
    {
        turret1Script.SpawnProjectile();
    }

    public void SetAnimState(int state)
    {
        this.gameObject.GetComponent<Animator>().SetInteger("AnimState", state);
    }
}
