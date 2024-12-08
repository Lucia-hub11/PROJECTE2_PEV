using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPartyEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EnemyDestruction.OnParty += PartyBlower;
    }

    private void PartyBlower()
    {
        GetComponent<AudioSource>().Play();
    }
}
