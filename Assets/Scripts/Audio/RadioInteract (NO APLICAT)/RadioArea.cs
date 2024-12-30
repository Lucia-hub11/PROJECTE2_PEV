using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Importar para usar UI

public class RadioArea : MonoBehaviour
{
    public float RadioRange = 4;
    public Transform WayPoint;
    public GameObject interactText; // Referencia al texto del Canvas

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, RadioRange);
    }

    void Start()
    {
        if (interactText != null)
        {
            interactText.SetActive(false); // Asegurarse de que el texto esté oculto al inicio
        }
    }

    void Update()
    {
        if (IsRadioDetected())
        {
            ShowInteractText(true);
        }
        else
        {
            ShowInteractText(false);
        }
    }

    public bool IsRadioDetected()
    {
        return IsInRadioRange(WayPoint);
    }

    private bool IsInRadioRange(Transform target)
    {
        return Vector3.Distance(transform.position, target.position) < RadioRange;
    }

    private void ShowInteractText(bool show)
    {
        if (interactText != null)
        {
            interactText.SetActive(show);
        }
    }
}
