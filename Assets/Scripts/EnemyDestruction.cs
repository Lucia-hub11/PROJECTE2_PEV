using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestruction : MonoBehaviour
{
    private Rigidbody _rg;
    public GameObject Explosion;
    private ScreenEffect screenEffect;
    private WaterBlood waterBlood;

    // Start is called before the first frame update
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
    }

    void OnDestroy()
    {
        //FindObjectOfType<ScreenEffect>().OnObjectDestroyed();
        //FindObjectOfType<WaterBlood>().OnObjectDestroyed();

        //ScreenEffect screenEffect = FindObjectOfType<ScreenEffect>();
        //WaterBlood waterBlood = FindObjectOfType<WaterBlood>();

        if (screenEffect != null)
        {
            screenEffect.OnObjectDestroyed();
        }

        if (waterBlood != null)
        {
            waterBlood.OnObjectDestroyed();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}