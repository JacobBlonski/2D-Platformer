using UnityEngine;

public class Coin : MonoBehaviour
{
    public float coin = 1;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<PlayerCoin>().AddCoin(coin);
        Destroy(gameObject);
    }
}
