using UnityEngine;

public class PlayerCoin : MonoBehaviour
{
    public float coin;

    public delegate void CoinChangedHandler(float newCoin, float amountChanged);
    public event CoinChangedHandler OncoinChanged;

    public delegate void CoinInitializerHandler(float newCoin);
    public event CoinInitializerHandler OncoinInitialize;


    void Start()
    {

    }


    void Update()
    {

    }

    public void AddCoin(float  coinToAdd)
    {
        coin += coinToAdd;
        OncoinChanged?.Invoke(coin, coinToAdd);

    }
}
