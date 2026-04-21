using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    private bool canReceiveDamage = true;
    public float invincibilityTimer = 2;

    public delegate void HealthChangedHandler(float newHealth, float amountChanged);
    public event HealthChangedHandler OnHealthChanged;

    public delegate void HealthHandler(float newHealth);
    public event HealthHandler OnHealthInitialize;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        currentHealth = maxHealth;
        OnHealthInitialize?.Invoke(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddDamage(float damage)
    {

        if (canReceiveDamage)
        {
            currentHealth -= damage;
            OnHealthChanged?.Invoke(currentHealth, -damage);
            canReceiveDamage = false;
            StartCoroutine(InvincibilityTimer(invincibilityTimer, ResetInvincibility));
        }
        Debug.Log(currentHealth);
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
        currentHealth += healthToAdd;
        OnHealthChanged?.Invoke(currentHealth, healthToAdd); 
        Debug.Log(currentHealth);
    }

    internal void AddCollect(Collider2D collect)
    {
        throw new NotImplementedException();
    }

    internal void AddCollection(object collect)
    {
        throw new NotImplementedException();
    }
}