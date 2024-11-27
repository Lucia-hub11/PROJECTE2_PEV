using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Header("Target to follow")]
    public Transform target; // El objetivo a seguir (por ejemplo, el jugador)

    [Header("Offset settings")]
    public Vector3 offset = new Vector3(0, 5, -10); // Offset inicial de la cámara respecto al objetivo

    [Header("Smoothness settings")]
    [Range(0, 1)] public float smoothSpeed = 0.125f; // Velocidad de suavizado (entre 0 y 1)

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Target is not assigned!");
            return;
        }

        // Calcula la posición deseada
        Vector3 desiredPosition = target.position + offset;

        // Suaviza la transición entre la posición actual y la deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Asigna la posición suavizada a la cámara
        transform.position = smoothedPosition;

        // Opcional: Si quieres que la cámara siempre mire al objetivo
       // transform.LookAt(target);
    }
}
