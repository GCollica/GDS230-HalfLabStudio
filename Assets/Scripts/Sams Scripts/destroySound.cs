using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySound : MonoBehaviour
{
    float ded = 1;
    // Update is called once per frame
    void Update()
    {
        ded -= Time.deltaTime;
        if (ded <= 0) { Destroy(gameObject); }
    }
}
