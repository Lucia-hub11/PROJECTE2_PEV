using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitch : MonoBehaviour
{
    public Light roomLight; // Drag the light here in the editor
    private bool isPlayerNearby = false;

    private PlayerInput playerInput; // Reference to PlayerInput from the Input System
    private InputAction interactAction; // Action for interacting

    void Start()
    {
        // Find the PlayerInput in the player object
        playerInput = FindObjectOfType<PlayerInput>();

        // Get the action associated with interacting
        interactAction = playerInput.actions["Interact"]; // Make sure "Interact" exists in your action map
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
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}
