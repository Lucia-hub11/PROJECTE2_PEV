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

    public static Action OnParty;
    

    void Start()
    {
        _rg = GetComponent<Rigidbody>();
        screenEffect = FindObjectOfType<ScreenEffect>();
        waterBlood = FindObjectOfType<WaterBlood>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject ExplosionSystem = Instantiate(Explosion, transform.position, Quaternion.identity);
        if (screenEffect != null)
        {
            screenEffect.OnObjectDestroyed();
            waterBlood.OnObjectDestroyed();
        }
        Destroy(gameObject);
        Destroy(ExplosionSystem, 1f);
        OnParty?.Invoke();
        

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