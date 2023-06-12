using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int CoinCounter = 0;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ball"))
        {
            CoinCounter++;
            Destroy(gameObject);
            Debug.Log(CoinCounter);
        }
    }
}
