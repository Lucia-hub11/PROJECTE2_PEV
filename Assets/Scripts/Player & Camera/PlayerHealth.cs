using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;
    public GameObject Player;

    void Start()
    {
        currentHealth = maxHealth;

    }

    public void TakeDamage(float amount)
    {
        //Debug.Log("DAMAGE " + amount);
        currentHealth = currentHealth - amount;
        Debug.Log("CURRENT H " + currentHealth);
        if (currentHealth <= 0)
        {
            //muerte
            //Destroy(Player);
            Debug.Log("MUERTA");
        }
    }
}
