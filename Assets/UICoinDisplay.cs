using TMPro;
using UnityEngine;

public class UICoinDisplay : MonoBehaviour
{
    public TextMeshProUGUI CoinText;
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
        Debug.Log("145145818");
        CoinText.text = newCoin.ToString();
    }

}