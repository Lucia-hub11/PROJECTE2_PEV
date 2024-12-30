using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LightSwitch : MonoBehaviour
{
    public Light roomLight;
    public Renderer lampRenderer; // Modificar l'emissi? de la textura de la llum
    public Text interactionText;

    private bool isPlayerNearby = false;
    private PlayerInput playerInput;
    private InputAction interactAction;

    void Start()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        interactAction = playerInput.actions["Interact"];

        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(false);
        }

        UpdateEmission(roomLight.enabled);
    }

    void Update()
    {
        if (isPlayerNearby && interactAction != null && interactAction.triggered)
        {
            roomLight.enabled = !roomLight.enabled;
            UpdateEmission(roomLight.enabled);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
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
            if (interactionText != null)
            {
                interactionText.gameObject.SetActive(false);
            }
        }
    }

    void UpdateEmission(bool isOn)
    {
        if (lampRenderer != null)
        {
            Material material = lampRenderer.material;

            if (isOn)
            {
                material.EnableKeyword("_EMISSION");
            }
            else
            {
                material.DisableKeyword("_EMISSION");
            }
        }
    }
}
