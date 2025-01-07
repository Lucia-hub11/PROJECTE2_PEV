using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public GameObject doorCollider;
    public GameObject paintingCollider;

    // Start is called before the first frame update
    void Start()
    {
        doorCollider.SetActive(false);
        paintingCollider.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            doorCollider.SetActive(true);
            Destroy(gameObject);

            paintingCollider.SetActive(true);
        }
    }
}
