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
    }

    private void OnTriggerEnter(Collider collision)
    {
        //if (screenEffect != null)
        //{
        //    screenEffect.OnObjectDestroyed();
        //    waterBlood.OnObjectDestroyed();
        //}
        if(gameObject.tag == "Enemy")
        {
            if (collision.tag == "Bullet")
            {
                GameObject ExplosionSystem = Instantiate(Explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(ExplosionSystem, 1f);
                OnParty?.Invoke();
            }
            if (collision.tag == "Player")
            {
                var healthComponent = collision.GetComponent<PlayerHealth>();
                if (healthComponent != null)
                {
                    healthComponent.TakeDamage(1);
                }
            }
        }
        if (gameObject.tag == "Boss")
        {
            if (collision.tag == "Bullet")
            {
                GameObject ExplosionSystem = Instantiate(Explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(ExplosionSystem, 1f);
                OnParty?.Invoke();
            }
            if (collision.tag == "Player")
            {
                var healthComponent = collision.GetComponent<PlayerHealth>();
                if (healthComponent != null)
                {
                    healthComponent.TakeDamage(10);
                }
            }
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