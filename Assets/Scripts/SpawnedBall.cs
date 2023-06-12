using System;
using UnityEngine;

public class SpawnedBall : MonoBehaviour
{
    public static Vector3 NewSpawnerPosition;
    public static bool NewSpawnerPositionGet = false;
    public static int DestroyedBalls = 0;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("BottomWall"))
        {
            if (!NewSpawnerPositionGet)
            {
                NewSpawnerPositionGet = true;
                NewSpawnerPosition = gameObject.transform.position;
                NewSpawnerPosition.y = -3.3f;
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Skull"))
        {
            Destroy(gameObject);
            DestroyedBalls--;
            Debug.Log(DestroyedBalls);
        }
    }
}
