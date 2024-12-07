using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class AudioManager : MonoBehaviour
{
    InputControllers _inputs;
    public RadioArea radioArea;
    private AudioSource MusicaInfantil;

    //private bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        _inputs = GetComponent<InputControllers>();
        if (_inputs == null)
        {
            Debug.LogError("InputControllers no està assignat o no es troba al mateix GameObject.");
        }
        
        MusicaInfantil = GetComponent<AudioSource>();

    }

    void Update()
    {
        //// Comprovar si el jugador està dins del rang de la ràdio
        //if (radioArea != null && radioArea.IsRadioDetected())
        //{
        //    // Si prems 'E' i la música no està sonant, la reprodueix
        //    if (_inputs.Interact && !isPlaying)
        //    {
        //        MusicaInfantil.Play();
        //        isPlaying = true; // Actualitza l'estat a reproducció
        //    }
        //    // Si prems 'E' i la música està sonant, la para
        //    else if (_inputs.Interact && isPlaying)
        //    {
        //        MusicaInfantil.Stop();
        //        isPlaying = false; // Actualitza l'estat a aturada
        //    }
        //}


        //if (radioArea.IsRadioDetected())
        //{
        //    if (ShouldPlay())
        //    {
        //        MusicaInfantil.Play();
        //    }
            
        //}

        if (radioArea.IsRadioDetected())
        {
            if (!MusicaInfantil.isPlaying)
            {
                if (ShouldPlay())
                    Play();
            }
        }
        else
        {
            if (MusicaInfantil.isPlaying)
            {
                MusicaInfantil.Stop();
            }
        }


    }

    private bool ShouldPlay()
    {
        return _inputs.Interact;
    }

    private void Play()
    {
        MusicaInfantil.Play();
    }

}
