using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    void FixedUpdate()
    {
        GetComponent<TextMeshProUGUI>().text = Coin.CoinCounter.ToString();
    }
}
