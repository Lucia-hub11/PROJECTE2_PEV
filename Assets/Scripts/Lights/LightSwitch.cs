using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI; // Importar para trabajar con UI

public class LightSwitch : MonoBehaviour
{
    public Light roomLight; // Drag the light here in the editor
    public Text interactionText; // Texto en el canvas para mostrar el mensaje
    private bool isPlayerNearby = false;

    private PlayerInput playerInput; // Reference to PlayerInput from the Input System
    private InputAction interactAction; // Action for interacting

    void Start()
    {
        // Find the PlayerInput in the player object
        playerInput = FindObjectOfType<PlayerInput>();

        // Get the action associated with interacting
        interactAction = playerInput.actions["Interact"]; // Make sure "Interact" exists in your action map

        // Aseg?rate de que el texto no sea visible al inicio
        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Check if the player is nearby and has pressed the interact button
        if (isPlayerNearby && interactAction != null && interactAction.triggered)
        {
            roomLight.enabled = !roomLight.enabled; // Toggle the light's state
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the Player has the "Player" tag
        {
            isPlayerNearby = true;

            // Mostrar el texto en el canvas
            if (interactionText != null)
            {
                interactionText.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;

            // Ocultar el texto en el canvas
            if (interactionText != null)
            {
                interactionText.gameObject.SetActive(false);
            }
        }
    }
}
