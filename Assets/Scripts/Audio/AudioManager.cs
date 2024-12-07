using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        //_inputs = GetComponent<InputControllers>();
        //GetComponent<RadioArea>().IsRadioDetected();
        
        //RadioArea.IsRadioDetected += OnMusica;

        

    }

    // Update is called once per frame
    private void OnMusica()
    {
        GetComponent<AudioSource>().Play();
    }





}
