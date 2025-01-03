using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooting : MonoBehaviour
{
    private Rigidbody _rg;
    public float bulletspeed;
    public GameObject Spark;

    void Start()
    {
        _rg = GetComponent<Rigidbody>();
        Applyspeed();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject SparkSystem = Instantiate(Spark, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(SparkSystem, 0.25f);
    }

    private void Applyspeed()
    {
        _rg.velocity = transform.forward * bulletspeed;
    }
}
