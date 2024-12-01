using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    InputControllers _inputs;

    public GameObject Prefab;
    public GameObject Spark;
    public GameObject BulletSpawn;
    private Rigidbody _rg;
    public float bulletspeed;

    public LayerMask apuntaColliderLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        _inputs = GetComponent<InputControllers>();
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

    // Update is called once per frame
    void Update()
    {
        if (ShouldShoot())
            SpawnBullet();

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, apuntaColliderLayerMask))
        {
            transform.position = raycastHit.point;
        }
    }

    private bool ShouldShoot()
    {
        return _inputs.Shoot;
    }

    private void SpawnBullet()
    {
        Instantiate(Prefab, BulletSpawn.transform.position, BulletSpawn.transform.rotation);
    }
}
