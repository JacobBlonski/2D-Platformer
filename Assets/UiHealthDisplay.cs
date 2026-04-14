using TMPro;
using UnityEngine;

public class UiHealthDisplay : MonoBehaviour
{
    //Referencja do PlayerHealth
    public TextMeshProUGUI healthtext;
    public PlayerHealth playerHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth.OnHealthChanged += OnHealthChanged;
        playerHealth.OnHealthInitialize += OnHealthInitialize;
    }

    public void OnHealthChanged(float newHealth, float amountChanged)
    {
        //Debug.Log("On Health Changed Event");
        healthtext.text = newHealth.ToString();
    }

    public void OnHealthInitialize(float newHealth)
    {

        healthtext.text += newHealth.ToString();
    }
}
