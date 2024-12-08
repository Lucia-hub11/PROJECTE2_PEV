using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestruction : MonoBehaviour
{
    private Rigidbody _rg;
    public GameObject Explosion;
    private ScreenEffect screenEffect;

    public static Action OnParty;
    

    // Start is called before the first frame update
    void Start()
    {
        _rg = GetComponent<Rigidbody>();
        screenEffect = FindObjectOfType<ScreenEffect>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject ExplosionSystem = Instantiate(Explosion, transform.position, Quaternion.identity);
        if (screenEffect != null)
        {
            screenEffect.OnObjectDestroyed();
        }
        Destroy(gameObject);
        Destroy(ExplosionSystem, 1f);
        OnParty?.Invoke();
        

    }

    void OnDestroy()
    {
        FindObjectOfType<ScreenEffect>().OnObjectDestroyed();
    }

    // Update is called once per frame
    void Update()
    {

    }
}