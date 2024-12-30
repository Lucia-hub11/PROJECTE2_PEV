using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light luzHabitacion; // Arrastra la luz en el editor
    private bool jugadorCerca = false;

    private InputControllers inputControllers; // Referencia al controlador de entrada

    void Start()
    {
        // Busca el componente InputControllers en el jugador
        inputControllers = FindObjectOfType<InputControllers>();
        if (inputControllers == null)
        {
            Debug.LogError("No se encontró un InputControllers en la escena.");
        }
    }

    void Update()
    {
        // Comprueba si el jugador está cerca y ha pulsado interactuar
        if (jugadorCerca && inputControllers != null && inputControllers.Interact)
        {
            luzHabitacion.enabled = !luzHabitacion.enabled; // Cambia el estado de la luz
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el Player tiene el tag "Player"
        {
            jugadorCerca = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
        }
    }
}
