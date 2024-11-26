using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    InputControllers _input;

    public GameObject Prefab;
    public GameObject BulletSpawn;
    private Rigidbody _rg;
    public float bulletspeed;
    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<InputControllers>();
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
        if (ShouldShoot())
            SpawnBullet();
    }

    private bool ShouldShoot()
    {
        return _input.Shoot;
    }

    private void SpawnBullet()
    {
        Instantiate(Prefab, BulletSpawn.transform.position, BulletSpawn.transform.rotation);
    }
}
