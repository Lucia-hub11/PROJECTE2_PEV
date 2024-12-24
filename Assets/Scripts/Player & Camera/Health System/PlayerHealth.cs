using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, ITakeDamage
{
    public void TakeDamage(float amount)
    {
        Debug.log("OUCH");
    }
}
