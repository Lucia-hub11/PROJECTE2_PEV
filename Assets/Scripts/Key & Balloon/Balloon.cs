using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public GameObject key;
    private Rigidbody keyRb;

    private void Start()
    {
        keyRb = key.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Explode();
        }
    }

    void Explode()
    {
        Destroy(gameObject);
        if (keyRb != null)
        {
            keyRb.isKinematic = false;
        }
    }
}
