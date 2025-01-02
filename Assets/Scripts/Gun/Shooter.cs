using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    InputControllers _inputs;

    public GameObject Prefab;
    public GameObject BulletSpawn;
    public LayerMask DefaultColliderLayerMask;
    public LayerMask GroundColliderLayerMask;
    public static Action OnBullet;
    public Transform GunPosition;
    void Start()
    {
        _inputs = GetComponentInParent<InputControllers>();
    }

    void Update()
    {
        transform.position = GunPosition.position;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHitDefault, 999f, DefaultColliderLayerMask))
        {
            transform.LookAt(raycastHitDefault.point);
        }
        if (Physics.Raycast(ray, out RaycastHit raycastHitGround, 999f, GroundColliderLayerMask))
        {
            transform.LookAt(raycastHitGround.point);
        }

        if (ShouldShoot())
            SpawnBullet();
    }

    private bool ShouldShoot()
    {
        return _inputs.Shoot;
    }

    private void SpawnBullet()
    {
        Instantiate(Prefab, BulletSpawn.transform.position, BulletSpawn.transform.rotation);
        OnBullet?.Invoke();
    }
}
