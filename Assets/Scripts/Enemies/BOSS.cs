using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;
    public GameObject Player;

    public static Action<float> OnDamage;
    public static Action<float> OnApple;

    void Start()
    {
        currentHealth = maxHealth;

    }

    public void TakeDamage(float amount)
    {
        //Debug.Log("DAMAGE " + amount);
        currentHealth = currentHealth - amount;
        Debug.Log("CURRENT H " + currentHealth);

        OnDamage?.Invoke(currentHealth / maxHealth);
        OnApple?.Invoke(currentHealth / maxHealth);

        if (currentHealth <= 0)
        {
            //muerte
            //Destroy(Player);
            Debug.Log("MUERTA");
        }
    }
}