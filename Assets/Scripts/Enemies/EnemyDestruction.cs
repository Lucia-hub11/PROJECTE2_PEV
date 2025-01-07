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
    private AngrierBunnies angrierBunnies;
    private Basement basement;
    private BrokeLantern lantern;

    //audio
    public static Action OnParty;

    private bool playerIsHere;

    public bool IsPlayerHere() //bool per els Behaviours del enemy conills
    {
        return playerIsHere;
    }


    void Start()
    {
        _rg = GetComponent<Rigidbody>();
        screenEffect = FindObjectOfType<ScreenEffect>();
        waterBlood = FindObjectOfType<WaterBlood>();
        angrierBunnies = FindObjectOfType<AngrierBunnies>();
        basement = FindObjectOfType<Basement>();
        lantern = FindObjectOfType<BrokeLantern>();
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
                if (screenEffect != null)
                {
                    screenEffect.OnDamageTaken();
                    Debug.Log("TIENE EL SCREEN EFFECT");
                }
                playerIsHere = true;
            }
        }
        if (gameObject.tag == "Boss")
        {
            if (collision.tag == "Bullet")
            {
                Debug.Log("BALA TOCA");
                var bossHealth = gameObject.GetComponent<BOSS>();
                if (bossHealth != null)
                {
                    Debug.Log("TIENE SALUD");
                    bossHealth.TakeDamage(1);
                }
            }
            if (collision.tag == "Player")
            {
                var healthComponent = collision.GetComponent<PlayerHealth>();
                if (healthComponent != null)
                {
                    healthComponent.TakeDamage(10);
                }
                if (screenEffect != null)
                {
                    screenEffect.OnDamageTaken();
                    Debug.Log("TIENE EL SCREEN EFFECT");
                }
                playerIsHere = true;
            }
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            playerIsHere = false;
        }
    }


    void OnDestroy()
    {
        //SHADER PRIMERA VERSI�
        //if (screenEffect != null)
        //{
        //    screenEffect.OnObjectDestroyed();
        //}

        if (waterBlood != null)
        {
            waterBlood.OnObjectDestroyed();
        }

        angrierBunnies.OnObjectDestroyed();
        if (basement != null)
        {
            basement.OnObjectDestroyed();
        }

        lantern.OnObjectDestroyed();
    }

    

}