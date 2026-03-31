using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public float health = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("col");
        collision.GetComponent<PlayerHealth>().AddHealth(health);
        Destroy(gameObject);
    }

}