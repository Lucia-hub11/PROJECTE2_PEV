using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSFX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Shooter.OnBullet += Piu;
    }

    // Update is called once per frame
    private void Piu()
    {
        GetComponent<AudioSource>().Play();
    }
}
