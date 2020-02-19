using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int CashMoney;
    // Start is called before the first frame update
    void Start()
    {
        CashMoney = 400;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(CashMoney);
    }
}
