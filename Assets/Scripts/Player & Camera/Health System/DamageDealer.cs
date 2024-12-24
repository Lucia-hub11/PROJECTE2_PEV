using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float Damage = 5;
    
    private void OnCollisionEnter(Collision collision)
    {
        ITakeDamage[] damageTakers =
            collision.collider.GetComponent<ITakeDamage>();
        if (damageTakers != null)
        {
            foreach (var item in damageTakers)
            {
                item.TakeDamage(Damage);
            }
        }
    }
}
