using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Bullet")
        {
            _rb.useGravity = true;
        }
        if (collision.tag == "Player")
        {
            Debug.Log("ÑAM");
            var healthComponent = collision.GetComponent<PlayerHealth>();
            if (healthComponent != null)
            {
                healthComponent.TakeHealth(2);
                Debug.Log("healthy");
            }

            Destroy(gameObject);
        }
    }
}
