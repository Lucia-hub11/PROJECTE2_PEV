using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject Prefab;
    private Rigidbody _rg;
    public float bulletspeed;
    // Start is called before the first frame update
    void Start()
    {
        _rg = GetComponent<Rigidbody>();
        Applyspeed();
        DestroyBullet();
    }
    private void DestroyBullet()
    {
        Destroy(gameObject, 1);
    }

    private void Applyspeed()
    {
        _rg.velocity = transform.forward * bulletspeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            ShouldShoot();
    }

    private void ShouldShoot()
    {
        SpawnBullet();
    }

    private void SpawnBullet()
    {
        Instantiate(Prefab, transform.position, Quaternion.identity);
    }
}
