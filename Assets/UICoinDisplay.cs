using TMPro;
using UnityEngine;

public class UICoinDisplay : MonoBehaviour
{
    public TextMeshPro CoinText;
    public PlayerCoin PlayerCoin;

    void Awake()
    {
        PlayerCoin.OncoinChanged += OnCoinChanged;
        PlayerCoin.OncoinInitialize += OnCoinInit;
    }

    private void OnCoinInit(float newCoin)
    {
        CoinText.text = newCoin.ToString();
    }

    private void OnCoinChanged(float newCoin, float amountChanged)
    {
        CoinText.text = newCoin.ToString();
    }

}