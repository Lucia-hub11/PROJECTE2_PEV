using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitch : MonoBehaviour
{
    public Light luzHabitacion; // Arrastra la luz en el editor
    private bool jugadorCerca = false;

    private PlayerInput playerInput; // Referencia a PlayerInput del Input System
    private InputAction interactAction; // Acción para interactuar

    void Start()
    {
        // Busca el PlayerInput en el jugador
        playerInput = FindObjectOfType<PlayerInput>();
        if (playerInput == null)
        {
            Debug.LogError("No se encontró un PlayerInput en la escena.");
            return;
        }

        // Obtén la acción asociada con interactuar
        interactAction = playerInput.actions["Interact"]; // Asegúrate de que "Interact" existe en tu mapa de acciones
    }

    void Update()
    {
        // Comprueba si el jugador está cerca y ha pulsado interactuar
        if (jugadorCerca && interactAction != null && interactAction.triggered)
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
