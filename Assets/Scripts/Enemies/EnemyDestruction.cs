using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestruction : MonoBehaviour
{
    private Rigidbody _rg;
    public GameObject Explosion;
    private ScreenEffect screenEffect;
    private WaterBlood waterBlood;

    //audio
    public static Action OnParty;


    void Start()
    {
        _rg = GetComponent<Rigidbody>();
        screenEffect = FindObjectOfType<ScreenEffect>();
        waterBlood = FindObjectOfType<WaterBlood>();
        Debug.Log("HOLA ?????");
    }

    private void OnTriggerEnter(Collider collision)
    {
        //if (screenEffect != null)
        //{
        //    screenEffect.OnObjectDestroyed();
        //    waterBlood.OnObjectDestroyed();
        //}

        if (collision.tag == "Bullet")
        {
            Debug.Log("HOLA??");
            GameObject ExplosionSystem = Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(ExplosionSystem, 1f);
            OnParty?.Invoke();

            Debug.Log("ATACA PLAYER");
            var healthComponent = collision.GetComponent<PlayerHealth>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(1);
                Debug.Log("DAMAGE");
            }
        }
        if (collision.tag == "Player")
        {
           
        }



    }

    void OnDestroy()
    {
        if (screenEffect != null)
        {
            screenEffect.OnObjectDestroyed();
        }

        if (waterBlood != null)
        {
            waterBlood.OnObjectDestroyed();
        }
    }

}