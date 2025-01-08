using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public InputControllers _inputs;
    public RadioArea radioArea;
    private AudioSource MusicaInfantil;
    
    void Start()
    {

        if (_inputs == null)
        {
            Debug.LogError("InputControllers no està assignat o no es troba al mateix GameObject.");
        }

        MusicaInfantil = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (radioArea.IsRadioDetected())
        {
            if (!MusicaInfantil.isPlaying)
            {
                if (ShouldPlay())
                    MusicPlay();
            }
        }
   
    }

    private bool ShouldPlay()
    {
        return _inputs.Interact;

    }

    private void MusicPlay()
    {
        MusicaInfantil.Play();
    }
}
