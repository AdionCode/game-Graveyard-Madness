using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;


    void Start()
    {
        
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

        
    }

    // Kurangi darah saat terkena serangan player
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Healt decrease");
    }

    
}
