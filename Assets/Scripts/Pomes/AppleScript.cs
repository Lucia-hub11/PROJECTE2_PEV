using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
    void Start()
    {
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("ÑAM");
            var healthComponent = collision.GetComponent<PlayerHealth>();
            if (healthComponent != null)
            {
                healthComponent.TakeHealth(20);
                Debug.Log("healthy");
            }

            Destroy(gameObject);
        }
    }
}
