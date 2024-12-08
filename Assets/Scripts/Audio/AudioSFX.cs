using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSFX : MonoBehaviour
{
    
    void Start()
    {
        Shooter.OnBullet += Piu;
    }

    
    private void Piu()
    {
        GetComponent<AudioSource>().Play();
    }
}
