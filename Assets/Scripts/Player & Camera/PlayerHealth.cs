using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //public float maxHealth = 100;
    public float currentHealth = 100;

    public void TakeDamage(float amount)
    {
        //Debug.Log("DAMAGE " + amount);
        currentHealth = currentHealth - amount;

        if (currentHealth == 0)
        {
            //muerte
            Debug.Log("MUERTA");
        }
    }
}
