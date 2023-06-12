using TMPro;
using UnityEngine;
public class BallsCounter : MonoBehaviour
{
    [SerializeField] private GameObject spawner;
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = Spawner.BallCounterString;
        transform.position = new Vector3(spawner.transform.position.x, spawner.transform.position.y - 0.5f,
            10);
    }
    
}
