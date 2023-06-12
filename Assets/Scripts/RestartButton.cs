using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    private static GameObject restartButton;

    public void ReStartGame()
    {
        SpawnedBall.NewSpawnerPositionGet = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
