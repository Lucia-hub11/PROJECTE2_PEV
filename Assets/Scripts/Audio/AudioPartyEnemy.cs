using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPartyEnemy : MonoBehaviour
{
    
    void Start()
    {
        EnemyDestruction.OnParty += PartyBlower;
    }

    private void PartyBlower()
    {
        GetComponent<AudioSource>().Play();
    }
}
