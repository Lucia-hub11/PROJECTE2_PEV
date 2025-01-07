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
    private DarkerLight darkerLight;
    private BrokeLantern lantern;

    public static Action OnParty;

    private bool playerIsHere;

    public bool IsPlayerHere()
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
        darkerLight = FindObjectOfType<DarkerLight>();

        lantern = FindObjectOfType<BrokeLantern>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(gameObject.tag == "Enemy")
        {
            if (collision.tag == "Bullet")
            {
                GameObject ExplosionSystem = Instantiate(Explosion, transform.position, Quaternion.identity);

                darkerLight?.OnObjectDestroyed(); //

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
                }
                playerIsHere = true;
            }
        }
        if (gameObject.tag == "Boss")
        {
            if (collision.tag == "Bullet")
            {
                var bossHealth = gameObject.GetComponent<BOSS>();
                if (bossHealth != null)
                {
                    bossHealth.TakeDamage(1);
                }
            }
            if (collision.tag == "Player")
            {
                var healthComponent = collision.GetComponent<PlayerHealth>();
                if (healthComponent != null)
                {
                    healthComponent.TakeDamage(5);
                }
                if (screenEffect != null)
                {
                    screenEffect.OnDamageTaken();
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
        waterBlood.OnObjectDestroyed();

        angrierBunnies.OnObjectDestroyed();

        basement.OnObjectDestroyed();

        lantern.OnObjectDestroyed();
    }
}