using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;
    public GameObject Player;

    public static Action<float> OnDamage;

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

        if (currentHealth <= 0)
        {
            //muerte
            //Destroy(Player);
            Debug.Log("MUERTA");
        }
    }
}
