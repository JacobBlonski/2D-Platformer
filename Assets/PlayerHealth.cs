using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float health;
    private bool canReceiveDamage = true;
    public float invincibilityTimer = 2;

    public delegate void HealthChangedHandler(float newHealth, float amountChanged);
    public event HealthChangedHandler OnHealthChanged;

    public delegate void HealthHandler(float newHealth);
    public event HealthHandler OnHealthInitialize;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        OnHealthInitialize?.Invoke(health);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddDamage(float damage)
    {

        if (canReceiveDamage)
        {
            health -= damage;
            OnHealthChanged?.Invoke(health, -damage);
            canReceiveDamage = false;
            StartCoroutine(InvincibilityTimer(invincibilityTimer, ResetInvincibility));
        }
        Debug.Log(health);
    }

    IEnumerator InvincibilityTimer(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();

    }

    private void ResetInvincibility()
    {
        canReceiveDamage = true;
    }
    public void AddHealth(float healthToAdd)
    {
        health += healthToAdd;
        OnHealthChanged?.Invoke(health, healthToAdd); 
        Debug.Log(health);
    }
}