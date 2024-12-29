using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;

    void start()
    {
        currentHealth = 200;

    }

    public void TakeDamage(float amount)
    {
        //Debug.Log("DAMAGE " + amount);
        currentHealth = currentHealth - amount;
        Debug.Log("CURRENT H " + currentHealth);
        if (currentHealth == 0)
        {
            //muerte
            Debug.Log("MUERTA");
        }
    }
}
