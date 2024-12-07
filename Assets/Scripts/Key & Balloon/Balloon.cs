using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public GameObject key; // La llave que caerá
    private Rigidbody keyRb;

    private void Start()
    {
        keyRb = key.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet")) // La bala debe tener el tag "Bullet"
        {
            Explode();
        }
    }

    void Explode()
    {
        // Elimina el globo y permite que la llave caiga
        Destroy(gameObject);
        if (keyRb != null)
        {
            keyRb.isKinematic = false; // Asegúrate de que pueda ser afectado por la física
        }
    }
}
