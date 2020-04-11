using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DamageNumbersUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textAsset;

    private void Awake()
    {
        textAsset = GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void SetNumber(int Damage)
    {
        textAsset.text = Damage.ToString();
    }

    public void Despawn()
    {
        Destroy(this.gameObject);
    }
}
