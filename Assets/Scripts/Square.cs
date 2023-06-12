using TMPro;
using UnityEngine;

public class Square : MonoBehaviour
{
    [SerializeField] private int hp; 
    [SerializeField] private TextMeshProUGUI hpText;

    private float maxHP = 40f;
    private void Start()
    {
        hpText.transform.position = gameObject.transform.position;
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void FixedUpdate()  
    {
        hpText.text = hp.ToString();

        float hpPercentage = (float)hp / maxHP;
        GetComponent<SpriteRenderer>().color = new Color(1f , 1f - hpPercentage, 1f - hpPercentage);
        
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag($"Ball"))
        {
            hp -= 1;    
        }
    }
}
