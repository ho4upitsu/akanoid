using System;
using UnityEngine;
public class AddBall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ball"))
        {
            SpawnedBall.DestroyedBalls++;
            Destroy(gameObject);
            Debug.Log(SpawnedBall.DestroyedBalls);
        }
    }
}
