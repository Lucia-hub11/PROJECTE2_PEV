using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingScript : MonoBehaviour
{
    public GameObject paintingCollider;

    // Start is called before the first frame update
    void Start()
    {
        paintingCollider.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            paintingCollider.SetActive(true);
        }
    }
}