using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    [SerializeField] private List<Scene> _sceneList;
    private GameObject nextLevelButton;

    public void GoToNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("pashol" + " " + currentScene + " " + _sceneList.Count);
        if (currentScene < _sceneList.Count)
            SceneManager.LoadScene(_sceneList[currentScene + 1].buildIndex);
    }
}
