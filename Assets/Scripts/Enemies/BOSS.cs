using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS : MonoBehaviour
{
    public float maxHealth = 5;
    private float currentHealth;
    public GameObject boss;
    public WinScreen WinScreen;

    public static Action<float> OnBossDamage;

    void Start()
    {
        currentHealth = maxHealth;

    }

    public void TakeDamage(float amount)
    {
        currentHealth = currentHealth - amount;
        OnBossDamage?.Invoke(currentHealth / maxHealth);

        if (currentHealth <= 0)
        {
            //muerte
            Destroy(boss);
            WinScreen.Setup();
        }
    }
}